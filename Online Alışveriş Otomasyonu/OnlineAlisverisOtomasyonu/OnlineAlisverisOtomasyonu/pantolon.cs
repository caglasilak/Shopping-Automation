﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineAlisverisOtomasyonu
{
    public partial class pantolon : Form
    {
        public pantolon()
        {
            InitializeComponent();
        }

        public string kullanici_adi { get; set; }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";
        private void pantolon_Load(object sender, EventArgs e)
        {
            SqlConnection connection=new SqlConnection(connectionString);   
            connection.Open();

            SqlCommand command = new SqlCommand("pantolonListele", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            int labelindex = 1;
            while (reader.Read())
            {
                string urunAdi = reader["UrunAdi"].ToString();
                string urunAciklamasi = reader["UrunAciklamasi"].ToString();
                string fiyat = reader["Fiyat"].ToString();
                string Stok = reader["Stok"].ToString();
                string RenkID = reader["RenkID"].ToString();

                Label label = (Label)this.Controls.Find("label" + labelindex, true).FirstOrDefault();
                if (label != null)
                {
                    label.Text = "Ürün Adı : "+ urunAdi + Environment.NewLine +
                        "Ürün Açıklaması : "+urunAciklamasi+ Environment.NewLine+
                        "Fiyatı : "+ fiyat+ Environment.NewLine+
                        "Stok : "+Stok+ Environment.NewLine+
                        "Rengi : "+RenkID;
                   
                }
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

 