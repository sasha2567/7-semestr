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
        public float coefA;
        public float coefB;
        public float coefC;

        private float[] determinant2x2(int n,float[] yt, float[] yt1)
        {
            float[] result = new float[2];
            float sumyt = 0;
            for (int i = 0; i < yt.Length;i++ )
            {
                sumyt += yt[i];
            }
            float sumyt1 = 0;
            for (int i = 0; i < yt1.Length; i++)
            {
                sumyt1 += yt1[i];
            }
            float sumy2t = 0;
            for (int i = 0; i < yt.Length; i++)
            {
                sumy2t += yt[i] * yt[i];
            }
            float sumytyt1 = 0;
            for (int i = 0; i < (yt.Length < yt1.Length ? yt.Length : yt1.Length); i++)
            {
                sumytyt1 += yt[i] * yt1[i];
            }
            float det0 = n * sumy2t - sumyt * sumyt1;
            float det1 = (sumyt * sumy2t - sumyt1 * sumytyt1) / det0;
            float det2 = (n * sumytyt1 - sumyt * sumyt) / det0;
            result[0] = det1;
            result[1] = det2;
            return result;
        }

        private float[] determinant3x3(int n, float[] yt, float[] yt1, float[] yt2)
        {
            float[] result = new float[3];
            float sumyt = 0;
            for (int i = 0; i < yt.Length; i++)
            {
                sumyt += yt[i];
            }
            float sumyt1 = 0;
            for (int i = 0; i < yt1.Length; i++)
            {
                sumyt1 += yt1[i];
            }
            float sumyt2 = 0;
            for (int i = 0; i < yt1.Length; i++)
            {
                sumyt2 += yt1[i];
            }
            float sumy2t1 = 0;
            for (int i = 0; i < yt.Length; i++)
            {
                sumy2t1 += yt1[i] * yt1[i];
            }
            float sumy2t2 = 0;
            for (int i = 0; i < yt.Length; i++)
            {
                sumy2t2 += yt2[i] * yt2[i];
            }
            float sumytyt1 = 0;
            for (int i = 0; i < (yt.Length < yt1.Length ? yt.Length : yt1.Length); i++)
            {
                sumytyt1 += yt[i] * yt1[i];
            }
            return result;
        }

        public List<PointF> Forecast(List<PointF> inmass, int steps, int exponent)
        {
            if (steps > 0)
            {
                List<PointF> result = new List<PointF>(steps + 1);
                result.Add(new PointF(inmass[inmass.Count - 1].X, inmass[inmass.Count - 1].Y));
                float step = 0;
                for (int i = 1; i < inmass.Count; i++)
                    step += inmass[i].X - inmass[i - 1].X;
                step /= inmass.Count - 1;
                if (exponent == 1)
                {
                    float[] y = new float[inmass.Count - 1];
                    float[] y1 = new float[inmass.Count - 1];
                    for(int i=1; i<inmass.Count - 1;i++)
                    {
                        y[i]=inmass[i].Y;
                        y1[i] = inmass[i-1].Y;
                    }
                    float[] res = determinant2x2(inmass.Count - 1,y,y1);
                    coefA = res[0];
                    coefB = res[1];
                    for (int i = 1; i <= steps; i++)
                    {
                        result.Add(new PointF(result[i - 1].X + step,
                            coefA + coefB * result[i - 1].Y));
                    }
                    return result;
                }
                if (exponent == 2)
                {
                    coefA = (
                        inmass[inmass.Count - 5].Y * inmass[inmass.Count - 2].Y * inmass[inmass.Count - 2].Y -
                        2 * inmass[inmass.Count - 2].Y * inmass[inmass.Count - 3].Y * inmass[inmass.Count - 4].Y +
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 3].Y * inmass[inmass.Count - 3].Y -
                        inmass[inmass.Count - 1].Y * inmass[inmass.Count - 5].Y * inmass[inmass.Count - 3].Y +
                        inmass[inmass.Count - 1].Y * inmass[inmass.Count - 4].Y * inmass[inmass.Count - 4].Y
                        ) /
                        (
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 3].Y -
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 4].Y -
                        inmass[inmass.Count - 5].Y * inmass[inmass.Count - 3].Y +
                        inmass[inmass.Count - 4].Y * inmass[inmass.Count - 4].Y -
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 4].Y +
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 5].Y
                        );
                    coefB = (
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 3].Y +
                        inmass[inmass.Count - 1].Y * inmass[inmass.Count - 4].Y -
                        inmass[inmass.Count - 1].Y * inmass[inmass.Count - 5].Y -
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 3].Y +
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 5].Y -
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 4].Y
                        ) /
                        (
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 3].Y -
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 4].Y -
                        inmass[inmass.Count - 5].Y * inmass[inmass.Count - 3].Y +
                        inmass[inmass.Count - 4].Y * inmass[inmass.Count - 4].Y -
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 4].Y +
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 5].Y
                        );
                    coefC = (
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 2].Y -
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 3].Y -
                        inmass[inmass.Count - 4].Y * inmass[inmass.Count - 2].Y +
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 3].Y -
                        inmass[inmass.Count - 1].Y * inmass[inmass.Count - 3].Y +
                        inmass[inmass.Count - 1].Y * inmass[inmass.Count - 4].Y
                        ) /
                        (
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 3].Y -
                        inmass[inmass.Count - 3].Y * inmass[inmass.Count - 4].Y -
                        inmass[inmass.Count - 5].Y * inmass[inmass.Count - 3].Y +
                        inmass[inmass.Count - 4].Y * inmass[inmass.Count - 4].Y -
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 4].Y +
                        inmass[inmass.Count - 2].Y * inmass[inmass.Count - 5].Y
                        );
                    result.Add(new PointF(inmass[inmass.Count - 1].X + step,
                        coefA + coefB * inmass[inmass.Count - 1].Y + coefC * inmass[inmass.Count - 2].Y));
                    for (int i = 2; i <= steps; i++)
                    {
                        result.Add(new PointF(result[i - 1].X + step,
                            coefA + coefB * result[i - 1].Y + coefC * result[i - 2].Y));
                    }
                    return result;
                }
            }
            return inmass;
        }

        public List<PointF> Model(List<PointF> inmass, int exponent)
        {
            List<PointF> result = new List<PointF>(inmass.Count);
            result.Add(new PointF(inmass[0].X, inmass[0].Y));
            if (exponent == 1)
            {
                for (int i = 1; i < inmass.Count; i++)
                {
                    result.Add(new PointF(inmass[i].X, coefA + coefB * inmass[i - 1].Y));
                }
                return result;
            }
            if (exponent == 2)
            {
                result.Add(new PointF(inmass[1].X, inmass[1].Y));
                for (int i = 2; i < inmass.Count; i++)
                {
                    result.Add(new PointF(inmass[i].X, coefA + coefB * inmass[i - 1].Y + coefC * inmass[i - 2].Y));
                }
                return result;
            }
            return inmass;
        }
    }
}
