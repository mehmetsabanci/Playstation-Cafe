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


namespace Playstation_Cafe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=MEHMET\SQLEXPRESS;Initial Catalog=PlaystationCafe;Integrated Security=True;Encrypt=False");

        int saat01, saat02, saat03, saat04, saat05, saat06 = 0;
        int dakika01, dakika02, dakika03, dakika04, dakika05, dakika06 = 0;
        int saniye01, saniye02, saniye03, saniye04, saniye05, saniye06 = 0;
        double ucret1, ucret2, ucret3, ucret4, ucret5, ucret6 = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye01++;
            Lbl_Masa01.Text = saniye01.ToString();
            if (saniye01 == 60)
            {
                dakika01++;
                Lbl_Masa01_Dakika.Text = dakika01.ToString();
                saniye01 = 0;
                ucret1 += 1.00;
                label2.Text = ucret1.ToString() + "₺";
                if (dakika01 == 60)
                {
                    saat01++;
                    Lbl_Masa01_Saat.Text = saat01.ToString();
                    dakika01 = 0;



                }
            }
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Lbl_Cikolata_Fiyat.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Lbl_Dondurma_Fiyat.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Lbl_Hamburger_Kola_Fiyat.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Lbl_Lolipop_Fiyat.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Lbl_Su_Fiyat.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Lbl_Kahve_Fiyat.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Lbl_Soda_Fiyat.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Lbl_Cay_Fiyat.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            double toplam_fiyat = 0;
            for(int i= 0;i< listBox1.Items.Count; i++)
            {
                toplam_fiyat += Convert.ToDouble(listBox1.Items[i].ToString());
            }
            
            Lbl_Toplam_Fiyat.Text = toplam_fiyat.ToString() + "₺";
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Lbl_Toplam_Fiyat.Text = "0₺";
        }

        private void renklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void maviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.LightGray;
            tabPage4.BackColor = Color.White;

        }

        private void kırmızıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.LightGray;
            tabPage4.BackColor = Color.Red;
        }

        private void beyazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.LightGray;
            tabPage4.BackColor = Color.Yellow;
        }

        private void siyahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.LightGray;
            tabPage4.BackColor = Color.Blue;
        }

        private void siyahToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.LightGray;
            tabPage4.BackColor = Color.Black;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void renklerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/mehmetsbc/");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
        }
        void listele()
        {           
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblGamers",conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Btn_Kaydet_Click(object sender, EventArgs e)
        {
            
            timer7.Start();
            conn.Open();
            SqlCommand komutkaydet = new SqlCommand("insert into TblGamers (GamerAd,GamerSoyad,GamerYas,GamerTelefon,GamerUserName,GamerPassword) values(@p1,@p2,@p3,@p4,@p5,@p6)",conn);
            komutkaydet.Parameters.AddWithValue("@p1",Txt_Ad.Text);
            komutkaydet.Parameters.AddWithValue("@p2",Txt_Soyad.Text);
            komutkaydet.Parameters.AddWithValue("@p3",Cmb_Yas.Text);
            komutkaydet.Parameters.AddWithValue("@p4",Msk_Telefon.Text);
            komutkaydet.Parameters.AddWithValue("@p5",Txt_Kullanici_Ad.Text);
            komutkaydet.Parameters.AddWithValue("@p6",Txt_Sifre.Text);
            komutkaydet.ExecuteNonQuery();
            conn.Close();
            listele();
            
            

        }

        private void timer7_Tick(object sender, EventArgs e)
        {
          
            
                
                progressBar1.Value += 5;
                if (progressBar1.Value == 100)
                {
                    timer7.Stop();
                
                MessageBox.Show("Kayıt Tamamlandı!");
                progressBar1.Value = 0;
            }

            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txt_Ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            Txt_Soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            Cmb_Yas.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            Msk_Telefon.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            Txt_Kullanici_Ad.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            Txt_Sifre.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Lbl_Masa01_Saat.Text = 0.ToString();
            Lbl_Masa01_Dakika.Text = 0.ToString();
            Lbl_Masa01.Text = 0.ToString();
            MessageBox.Show(ucret1 + " ₺ " + "Masa ücreti alınmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label2.Text = "MASA-01";

        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            saniye02++;
            Lbl_Masa02.Text = saniye02.ToString();
            if (saniye02 == 60)
            {
                dakika02++;
                Lbl_Masa02_Dakika.Text = dakika02.ToString();
                saniye02 = 0;
                ucret2 += 1.00;
                label3.Text = ucret2.ToString() + "₺";
                if (dakika02 == 60)
                {
                    saat02++;
                    Lbl_Masa02_Saat.Text = saat02.ToString();
                    dakika02 = 0;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Lbl_Masa02_Saat.Text = 0.ToString();
            Lbl_Masa02_Dakika.Text = 0.ToString();
            Lbl_Masa02.Text = 0.ToString();
            MessageBox.Show(ucret2 + " ₺ " + "Masa ücreti alınmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label3.Text = "MASA-02";
        }

        private void Masa03_Baslat_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            saniye03++;
            Lbl_Masa03.Text = saniye03.ToString();
            if (saniye03 == 60)
            {
                dakika03++;
                Lbl_Masa03_Dakika.Text = dakika03.ToString();
                saniye03 = 0;
                ucret3 += 1.00;
                label5.Text = ucret3.ToString() + "₺";
                if (dakika03 == 60)
                {
                    saat03++;
                    Lbl_Masa03_Saat.Text = saat03.ToString();
                    dakika03 = 0;
                }
            }
        }
        private void Masa03_Durdur_Click(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        private void Masa03_Ödeme_Click(object sender, EventArgs e)
        {
            Lbl_Masa03_Saat.Text = 0.ToString();
            Lbl_Masa03_Dakika.Text = 0.ToString();
            Lbl_Masa03.Text = 0.ToString();
            MessageBox.Show(ucret3 + " ₺ " + "Masa ücreti alınmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label5.Text = "MASA-03";
        }
        private void Masa04_Baslat_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            saniye04++;
            Lbl_Masa04.Text = saniye04.ToString();
            if (saniye04 == 60)
            {
                dakika04++;
                Lbl_Masa04_Dakika.Text = dakika04.ToString();
                saniye04 = 0;
                ucret4 += 1.00;
                label7.Text = ucret4.ToString() + "₺";
                if (dakika04 == 60)
                {
                    saat04++;
                    Lbl_Masa04_Saat.Text = saat04.ToString();
                    dakika04 = 0;
                }
            }
        }
        private void Masa04_Durdur_Click(object sender, EventArgs e)
        {
            timer4.Stop();
        }
        private void Masa04_Ödeme_Click(object sender, EventArgs e)
        {
            Lbl_Masa04_Saat.Text = 0.ToString();
            Lbl_Masa04_Dakika.Text = 0.ToString();
            Lbl_Masa04.Text = 0.ToString();
            MessageBox.Show(ucret4 + " ₺ " + "Masa ücreti alınmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label7.Text = "MASA-04";
        }
        private void Masa05_Baslat_Click(object sender, EventArgs e)
        {
            timer5.Start();
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            saniye05++;
            Lbl_Masa05.Text = saniye05.ToString();
            if (saniye05 == 60)
            {
                dakika05++;
                Lbl_Masa05_Dakika.Text = dakika05.ToString();
                saniye05 = 0;
                ucret5 += 1.00;
                label9.Text = ucret5.ToString() + "₺";
                if (dakika05 == 60)
                {
                    saat05++;
                    Lbl_Masa05_Saat.Text = saat05.ToString();
                    dakika05 = 0;
                }
            }

        }
        private void Masa05_Durdur_Click(object sender, EventArgs e)
        {
            timer5.Stop();
        }
        private void Masa05_Ödeme_Click(object sender, EventArgs e)
        {
            Lbl_Masa05_Saat.Text = 0.ToString();
            Lbl_Masa05_Dakika.Text = 0.ToString();
            Lbl_Masa05.Text = 0.ToString();
            MessageBox.Show(ucret5 + " ₺ " + "Masa ücreti alınmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label9.Text = "MASA-05";
        }
        private void Masa06_Baslat_Click(object sender, EventArgs e)
        {
            timer6.Start();
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            saniye06++;
            Lbl_Masa06.Text = saniye06.ToString();
            if (saniye06 == 60)
            {
                dakika06++;
                Lbl_Masa06_Dakika.Text = dakika06.ToString();
                saniye06 = 0;
                ucret6 += 1.00;
                label11.Text = ucret6.ToString() + "₺";
                if (dakika06 == 60)
                {
                    saat06++;
                    Lbl_Masa06_Saat.Text = saat06.ToString();
                    dakika06 = 0;
                }

            }
        }
        private void Masa06_Durdur_Click(object sender, EventArgs e)
        {
            timer6.Stop();
        }
        private void Masa06_Ödeme_Click(object sender, EventArgs e)
        {
            Lbl_Masa06_Saat.Text = 0.ToString();
            Lbl_Masa06_Dakika.Text = 0.ToString();
            Lbl_Masa06.Text = 0.ToString();
            MessageBox.Show(ucret6 + " ₺ " + "Masa ücreti alınmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label11.Text = "MASA-06";
        }





    }
}

