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
                    coefA = (inmass[inmass.Count - 1].Y - inmass[inmass.Count - 2].Y) /
                    (inmass[inmass.Count - 2].Y - inmass[inmass.Count - 3].Y);
                    coefB = (inmass[inmass.Count - 2].Y * inmass[inmass.Count - 2].Y - inmass[inmass.Count - 1].Y * inmass[inmass.Count - 3].Y) /
                        (inmass[inmass.Count - 2].Y - inmass[inmass.Count - 3].Y);
                    for (int i = 1; i <= steps; i++)
                    {
                        result.Add(new PointF(result[i - 1].X + step,
                            coefB + coefA * result[i - 1].Y));
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
                    result.Add(new PointF(inmass[i].X, coefB + coefA * inmass[i - 1].Y));
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
