using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineAlisverisOtomasyonu
{
    public partial class MusteriAnasayfa : Form
    {

        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";
        public string kullanici_adi { get; set; }
        public MusteriAnasayfa(string kullanici)
        { 
            kullanici_adi = kullanici;
        }
        public MusteriAnasayfa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Elbise elbise = new Elbise();
            elbise.kullanici_adi = kullanici_adi;
            elbise.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pantolon pantolon = new pantolon();
            pantolon.kullanici_adi=kullanici_adi;

            pantolon.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sweatshirt sweatshirt = new sweatshirt();
            sweatshirt.kullanici_adi = kullanici_adi;
            sweatshirt.Show();
        }

        private void MusteriAnasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Kullanıcı tarafından girilen isim
            string arananIsim = textBox1.Text.Trim();

            if (arananIsim != "")
            {
                string urunAdi = textBox1.Text.Trim();

                // Veritabanı bağlantısı ve sorgu oluşturma
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Urunler WHERE UrunAdi LIKE @UrunAdi";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunAdi", "%" + urunAdi + "%");

                    // Veri okuyucu ile sorgu çalıştırma
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // DataGridView'e veri set etme
                    dataGridView1.DataSource = dataTable;

                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir isim girin!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decimal girilenFiyat = decimal.Parse(textBox2.Text);
            string siralamaTipi = comboBox1.Text;

            string query = "SELECT * FROM Urunler WHERE Fiyat <= @girilenFiyat";

            if (siralamaTipi == "Artan Fiyat" || siralamaTipi == null)
            {
                query += " ORDER BY Fiyat ASC";
            }
            else if (siralamaTipi == "Azalan Fiyat")
            {
                query += " ORDER BY Fiyat DESC";
            }
            else
            {
                // Sıralama seçilmediğinde varsayılan olarak ürün adına göre sırala
                query += " ORDER BY UrunAdi";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@girilenFiyat", girilenFiyat);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı işlemi sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string renkAdi = textBox3.Text;

            int renkID = GetRenkIDFromDatabase(renkAdi);

            if (renkID == -1)
            {
                MessageBox.Show("Geçerli bir renk giriniz!");
                return;
            }

            DataTable dt = GetUrunlerByRenkIDFromDatabase(renkID);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Bu renge ait ürün bulunamadı.");
                return;
            }
            dataGridView1.DataSource = dt;
        }


        private int GetRenkIDFromDatabase(string renkAdi)
        {
            int renkID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetRenkIDByAdi", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RenkAdi", renkAdi);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    renkID = Convert.ToInt32(result);
                }
            }

            return renkID;
        }


        private DataTable GetUrunlerByRenkIDFromDatabase(int renkID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetUrunlerByRenkID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RenkID", renkID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }

            return dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string kategoriAdi = textBox4.Text;

            int kategoriID = GetKategoriIDFromDatabase(kategoriAdi);

            if (kategoriID == -1)
            {
                MessageBox.Show("Geçerli bir kategori giriniz!");
                return;
            }

            DataTable dt = GetUrunlerByKategoriIDFromDatabase(kategoriID);
            dataGridView1.DataSource = dt;
        }


        private int GetKategoriIDFromDatabase(string kategoriAdi)
        {
            int kategoriID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetKategoriIDByAdi", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@KategoriAdi", kategoriAdi);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    kategoriID = Convert.ToInt32(result);
                }
            }

            return kategoriID;
        }


        private DataTable GetUrunlerByKategoriIDFromDatabase(int kategoriID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetUrunlerByKategoriID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@KategoriID", kategoriID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }

            return dt;
        }
    }
}
