using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace RLE
{
    class Img8x8
    {
        public bool[,] data = new bool[8, 8];
        public Img8x8()
        {
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    data[i, j] = rand.Next(0, 100) > 50 ? true : false;
        }
        public int[,] DataInt()
        {
            int[,] result = new int[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    result[i, j] = data[i, j] ? 1 : 0;
            return result;
        }
        public void Draw(PictureBox pb)
        {
            Graphics graphics = pb.CreateGraphics();
            graphics.Clear(pb.BackColor);
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (data[i, j])
                    {
                        graphics.FillRectangle(
                            new SolidBrush(Color.Black),
                            new Rectangle(j * 8, i * 8, 8, 8));
                    }
        }
    }
}
