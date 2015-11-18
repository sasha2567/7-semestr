using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
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
        public float coefA;
        public float coefB;

        public AR()
        {
            paramB = 0;
            paramC = 0;
            exponent = 0;
            regression = 0;
        }

        public List<PointF> GetTrend(List<PointF> inmass)
        {
            float A1 = 0;
            float B1 = 0;
            float C1 = 0;
            float D1 = 0;
            for (int i = 0; i < inmass.Count; i++)
            {
                A1 += inmass[i].X;
                B1 += inmass[i].Y;
                C1 += inmass[i].X * inmass[i].X;
                D1 += inmass[i].X * inmass[i].Y;
            }
            float determinant = inmass.Count * C1 - A1 * A1;
            if(determinant != 0)
            {
                paramB = (B1 * C1 - A1 * D1) / determinant;
                paramC = (inmass.Count * D1 - A1 * B1) / determinant;
            }
            else
            {
                MessageBox.Show("Определитель матрицы равен 0.");
                return null;
            }
            List<PointF> result = new List<PointF>();
            for (int i = 0; i < inmass.Count; i++)
            {
                result.Add(new PointF(inmass[i].X, paramC * inmass[i].X + paramB));
            }
            return result;
        }

        public float GetRegression(List<PointF> inmass)
        {
            float Sx,Sy,meanX,meanY;
            Sx = Sy = meanX = meanY = 0;
            for (int i = 0; i < inmass.Count; i++)
            {
                meanX += inmass[i].X;
                meanY += inmass[i].Y;
            }
            meanX /= inmass.Count;
            meanY /= inmass.Count;
            for (int i = 0; i < inmass.Count; i++)
            {
                Sx += (inmass[i].X - meanX) * (inmass[i].X - meanX);
                Sy += (inmass[i].Y - meanY) * (inmass[i].Y - meanY);
            }
            Sx /= inmass.Count;
            Sy /= inmass.Count;
            Sx = (float)Math.Sqrt(Sx);
            Sy = (float)Math.Sqrt(Sy);
            float tmp = 0;
            for (int i = 0; i < inmass.Count; i++)
            {
                tmp += ((inmass[i].X - meanX) / Sx) * ((inmass[i].Y - meanY) / Sy);
            }
            regression = tmp / (inmass.Count - 1);
            return regression;
        }


        public List<PointF> Forecast(List<PointF> inmass, int steps)
        {
            if (steps > 0)
            {
                List<PointF> result = new List<PointF>(steps + 1);
                result.Add(new PointF(inmass[inmass.Count - 1].X, inmass[inmass.Count - 1].Y));
                float step = 0;
                for (int i = 1; i < inmass.Count; i++)
                    step += inmass[i].X - inmass[i - 1].X;
                step /= inmass.Count - 1;
                coefA = (inmass[inmass.Count - 2].Y - inmass[inmass.Count - 1].Y) / 
                    (inmass[inmass.Count - 3].Y - inmass[inmass.Count - 2].Y);
                coefB = inmass[inmass.Count - 1].Y - coefA * inmass[inmass.Count - 2].Y;
                for (int i = 1; i <= steps; i++)
                {
                        result.Add(new PointF(result[i - 1].X + step,
                            coefB + coefA * result[i - 1].Y));
                }
                return result;
            }
            return inmass;
        }
    }
}
