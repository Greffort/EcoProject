using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoProject;

namespace YakimovMaket
{
    static class  MathPro
    {
        public static double Fluctuation(double a, double b)
        {
            Random rand = new Random();
            return (a - b) + 2 * b * rand.NextDouble();
        }
        public static double CosBy2Points(Vertex V1, Vertex V2)
        {
            double Cos_a = (V1.y - V2.y) / Math.Sqrt(Math.Pow(V1.x - V2.x, 2) + Math.Pow(V1.y - V2.y, 2));

            return Cos_a;
        }
    }
}
