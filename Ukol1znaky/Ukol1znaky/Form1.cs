using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ukol1znaky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char predotaznikem = ' ';
            int pozice = 0;
            listBox1.Items.Clear();
            FileStream data = new FileStream("znaky.dat",FileMode.Open,FileAccess.Read);
            BinaryReader precti = new BinaryReader(data,Encoding.GetEncoding("UTF-8"));

            precti.BaseStream.Position = 0;
            while(precti.BaseStream.Position < precti.BaseStream.Length)
            {
                char znak = precti.ReadChar();
                listBox1.Items.Add(znak);
                if(znak == '?')
                {
                    pozice = (int)precti.BaseStream.Position;
                    precti.BaseStream.Position -= 2;
                    predotaznikem = precti.ReadChar();
                    break;
                }
            }
            MessageBox.Show("otaznik je na pozici : " + pozice + "\nznak pred otaznikem je : " + predotaznikem);

            data.Close();
        }
    }
}
