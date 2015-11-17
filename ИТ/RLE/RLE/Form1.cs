using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLE
{
    public partial class Form1 : Form
    {
        Img8x8 img;
        public Form1()
        {
            InitializeComponent();
            img = new Img8x8();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            img = new Img8x8();
            Work();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Work();
        }
        void Work()
        {
            img.Draw(pictureBox1);
            richTextBox1.Text = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    richTextBox1.Text += "[" + img.DataInt()[i, j] + "]";
                richTextBox1.Text += "\n";
            }
            String encode = RLECoder.Encode(img.DataInt());
            richTextBox2.Text = encode;
        }
    }
}
