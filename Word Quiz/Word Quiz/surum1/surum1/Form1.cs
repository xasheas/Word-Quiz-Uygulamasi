using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace surum1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\kelimebilgileri.mdb");

        private void Form1_Load(object sender, EventArgs e)
        {
            randomkayanyazi();
        }

        private void randomkayanyazi()
        {
            string[] kelimeler= new string[1000];
            string[] tkelimeler = new string[1000];
            string[] turler = new string[1000];

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("select * From datatotal");
            OleDbDataReader oku = komut.ExecuteReader();
            int i = 0;
            Random rndm = new Random();           //ekrana random sayi basmak istiyoruz
            while (oku.Read())
            {               
                kelimeler[i] = oku["ikelime"].ToString();
                tkelimeler[i] = oku["tkelime"].ToString();
                turler[i] = oku["tür"].ToString();
                i++;
            }
            baglanti.Close();

            for(int x=0;x<i;x++)
            {
                int a = rndm.Next(i);
                label1.Text += kelimeler[a] + "\n";
                label2.Text += tkelimeler[a] + "\n";
                label3.Text += turler[a] + "\n";
            } 
            
        }

        private void timer1_Tick(object sender, EventArgs e)  //ana ekranda labelları hareket ettirecek metodumuz
        {
            label1.Location = new Point(label1.Location.X, label1.Location.Y - 1);  //her birim zamanda labelları y ekseninde 1 birim yukarı taşıyoruz
            label2.Location = new Point(label2.Location.X, label2.Location.Y - 1);
            label3.Location = new Point(label3.Location.X, label3.Location.Y - 1);
        }


        private void addWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            addwordform b = new addwordform();
            b.Show();
        }

        private void dictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            dictionaryform b = new dictionaryform();
            b.Show();           
        }

        private void testingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            testingform b = new testingform();
            b.Show();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            statisticsform b = new statisticsform();
            b.Show();        
        }


        private void pictureBox3_Click(object sender, EventArgs e) // resimlere tıklandığında ilgili sayfalara gidilmesini sağlayan metodlar 
        {
            Form1.ActiveForm.Hide();
            testingform b = new testingform();
            b.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            dictionaryform b = new dictionaryform();
            b.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            addwordform b = new addwordform();
            b.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            statisticsform b = new statisticsform();
            b.Show();
        }
    }
}
