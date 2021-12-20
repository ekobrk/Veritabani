using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Otopark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NpgsqlConnection con = new NpgsqlConnection("server= localHost;port=5432; Database=Kutuphane ; user ID= postgres; password=185658");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string sorgu2 = "select * from kitap";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView1.DataSource = ds2.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into kitap(kitap_adi, sayfa_sayisi, türü, basim_yili , yayim_yili , isbn, stok , raf_no, dil, yazari) values (@p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", con);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
            komut.Parameters.AddWithValue("@p5", int.Parse(textBox5.Text));
            komut.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));
            komut.Parameters.AddWithValue("@p7", int.Parse(textBox7.Text));
            komut.Parameters.AddWithValue("@p8", int.Parse(textBox8.Text));
            komut.Parameters.AddWithValue("@p9", textBox9.Text);
            komut.Parameters.AddWithValue("@p10", textBox10.Text);
            komut.ExecuteNonQuery();
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

            MessageBox.Show("Başarıyla eklendi..");
            string sorgu2 = "select * from kitap";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView1.DataSource = ds2.Tables[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            string sorgu3 = "Select * From kitap where kitap_id='" + textBox12.Text + "'";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView1.DataSource = ds3.Tables[0];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From kitap where kitap_id =@p1", con);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox11.Text));
            komut2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("kitap silindi..");
            string sorgu = "select * from kitap";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            textBox11.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            NpgsqlCommand komut = new NpgsqlCommand("Update kitap set sayfa_sayisi = @p2, türü = @p3, basim_yili = @p4 , yayim_yili = @p5 , isbn = @p6, stok = @p7 , raf_no = @p8, dil = @p9, yazari = @p10 where kitap_adi = @p1", con);


            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
            komut.Parameters.AddWithValue("@p5", int.Parse(textBox5.Text));
            komut.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));
            komut.Parameters.AddWithValue("@p7", int.Parse(textBox7.Text));
            komut.Parameters.AddWithValue("@p8", int.Parse(textBox8.Text));
            komut.Parameters.AddWithValue("@p9", textBox9.Text);
            komut.Parameters.AddWithValue("@p10", textBox10.Text);
            komut.ExecuteNonQuery();
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

            MessageBox.Show("kitap güncellendi..");
            string sorgu = "select * from kitap";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
