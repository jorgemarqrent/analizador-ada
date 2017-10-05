using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace analizadorLexico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        analizador obj = new analizador();
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                textBox2.Text = "";
                textBox1.Text = textBox1.Text.TrimEnd();
                obj.aSint(textBox1, textBox2);
                //obj.analiza(textBox1, textBox2);
            }
        }

       

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Adamantium (.ada)|*.ada";
            abrir.InitialDirectory = @"C:\Users\zune_\Desktop\PruebasLyA";
            if (abrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(abrir.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
