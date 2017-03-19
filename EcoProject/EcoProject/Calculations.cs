using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EcoProject
{
    class Calculations
    {
        public void CalculatingVolumes(Triangle tr)
        {
            Vector a1 = new Vector();
            Vector a2 = new Vector();
            Vector a3 = new Vector();

            a1 = tr.V1 + tr.V2;
            a2 = tr.V2 + tr.V3;
            a3 = tr.V3 + tr.V1;

            Vector n1 = new Vector(tr.M1, tr.M2);
            Vector n2 = new Vector(tr.M2, tr.M3);
            Vector n3 = new Vector(tr.M3, tr.M1);

            //получаем нормальный вектор
            n1 = !n1;
            n2 = !n2;
            n3 = !n3;

            float V1 = new float();
            float V2 = new float();
            float V3 = new float();


            V1 = a1 * n1;
            if (n1 * new Vector(tr.M1, tr.M3) > 0) V1 = (-1) * V1;

            V2 = a2 * n2;
            if (n2 * new Vector(tr.M2, tr.M1) > 0) V2 = (-1) * V2;

            V3 = a3 * n3;
            if (n3 * new Vector(tr.M3, tr.M2 ) > 0) V3 = (-1) * V3;



        }

        private float Scalar ( Vector V1, Vector V2)
        {
            float scalar = V1.x * V2.x + V1.y * V2.y;
            return scalar;
        }
    }
}
