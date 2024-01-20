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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlineAlisverisOtomasyonu
{
    public partial class personelekle : Form
    {
        public personelekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminKayit();
        }
        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";

        private void AdminKayit()
        {
            string kullaniciAdi = textBox2.Text;
            string sifre = textBox1.Text;

            // Kullanıcı adı, şifre, ad ve soyad zorunlu alanlar olduğundan bu alanların dolu olup olmadığını kontrol ediyoruz
            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Lütfen kullanıcı adınızı girin.");
                return; // Kullanıcı adı girilmediği için fonksiyonu sonlandırıyoruz.
            }

            if (string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen şifrenizi girin.");
                return; // Şifre girilmediği için fonksiyonu sonlandırıyoruz.
            }



            // Yukarıdaki koşullardan geçen bir kullanıcı, veritabanına kaydedilebilir.
           
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("PersonelEkle", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@kullaniciadi", kullaniciAdi);
            command.Parameters.AddWithValue("@sifre", sifre);

            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Personel Kaydı Yapılmıştır!");
            connection.Close();
        }
    }
}
