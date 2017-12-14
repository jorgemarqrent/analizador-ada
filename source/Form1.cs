using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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
                if (obj.aSint(textBox1, textBox2)!=-1)
                {
                    //obj.analiza(textBox1, textBox2);

                   DialogResult r= MessageBox.Show("Desea ejecutar el programa?", "Ejecutar", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        
                        obj.declaraV();
                        obj.ejecuta(textBox2);
                    }

                }
            }
        }

       

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Adamantium (*.ada)|*.ada|Binario (*.oda)|*.oda";
            abrir.InitialDirectory = @"C:\Users\zune_\Desktop\PruebasLyA";
            if (abrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
               
                    System.IO.StreamReader sr = new
                       System.IO.StreamReader(abrir.FileName);
                    textBox1.Text = sr.ReadToEnd();
                    sr.Close();
              
                    string nombre = Path.GetFileNameWithoutExtension(abrir.FileName);
                    string dir = @"C:\Users\zune_\Desktop\PruebasLyA";
                    string serializationFile = Path.Combine(dir, nombre+".oda");
                    using (Stream stream = File.Open(serializationFile, FileMode.Open))
                    {
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                        obj.cuadruplos = (List<Cuadruplo>)bformatter.Deserialize(stream);
                        obj.tabla_avail = (List<TabSimbol>)bformatter.Deserialize(stream);
                        obj.tabla_constantes = (List<TabConst>)bformatter.Deserialize(stream);                       
                        obj.tabla_simbolos = (List<TabSimbol>)bformatter.Deserialize(stream);
                    }
                    DialogResult r = MessageBox.Show("Desea ejecutar el programa?", "Ejecutar", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        
                        obj.declaraV();
                        obj.ejecuta(textBox2);
                    }
                }
            }
        

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog guardar = new SaveFileDialog();

            guardar.Filter = "Adamantium(*.ada) | *.ada";
            guardar.RestoreDirectory = true;

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(guardar.OpenFile());

                for (int i = 0; i <textBox1.Lines.Length; i++)

                {

                    writer.WriteLine(textBox1.Lines[i].ToString());

                }

                writer.Dispose();

                writer.Close();
                string nombre = Path.GetFileNameWithoutExtension(guardar.FileName);
                string dir = @"C:\Users\zune_\Desktop\PruebasLyA";
                string serializationFile = Path.Combine(dir, nombre + ".oda");

                //serialize
                using (Stream stream = File.Open(serializationFile, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, obj.cuadruplos);
                    bformatter.Serialize(stream, obj.tabla_avail);
                    bformatter.Serialize(stream, obj.tabla_constantes);
                    bformatter.Serialize(stream, obj.tabla_simbolos);
                }
            }
           

        }
    }
}
