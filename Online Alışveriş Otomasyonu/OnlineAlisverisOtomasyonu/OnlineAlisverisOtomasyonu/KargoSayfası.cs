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
    public partial class KargoSayfası : Form
    {
        public string kullanici_adi { get; set; }
        public KargoSayfası()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";
        private void KargoSayfası_Load(object sender, EventArgs e)
        {

          

            SqlConnection connection2 = new SqlConnection(connectionString);
            connection2.Open();
            SqlCommand command2=new SqlCommand("MusteriAdiSoyadiAdres", connection2);
            command2.Parameters.AddWithValue("@kullaniciAdi", kullanici_adi);
            command2.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader1 = command2.ExecuteReader();
            int labelindex1 = 2;
            while (reader1.Read())
            {
                string  MusteriAdi = reader1["MusteriAdi"].ToString();
                string MusteriSoyadi = reader1["MusteriSoyadi"].ToString();
                string Adres = reader1["Adres"].ToString();
                

                Label label = (Label)this.Controls.Find("label" + labelindex1, true).FirstOrDefault();
                if (label != null)
                {

                    label.Text =
                        "Müşteri Adı: " + MusteriAdi + Environment.NewLine +
                        "Müşteri Soyadı : " + MusteriSoyadi + Environment.NewLine +
                        "Adres : " + Adres + Environment.NewLine;

                }
                
            }

            labelindex1++;

            connection2.Close();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("kargoListele", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                int siparisID = Convert.ToInt16(reader["SiparisID"]);
                DateTime kargoTarihi =Convert.ToDateTime( reader["KargoTarihi"]);
                string kargoDurumu = reader["KargoDurumu"].ToString();
                string teslimatAdresi= reader["TeslimatAdresi"].ToString();
                

                Label label = (Label)this.Controls.Find("label" + labelindex1, true).FirstOrDefault();
                if (label != null)
                {

                    label.Text =
                        "Sipariş ID : " + siparisID + Environment.NewLine +
                        "Kargo Tarihi : " + kargoTarihi + Environment.NewLine +
                        "Kargo Durumu : " + kargoDurumu + Environment.NewLine +
                        

                        "Teslimat Adresi : " + teslimatAdresi + Environment.NewLine;
     

                }
           
            }

            connection.Close();
        }
    }
}
