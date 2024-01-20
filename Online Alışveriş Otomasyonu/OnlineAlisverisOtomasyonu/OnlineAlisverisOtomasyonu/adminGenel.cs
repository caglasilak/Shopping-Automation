using CrystalDecisions.ReportAppServer.DataDefModel;
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
    public partial class adminGenel : Form
    {
        public adminGenel()
        {
            InitializeComponent();
        }

        private void adminGenel_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminUrunEkrani ekran = new adminUrunEkrani();
            ekran.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminMusteri adminMusteri = new adminMusteri();
            adminMusteri.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            personelekle ekle = new personelekle();
            ekle.Show();
        }


        public void backup()
        {
            string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";
            string serverName = "MEMO\\SQLEXPRESS";
            string databaseName = "OnlineAlisveriVT3";
            string backupPath = "C:\\Users\\mehme\\Desktop\\";
           // string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string backupFileName = $"{backupPath}{databaseName}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.bak";
                    string backupQuery = $"BACKUP DATABASE {databaseName} TO DISK = '{backupFileName}' WITH INIT";

                    SqlCommand cmd = new SqlCommand(backupQuery, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Yedek alma işlemi başarıyla tamamlandı.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }


      
        private void button4_Click(object sender, EventArgs e)
        {
            backup();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
