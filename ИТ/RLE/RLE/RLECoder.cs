using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLE
{
    class RLECoder
    {
        public static string Encode(int[,] img)
        {
            string result = "";
            int mx = img.GetLength(0);
            int my = img.GetLength(1);
            for (int i = 0; i < my; i++)
            {
                for (int j = 0; j < mx; j++)
                {
                    result += '[';
                    int shift = CalcRepeat(img, i, j);
                    if (shift > 1)
                    {
                        string symbol = Convert.ToString(img[i, j], 2);
                        string repeat = Convert.ToString(shift, 2);
                        j += shift;
                        result += repeat + ':' + symbol;
                    }
                    else
                        result += Convert.ToString(img[i, j], 2);
                    result += "]\t";
                }
                result += '\n';
            }
            return result;
        }
        static int CalcRepeat(int[,] img, int y, int x)
        {
            int result = 0;
            for (int i = x; i < img.GetLength(1) - 1; i++)
                if (img[y, i] == img[y, i + 1])
                    result++;
                else 
                    return result;
            return result;
        }
    }
}
