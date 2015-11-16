using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAD
{
    class AR
    {
        public int exponent;
        public float paramB;
        public float paramC;
        public float regression;

        public AR()
        {
            paramB = 0;
            paramC = 0;
            exponent = 0;
            regression = 0;
        }

        public float[] GetTrend(float[] inmassX,float[] inmassY)
        {
            float A1 = 0;
            float B1 = 0;
            float C1 = 0;
            float D1 = 0;
            if(inmassX.Length != inmassY.Length)
            {
                MessageBox.Show("Ошибка! Размеры множеств X и Y не совпадают.");
                return null;
            }
            for (int i = 0; i < inmassX.Length; i++)
            {
                A1 += inmassX[i];
                B1 += inmassY[i];
                C1 += inmassX[i] * inmassX[i];
                D1 += inmassX[i] * inmassY[i];
            }
            float determinant = inmassX.Length * C1 - A1 * A1;
            if(determinant != 0)
            {
                paramB = (B1 * C1 - A1 * D1) / determinant;
                paramC = (inmassX.Length * D1 - A1 * B1) / determinant;
            }
            else
            {
                MessageBox.Show("Определитель матрицы равен 0.");
                return null;
            }
            float[] result = new float[inmassX.Length];
            for (int i = 0; i < inmassX.Length; i++)
            {
                result[i] = paramC * inmassX[i] + paramB;
            }
            return result;
        }

        public float GetRegression(float[] inmassX, float[] inmassY)
        {
            float Sx,Sy,meanX,meanY;
            Sx = Sy = meanX = meanY = 0;
            if (inmassX.Length != inmassY.Length)
            {
                MessageBox.Show("Ошибка! Размеры множеств X и Y не совпадают.");
                return 0;
            }
            for (int i = 0; i < inmassX.Length; i++)
            {
                meanX += inmassX[i];
                meanY += inmassY[i];
            }
            meanX /= inmassX.Length;
            meanY /= inmassY.Length;
            for (int i = 0; i < inmassX.Length; i++)
            {
                Sx += (inmassX[i] - meanX) * (inmassX[i] - meanX);
                Sy += (inmassY[i] - meanY) * (inmassY[i] - meanY);
            }
            Sx /= inmassX.Length;
            Sy /= inmassY.Length;
            Sx = (float)Math.Sqrt(Sx);
            Sy = (float)Math.Sqrt(Sy);
            float tmp = 0;
            for (int i = 0; i < inmassX.Length; i++)
            {
                tmp += ((inmassX[i] - meanX) / Sx) * ((inmassY[i] - meanY) / Sy);
            }
            regression = tmp / (inmassX.Length - 1);
            return regression;
        }


        public float[] Forecast(float[] inmassX, float[] inmassY,int steps)
        {
            if (inmassX.Length != inmassY.Length)
            {
                MessageBox.Show("Ошибка! Размеры множеств X и Y не совпадают.");
                return null;
            }
            if (steps > 0)
            {
                float[] resultx = new float[inmassX.Length + steps];
                float[] resulty = new float[inmassY.Length + steps];
                
                for (int i = 0; i < inmassX.Length; i++)
                {
                    resultx[i] = inmassX[i];
                    resulty[i] = inmassY[i];
                }
                float step = 0;
                for (int i = 1; i < inmassX.Length; i++)
                    step += inmassX[i] - inmassX[i - 1];
                step /= inmassX.Length;
                for (int i = inmassX.Length; i < resultx.Length; i++)
                {
                    resultx[i] = resultx[i - 1] + step;
                }
                float coefA, coefB;
                coefA = paramC * (1 - regression);
                coefB = paramB * (1 - regression);
                for (int i = 0; i < steps; i++)
                {
                    if (i == 0)
                        resulty[inmassY.Length + i] = regression * inmassY[inmassY.Length - 1] + coefB + inmassX[inmassX.Length - 1] * coefA;
                    else
                        resulty[inmassY.Length + i] = regression * resulty[inmassY.Length + i] + coefB + resultx[inmassX.Length + i] * coefA;
                }
                return resulty;
            }
            return inmassY;
        }
    }
}
