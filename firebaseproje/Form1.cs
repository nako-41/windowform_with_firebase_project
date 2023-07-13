using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Newtonsoft.Json;

namespace firebaseproje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IFirebaseConfig fc = new FirebaseConfig()
        {
            AuthSecret = "8PFEUbS17CGHRqV6hkfMsHi8VPonQVBywTXgdtjy",
            BasePath = "https://firabaseproje-fc2a7-default-rtdb.firebaseio.com/"

        };

        IFirebaseClient client;

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                client = new FireSharp.FirebaseClient(fc);
            }
            catch (Exception)
            {

                MessageBox.Show("veritabanına baglantı sorunu");
            }

        }
        Iller ils = new Iller();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                ils.plakakodu = textBox2.Text;
                ils.iladi = textBox1.Text.ToLower();

                client.Set("illertbl/" + textBox2.Text, ils);
                MessageBox.Show("bilgiler eklendi");
            }
            else
            {
                MessageBox.Show("lutfen alanlari doldurunuz");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            client.Delete("illertbl/" + textBox2.Text);
            MessageBox.Show("bilgiler silindi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ils.plakakodu = textBox2.Text;
            ils.iladi = textBox1.Text;

            var update = client.Update("illertbl/" + textBox1.Text, ils);

            MessageBox.Show("bilgiler guncellendi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("plakakodu", "plaka_kodu");
            dataGridView1.Columns.Add("iller", "iladi");




            FirebaseResponse all = client.Get(@"illertbl");
            Dictionary<string, Iller> veri = JsonConvert.DeserializeObject<Dictionary<string, Iller>>(all.Body.ToString());

            foreach (var item in veri)
            {
                dataGridView1.Rows.Add(item.Value.iladi , item.Value.plakakodu);
            }


        }
    }
}
