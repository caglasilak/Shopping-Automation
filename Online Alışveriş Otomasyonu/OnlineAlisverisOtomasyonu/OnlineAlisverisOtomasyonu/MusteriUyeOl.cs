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
    public partial class MusteriUyeOl : Form
    {

        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";
        public MusteriUyeOl()
        {
            InitializeComponent();
        }

        private void MusteriUyeOl_Load(object sender, EventArgs e)
        {
        }


        private void UyeOl()
        {
            string adi = txt_adi.Text;
            string soyadi = txt_soyad.Text;
            string kullaniciAdi = txt_kullanici.Text;
            string sifre = txt_sifre.Text;
            string adres = txt_adres.Text;
            string eposta = txt_adres.Text;
            string telefon = txt_telefon.Text;

           

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

            if (string.IsNullOrEmpty(adi))
            {
                MessageBox.Show("Lütfen adınızı girin.");
                return; // Ad girilmediği için fonksiyonu sonlandırıyoruz.
            }

            if (string.IsNullOrEmpty(soyadi))
            {
                MessageBox.Show("Lütfen soyadınızı girin.");
                return; // Soyad girilmediği için fonksiyonu sonlandırıyoruz.
            }

            // E-posta, telefon ve adres alanları zorunlu olmayabilir, ancak gerekiyorsa bu alanları da kontrol edebiliriz.
            // Burada sadece boş olup olmadıklarını kontrol ediyoruz.
            if (string.IsNullOrEmpty(eposta))
            {
                MessageBox.Show("Lütfen e-posta adresinizi girin.");
                return; // E-posta girilmediği için fonksiyonu sonlandırıyoruz.
            }

            if (string.IsNullOrEmpty(telefon))
            {
                MessageBox.Show("Lütfen telefon numaranızı girin.");
                return; // Telefon girilmediği için fonksiyonu sonlandırıyoruz.
            }

            if (string.IsNullOrEmpty(adres))
            {
                MessageBox.Show("Lütfen adresinizi girin.");
                return; // Adres girilmediği için fonksiyonu sonlandırıyoruz.
            }

            // Yukarıdaki koşullardan geçen bir kullanıcı, veritabanına kaydedilebilir.
          
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("MusteriEkle", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@adi", adi);
            command.Parameters.AddWithValue("@soyadi", soyadi);
            command.Parameters.AddWithValue("@kullaniciadi", kullaniciAdi);
            command.Parameters.AddWithValue("@sifre", sifre);
            command.Parameters.AddWithValue("@adres", adres);
            command.Parameters.AddWithValue("@eposta", eposta);
            command.Parameters.AddWithValue("@telefon", telefon);

            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Müşteri Kaydı Yapılmıştır! ");
            connection.Close();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            UyeOl();
           

        }
    }
}
