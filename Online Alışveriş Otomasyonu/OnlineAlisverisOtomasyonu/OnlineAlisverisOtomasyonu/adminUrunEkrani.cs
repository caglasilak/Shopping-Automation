using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OnlineAlisverisOtomasyonu
{
    public partial class adminUrunEkrani : Form
    {
        public adminUrunEkrani()
        {
            InitializeComponent();
         
        }
        string connectionString = "Data Source=MEMO\\SQLEXPRESS;Initial Catalog=OnlineAlisveriVT3;User ID=1996;Password=1996;TrustServerCertificate=True";
        private void UrunEkle()
        {
            string urunAdi = txt_adi_ekle.Text;
            string urunAciklamasi = txt_ekleurunacikla.Text;
            int fiyat = Convert.ToInt32(txt_ekleurunfiyati.Text);


            int kategori = Convert.ToInt32(txt_ekleurunkategori.Text);

            int renk = Convert.ToInt32(txt_ekleurunrenk.Text);

          
            //string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;Encrypt=true;TrustServerCertificate=false;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("UrunEkle", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@urunAdi", urunAdi);
            command.Parameters.AddWithValue("@urunAciklamasi", urunAciklamasi);
            command.Parameters.AddWithValue("@fiyat", fiyat);
            command.Parameters.AddWithValue("@kategori", kategori);
            command.Parameters.AddWithValue("@renk", renk);

            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarıyla Güncellendi");
            connection.Close();

        }

        private void Guncelle()
        {

            int urunID = Convert.ToInt32(textBox1.Text);
            string urunAdi = textBox6.Text;
            string urunAciklamasi = textBox5.Text;
            int fiyat = Convert.ToInt32(textBox4.Text);


            int kategori = Convert.ToInt32(textBox2.Text);

            int renk = Convert.ToInt32(textBox3.Text);
           

           
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("UrunGuncelle", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@urunID", urunID);
            command.Parameters.AddWithValue("@urunAdi", urunAdi);
            command.Parameters.AddWithValue("@urunAciklamasi", urunAciklamasi);
            command.Parameters.AddWithValue("@fiyat", fiyat);
            command.Parameters.AddWithValue("@kategori", kategori);
            command.Parameters.AddWithValue("@renk", renk);

            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarıyla Güncellendi");
            connection.Close();
        }

        public void delete()
        {

            int urunID = Convert.ToInt32(textBox7.Text);

           
            //string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;Encrypt=true;TrustServerCertificate=false;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("UrunSil", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@urunKodu", urunID);

            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarıyla silindi");
            connection.Close();

        }

        public void urunListele()
        {
           
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("UrunListele", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            connection.Close();

            dataGridView1.DataSource = dataTable;
            this.Controls.Add(dataGridView1);
        }

        public void silinenurunListele()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("SilinenUrunListele", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            connection.Close();

            dataGridView1.DataSource = dataTable;
            this.Controls.Add(dataGridView1);
        }

        public void PDFKaydet()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.Title = "PDF Dosyaları";
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.Filter = "PDF Dosyası (*.pdf) | *.pdf|Tüm Dosyalar(*.*) | *.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.
                pdfTable.DefaultCell.Padding = 3; // hücre duvarı ve veri arasında mesafe
                pdfTable.WidthPercentage = 80; // hücre genişliği
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT; // yazı hizalaması
                pdfTable.DefaultCell.BorderWidth = 1; // kenarlık kalınlığı
                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.



                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); // hücre arka plan rengi
                    pdfTable.AddCell(cell);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        if (cell.Value != null)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                        else
                        {
                            pdfTable.AddCell(""); // Null değer ise boş hücre ekleyebilirsiniz.
                        }

                    }
                }

                using (FileStream stream = new FileStream(saveFileDialog.FileName + ".pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);// sayfa boyutu.
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("Veriler PDF Olarak kaydedilmiştir.");
            }
        }

        public void exportcsv()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.Title = "CSV Dosyaları";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.Filter = "CSV Dosyası (*.csv) | *.csv|Tüm Dosyalar(*.*) | *.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                {
                    // Sütun başlıklarını yaz
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        streamWriter.Write(column.HeaderText + ",");
                    }
                    streamWriter.WriteLine();

                    // Satırları yaz
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                streamWriter.Write(cell.Value.ToString() + ",");
                            }
                            else
                            {
                                streamWriter.Write(",");
                            }
                        }
                        streamWriter.WriteLine();
                    }

                    streamWriter.Close();
                }

                MessageBox.Show("Veriler CSV Olarak kaydedilmiştir.");
            }
        }

        private void VeriyiDataGridViewaEkle(string veri)
        {
            // Her satırı ayır
            string[] satirlar = veri.Split('\n');

            // Her satırı DataGridView'a ekle
            foreach (string satir in satirlar)
            {
                dataGridView1.Rows.Add(satir);
            }
        }

        private void VeritabaninaEkle(string[] veri)
        {
            // SQLite veritabanına ekleme sorgusu
           
            string sorgu = "INSERT INTO Urunler (UrunAdi, UrunAciklamasi, Fiyat, Stok,KategoriID,RenkID) VALUES (@UrunAdi, @UrunAciklamasi, @Fiyat, @Stok,@KategoriID,@RenkID)";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (SqlCommand komut = new SqlCommand(sorgu,connection))
            {
                // Parametreleri sorguya ekle
                komut.Parameters.AddWithValue("@UrunAdi", veri[0]);
                komut.Parameters.AddWithValue("@UrunAciklamasi", veri[1]);
                komut.Parameters.AddWithValue("@Fiyat", veri[2]);
                komut.Parameters.AddWithValue("@Stok", veri[3]);
                komut.Parameters.AddWithValue("@KategoriID", 1);
                komut.Parameters.AddWithValue("@RenkID", 1);


                // Sorguyu çalıştır
                komut.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrunEkle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            urunListele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            silinenurunListele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PDFKaydet();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            exportcsv();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Urun Adi", "UrunAdi");
            dataGridView1.Columns.Add("Urun Açıklaması", "UrunAciklamasi");
            dataGridView1.Columns.Add("Fiyat", "Fiyat");
            dataGridView1.Columns.Add("Stok", "Stok");
            dataGridView1.Columns.Add("Kategori ID", "KategoriID");
            dataGridView1.Columns.Add("Renk ID", "RenkID");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Seçilen dosyanın içeriğini oku
                    string dosyaYolu = openFileDialog.FileName;
                    string[] satirlar = System.IO.File.ReadAllLines(dosyaYolu);

                    // İlk satırı DataGridView sütun başlıklarına ekle
                    if (satirlar.Length > 0)
                    {
                        string[] basliklar = satirlar[0].Split(',');
                        for (int i = 0; i < basliklar.Length; i++)
                        {
                            dataGridView1.Columns[i].HeaderText = basliklar[i];
                        }
                    }

                    // Diğer satırları DataGridView'a ekle
                    for (int i = 1; i < satirlar.Length; i++)
                    {
                        string[] veri = satirlar[i].Split(',');
                        dataGridView1.Rows.Add(veri);

                        // Veriyi veritabanına ekle
                        VeritabaninaEkle(veri);
                    }

                    MessageBox.Show("Veri başarıyla alındı ve veritabanına eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri alma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            // Veriyi DataGridView'a ekleyen fonksiyon
            
        }

        private void adminUrunEkrani_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}