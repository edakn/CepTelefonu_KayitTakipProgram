
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm1.frm3.Show();
            this.Hide();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

           int islem;
           string a; 
           a = string.Format(" {0:yyyy}",DateTime.Now); 

          
           if (int.Parse(textBox5.Text) > int.Parse(a))
           {
               MessageBox.Show("Lütfen Üretim Tarihini Doğru Giriniz");
           }
           else 
           {
               islem = int.Parse(a) - int.Parse(textBox5.Text); 
               if (islem <= 2) 
               {
                   textBox7.Text = "GARANTİLİ";
               }
               else 
               {
                   textBox7.Text = "GARANTİ DIŞI";
               }
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1.baq.Open();
            frm1.kmt.Connection = frm1.baq;
            frm1.kmt.CommandText = "INSERT INTO veri(imei,model,marka,ulke,tarih,garanti,durum) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox6.Text + "')";
            frm1.kmt.ExecuteNonQuery();
            frm1.kmt.Dispose();
            frm1.baq.Close();
            frm1.dtst.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm1.baq.Open();
            frm1.kmt.Connection = frm1.baq;
            frm1.kmt.CommandText = "UPDATE veri SET model='" + textBox2.Text + "',marka='" + textBox3.Text + "',ulke='" + textBox4.Text + "',tarih='" + textBox5.Text + "',durum='" + textBox6.Text + "',garanti='" + textBox7.Text + "' WHERE imei='" + textBox1.Text + "'";
            frm1.kmt.ExecuteNonQuery();
            frm1.baq.Close();
            frm1.kmt.Dispose();
            frm1.dtst.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm1.baq.Open();
            frm1.kmt.Connection = frm1.baq;
            frm1.kmt.CommandText = "DELETE FROM veri WHERE imei='" + textBox1.Text + "'";
            frm1.kmt.ExecuteNonQuery();
            frm1.baq.Close();
            frm1.kmt.Dispose();
            frm1.dtst.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
