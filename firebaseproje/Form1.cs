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
            BasePath = "https://firabaseproje-fc2a7-default-rtdb.firebaseio.com/",

        };

        IFirebaseClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
           dataGridView1 = new DataGridView();
            dataGridView1.BackgroundColor = Color.Red;


            try
            {
                client = new FireSharp.FirebaseClient(fc);
            }
            catch (Exception)
            {

                MessageBox.Show("veritabanına baglantı sorunu");
            }

        }
    }
}
