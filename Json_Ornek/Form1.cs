using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Json_Ornek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Kitap> kitaps=new List<Kitap>();
        JavaScriptSerializer tercuman=new JavaScriptSerializer();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kitap yeni=new Kitap();
            yeni.Baslik = textBox1.Text;
            yeni.Fiyat = numericUpDown1.Value;
            kitaps.Add(yeni);
            jsonyaz(kitaps);
        }

        private void jsonyaz(List<Kitap> kitaps)
        {
            string jason = tercuman.Serialize(kitaps);
            File.WriteAllText("../../kitaplar.jason",jason);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string oku = File.ReadAllText("../../kitaplar.jason");
            var liste = tercuman.Deserialize<List<Kitap>>(oku);
            listBox1.DisplayMember = "Baslik";
            foreach (Kitap kitap in liste)
            {
                listBox1.Items.Add(kitap);
            }
        }
    }
}
