using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace OnlineAlisverisOtomasyonu
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";



        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox2.Text;
            string sifre = textBox1.Text;

           
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT COUNT(*) FROM Adminler WHERE KullaniciAdi = @kullaniciAdi AND Sifre = @sifre";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            command.Parameters.AddWithValue("@sifre", sifre);

            int count = (int)command.ExecuteScalar();

            connection.Close();

            if (count > 0)
            {
                adminGenel adminPaneli = new adminGenel();
                adminPaneli.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            };


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
