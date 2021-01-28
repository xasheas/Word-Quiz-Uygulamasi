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
    public partial class addwordform : Form
    {
        public addwordform()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\kelimebilgileri.mdb");

        private void addwordform_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
              baglanti.Open();
            DateTime dt = DateTime.Today;
            
            OleDbCommand data = new OleDbCommand("insert into data(ikelime,tkelime,tür,tarih) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + dt + "')", baglanti);
            data.ExecuteNonQuery();         
            OleDbCommand datatotal = new OleDbCommand("insert into datatotal(ikelime,tkelime,tür,tarih) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + dt + "')", baglanti);
            datatotal.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show(" Kelime kaydedilmiştir.\n Kelime bilgileri; \n Sözcük : " +textBox1.Text+"\n Türü : "+textBox3.Text+"\n Çevirisi : "+textBox2.Text );
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addwordform.ActiveForm.Hide();
            Form1 b = new Form1();
            b.Show();
        }

        private void testingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addwordform.ActiveForm.Hide();
            testingform b = new testingform();
            b.Show();
        }

        private void dictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addwordform.ActiveForm.Hide();
            dictionaryform b = new dictionaryform();
            b.Show();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addwordform.ActiveForm.Hide();
            statisticsform b = new statisticsform();
            b.Show();
        }
    }
}
