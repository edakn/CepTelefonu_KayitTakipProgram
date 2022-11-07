
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb; 
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form2 frm2;
        public Form3 frm3;
        public OleDbConnection baq = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0; Data Source=vt1.mdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();
        public Form1()
        {
            InitializeComponent();
            frm2 = new Form2();
            frm3 = new Form3();
            frm2.frm1 = this;
            frm3.frm1 = this;
        }
        public void arizaara()
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From veri", baq);
            if (textBox1.Text == "")
            {
                kmt.Connection = baq;
                kmt.CommandText = "Select * from veri";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "veri");
            }
            if (Convert.ToBoolean(baq.State) == false)
            {
                baq.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From veri" +
                 " where(imei like '%" + textBox1.Text + "%' )";
            dtst.Clear();
            adtr.Fill(dtst, "veri");
            baq.Close();
        }

        public void arizaara2()
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From veri", baq);
            if (frm3.textBox8.Text == "")
            {
                kmt.Connection = baq;
                kmt.CommandText = "Select * from veri";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "veri");
            }
            if (Convert.ToBoolean(baq.State) == false)
            {
                baq.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From veri" +
                 " where(imei like '%" + frm3.textBox8.Text + "%' )";
            dtst.Clear();
            adtr.Fill(dtst, "veri");
            baq.Close();
        }

        public void arizalistele()
        {
            baq.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From veri", baq);
            adtr.Fill(dtst, "veri");
            dataGridView1.DataMember = "veri";
            dataGridView1.DataSource = dtst;
            adtr.Dispose();
            baq.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dtst.Clear();
            arizalistele(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arizaara();
            dataGridView1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
