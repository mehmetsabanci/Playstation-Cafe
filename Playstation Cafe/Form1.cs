using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playstation_Cafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string kullanici_adi = "admin4242";
        string sifre = "admin123456";
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == kullanici_adi && textBox2.Text== sifre) 
            {
                Form2 fr = new Form2();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ya da şifre hatalı!");
            }
        }
    }
}
