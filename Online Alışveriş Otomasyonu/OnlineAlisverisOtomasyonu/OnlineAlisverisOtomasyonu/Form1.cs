using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineAlisverisOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteri musteriGirisi = new Musteri();
            musteriGirisi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin adminGirisi = new admin();
            adminGirisi.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PersonelGiris personel = new PersonelGiris();
            personel.Show();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
