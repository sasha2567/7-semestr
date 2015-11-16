using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAD
{
    public class MA
    {
        public float[] Solve(float[] inmassY, int q, int steps)
        {
            float[] result = new float[inmassY.Length + steps];
            for (int i = 0; i < inmassY.Length; i++)
            {
                result[i] = inmassY[i];
            }
            for (int i = inmassY.Length; i < inmassY.Length + steps; i++)
            {
                List<float> sum = new List<float>();
                for (int j = 0; j <= q; j++)
                {
                    sum.Add(result[i - j - 1]);
                }
                result[i] = sum.Average();
            }
            float[] res = new float[steps];
            for (int i = 0; i < steps; i++)
            {
                res[i] = result[i + inmassY.Length];
            }
            return res;
        }
    }
}
