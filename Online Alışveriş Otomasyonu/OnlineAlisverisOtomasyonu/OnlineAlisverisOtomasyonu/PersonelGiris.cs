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
    public partial class PersonelGiris : Form
    {
        public PersonelGiris()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";
        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox2.Text;
            string sifre = textBox1.Text;


            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT COUNT(*) FROM Personel WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @sifre";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            command.Parameters.AddWithValue("@sifre", sifre);

            int count = (int)command.ExecuteScalar();

            connection.Close();

            if (count > 0)
            {
                PersonelGenel personel = new PersonelGenel();
                personel.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            };
        }

        private void PersonelGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
