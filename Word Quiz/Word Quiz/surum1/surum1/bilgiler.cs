using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace surum1
{
    class kelimeler
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\kelimebilgileri.mdb"); //access veri tabanı bağlantı yolu

        int i;  //sayaç
       
        DateTime kayittarihi, bugun = DateTime.Today;  //zaman değişkenleri
        TimeSpan gecenzaman;
        double toplamgun;

        public string[] ikelimeler = new string[1000]; 
        public string[] tkelimeler = new string[1000];
        public string[] türler = new string[1000];
        public int[] veritabani = new int[1000];

        public void kelimetopla()
        {
            i = 0;
            tablo0oku();   //tüm tablolar gerekli kontroller eşliğinde okunarak kelime dizisi toplanır.
            tablo1oku();
            tablo2oku();
            tablo3oku();
            tablo4oku();
        }


        private void tablo0oku()   
        {
            baglanti.Open(); 
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("select * From data");   //bilinmeyen kelimelerin bulunduğu tablo
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())  
            {
                ikelimeler[i] = (oku["ikelime"].ToString());
                türler[i] = (oku["tür"].ToString());
                tkelimeler[i] = (oku["tkelime"].ToString());
                veritabani[i] = 0;
                i++;
            }
            baglanti.Close();
        }

        private void tablo1oku()  
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("select * From data1");   //bir kez bilinen kelimelerin bulunduğu tablo
            OleDbDataReader oku = komut.ExecuteReader();
                  
            while (oku.Read())   
            {   //bu ve sonraki tablolarda zaman kontrolü yapılır, soruların tekrar sorulabilmesi için istenen zaman geçmelidir
                kayittarihi = Convert.ToDateTime(oku["tarih"]); 
                gecenzaman = bugun-kayittarihi;               
                toplamgun = gecenzaman.TotalDays;
                if (toplamgun >= 1)      //bu tablodaki soruların tekrar sorulması için 1 gün geçmelidir.
                {
                    ikelimeler[i] = (oku["ikelime"].ToString());
                    türler[i] = (oku["tür"].ToString());
                    tkelimeler[i] = (oku["tkelime"].ToString());
                    veritabani[i] = 1; i++;
                }
            }
            baglanti.Close();
        }

        private void tablo2oku()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("select * From data2"); //2 kez bilinen kelimelerin bulunduğu tablo
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())  
            {
                kayittarihi = Convert.ToDateTime(oku["tarih"]);
                gecenzaman = bugun - kayittarihi;
                toplamgun = gecenzaman.TotalDays;
                if (toplamgun >= 6)   //bu tablodaki soruların tekrar sorulması için 1+6=7 gün geçmelidir.
                {
                    ikelimeler[i] = (oku["ikelime"].ToString());
                    türler[i] = (oku["tür"].ToString());
                    tkelimeler[i] = (oku["tkelime"].ToString());
                    veritabani[i] = 2; i++;
                }
            }
            baglanti.Close();
        }

        private void tablo3oku()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("select * From data3");  //3 kez bilinen kelimelerin bulunduğu tablo
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                kayittarihi = Convert.ToDateTime(oku["tarih"]);
                gecenzaman = bugun-kayittarihi;
                toplamgun = gecenzaman.TotalDays;
                if (toplamgun >= 23)   //bu tablodaki soruların tekrar sorulması için 1+6+23=30 gün geçmelidir.
                {
                    ikelimeler[i] = (oku["ikelime"].ToString());
                    türler[i] = (oku["tür"].ToString());
                    tkelimeler[i] = (oku["tkelime"].ToString());
                    veritabani[i] = 3; i++;
                }
            }
            baglanti.Close();
        }

        private void tablo4oku()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("select * From data4");  //4 kez bilinen kelimelerin bulunduğu tablo
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                kayittarihi = Convert.ToDateTime(oku["tarih"]);
                gecenzaman = bugun-kayittarihi;
                toplamgun = gecenzaman.TotalDays;
                if (toplamgun >= 150)   //bu tablodaki soruların tekrar sorulması için 1+6+23+150=180 gün geçmelidir. 
                {
                    ikelimeler[i] = (oku["ikelime"].ToString());
                    türler[i] = (oku["tür"].ToString());
                    tkelimeler[i] = (oku["tkelime"].ToString());
                    veritabani[i] = 4; i++;
                }
            }
            baglanti.Close();          
        }



        public int sayaciogren()
            {
                return i;
            }


    }

}
