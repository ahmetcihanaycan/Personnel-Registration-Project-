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
using System.Data.SqlClient;

namespace Personel_kAYİT
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NKAUUHC\\SQLEXPRESS;Initial Catalog=Personel_Veritabani;Integrated Security=True");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            // Toplam Personel Sayisi 
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select Count(*) From tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString();
            }
            
           baglanti.Close();
        
    
        // Evli Personel Sayisi
            baglanti.Open();
             SqlCommand komut2 = new SqlCommand("Select Count(*) from tbl_personel  where PerDurum = 1" , baglanti);
             SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read()) 
            {           
            lblevlipersonel.Text = dr2[0].ToString();
            }

            baglanti.Close();


        // Bekar Personel Sayisi

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) from tbl_personel where perdurum = 0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarpersonel.Text = dr3[0].ToString();
            }
            
            baglanti.Close();

           
        //Şehir Sayısı 

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(Persehir)) From tbl_personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehirsayısı.Text = dr4[0].ToString(); 

            }

            baglanti.Close();

        //Toplam Maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) From tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbltoplammaas.Text= dr5[0].ToString();

            }
            baglanti.Close();

            //Ortalama Maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) from tbl_personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortmaas.Text = dr6[0].ToString();
            }
            baglanti.Close();


        }
}
}
