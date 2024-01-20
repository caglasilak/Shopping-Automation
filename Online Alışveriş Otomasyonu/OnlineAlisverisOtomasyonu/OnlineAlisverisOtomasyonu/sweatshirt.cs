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
    public partial class sweatshirt : Form
    {

        public string kullanici_adi { get; set; }
        
        public sweatshirt()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";
        private void sweatshirt_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("sweatshirtListele", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            int labelindex = 1;
            int[] fiyatlar = new int[10];
            int counter = 0;
            string urunAdi;
            string urunAciklamasi;      
            string Stok;
            string RenkID;

            //SİPARİŞLER TABLOSUNA EKLENECEK VERİLER
            int miktar = Convert.ToInt32(numericUpDown1.Value);
            decimal fiyat;
       
            int urunID;

            while (reader.Read())
            {
                 urunID =Convert.ToInt32( reader["UrunID"]);
                 urunAdi = reader["UrunAdi"].ToString();
                 urunAciklamasi = reader["UrunAciklamasi"].ToString();
                 fiyat = Convert.ToDecimal(reader["Fiyat"]);
                 Stok = reader["Stok"].ToString();
                 RenkID = reader["RenkID"].ToString();

                Label label = (Label)this.Controls.Find("label" + labelindex, true).FirstOrDefault();
                if (label != null)
                {
                    label.Text = "Ürün Adı : " + urunAdi + Environment.NewLine +
                        "Ürün Açıklaması : " + urunAciklamasi + Environment.NewLine +
                        "Fiyatı : " + fiyat + Environment.NewLine +
                        "Stok : " + Stok + Environment.NewLine +
                        "Rengi : " + RenkID;

                }

                //fiyatlar[counter] =Convert.ToInt32(fiyat);
                counter++;
                labelindex++;
            }
            connection.Close();

        }

        public void urunEkle()
        {
            int miktar = Convert.ToInt32(numericUpDown1.Value);
            int fiyat = 500;
            int musteriID = 1;
            int urunID = 1;



            

            //string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;Encrypt=true;TrustServerCertificate=false;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SiparisEkleme", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@miktar", miktar);
            command.Parameters.AddWithValue("@fiyat", fiyat);
           
            command.Parameters.AddWithValue("@urunID", urunID);


            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarıyla Eklendi");
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           urunEkle();
            OdemeEkran odemeEkran = new OdemeEkran();
            odemeEkran.kullanici_adi = kullanici_adi;
            odemeEkran.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            urunEkle();
            OdemeEkran odemeEkran = new OdemeEkran();
            odemeEkran.kullanici_adi = kullanici_adi;
            odemeEkran.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            urunEkle();
            OdemeEkran odemeEkran = new OdemeEkran();
            odemeEkran.kullanici_adi = kullanici_adi;
            odemeEkran.Show();
        }
    }
}
