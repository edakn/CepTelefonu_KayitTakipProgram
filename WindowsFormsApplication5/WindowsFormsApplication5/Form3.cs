
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
    public partial class Form3 : Form
    {
        public Form1 frm1;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm1.frm2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            frm1.arizaara2();
            
            textBox1.DataBindings.Add("Text", frm1.dtst, "veri.imei");
            textBox2.DataBindings.Add("Text", frm1.dtst, "veri.model");
            textBox3.DataBindings.Add("Text", frm1.dtst, "veri.marka");
            textBox4.DataBindings.Add("Text", frm1.dtst, "veri.ulke");
            textBox5.DataBindings.Add("Text", frm1.dtst, "veri.tarih");
            textBox7.DataBindings.Add("Text", frm1.dtst, "veri.garanti");
            textBox6.Text = "ÇALINTI";
            button2.Enabled = true;
            button1.Enabled = false;
            
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
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Visible = true;

            }
            else
            {
                groupBox1.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frm1.baq.Open();
            frm1.kmt.Connection = frm1.baq;
            frm1.kmt.CommandText = "DELETE FROM veri WHERE imei='" + textBox1.Text + "'";
            frm1.kmt.ExecuteNonQuery();
            frm1.baq.Close();
            frm1.kmt.Dispose();
            frm1.dtst.Clear();
        }
    }
}
