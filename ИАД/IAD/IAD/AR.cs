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
        public float coefA;
        public float coefB;

        public AR()
        {
            exponent = 0;
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

        public List<PointF> Model(List<PointF> inmass)
        {
            List<PointF> result = new List<PointF>(inmass.Count);
            for (int i = 1; i < inmass.Count; i++)
            {
                result.Add(new PointF(inmass[i - 1].X, coefB + coefA * inmass[i - 1].Y));
            }
            result.Add(new PointF(inmass[inmass.Count - 1].X, coefB + coefA * inmass[inmass.Count - 1].Y));
            return result;
        }
    }
}
