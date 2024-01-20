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
    public partial class adminMusteri : Form
    {
        public adminMusteri()
        {
            InitializeComponent();
        }


        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";
        private void musteriListele()
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("MusteriListele", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            connection.Close();

            dataGridView1.DataSource = dataTable;
            this.Controls.Add(dataGridView1);
        }

        private void silinenmusteriListele()
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("SilinenMusteriListele", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            connection.Close();

            dataGridView1.DataSource = dataTable;
            this.Controls.Add(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteriListele();
        }

        public void delete()
        {

            int musterikullaniciID = Convert.ToInt32(textBox1.Text);

            

           
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("MusteriSilme", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@musteriKullaniciID", musterikullaniciID);

            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Müşteri başarıyla silindi");
            connection.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            silinenmusteriListele();
        }

        private void adminMusteri_Load(object sender, EventArgs e)
        {

        }
    }
}
