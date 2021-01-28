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
    public partial class dictionaryform : Form
    {
        public dictionaryform()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\kelimebilgileri.mdb");

  

        private void verilerigoruntule()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText=("select * From datatotal");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem(); 
                ekle.Text = oku["ikelime"].ToString();
                ekle.SubItems.Add(oku["tür"].ToString());
                ekle.SubItems.Add(oku["tkelime"].ToString());
                listView1.Items.Add(ekle);
            }
            
            baglanti.Close();
        }

        private void dictionaryform_Load(object sender, EventArgs e)
        {
            verilerigoruntule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("select * From datatotal where ikelime like '%" + textBox1.Text + "%' ");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ikelime"].ToString();
                ekle.SubItems.Add(oku["tür"].ToString());
                ekle.SubItems.Add(oku["tkelime"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("select * From datatotal where tkelime like '%" + textBox2.Text + "%' ");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ikelime"].ToString();
                ekle.SubItems.Add(oku["tür"].ToString());
                ekle.SubItems.Add(oku["tkelime"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dictionaryform.ActiveForm.Hide();
            Form1 b = new Form1();
            b.Show();
        }

        private void testingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dictionaryform.ActiveForm.Hide();
            testingform b = new testingform();
            b.Show();
        }

        private void addWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dictionaryform.ActiveForm.Hide();
            addwordform b = new addwordform();
            b.Show();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dictionaryform.ActiveForm.Hide();
            statisticsform b = new statisticsform();
            b.Show();
        }
    }
}
