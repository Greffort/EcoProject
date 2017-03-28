using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoProject
{
    class Triangle
    {
        public Vertex M1;
        public Vertex M2;
        public Vertex M3;

        public Edge E1;
        public Edge E2;
        public Edge E3;

        public Vector V1;
        public Vector V2;
        public Vector V3;
        
        public Triangle(Vertex M1, Vertex M2, Vertex M3)
        {
            this.M1 = M1;
            this.M2 = M2;
            this.M3 = M3;

            this.E1 = new Edge(M1, M2);
            this.E2 = new Edge(M2, M3);
            this.E3 = new Edge(M3, M1);
        }
 
        public Triangle(Vertex M1, Vertex M2, Vertex M3, Vector V1, Vector V2, Vector V3)
        {
            this.M1 = M1;
            this.M2 = M2;
            this.M3 = M3;

            this.E1 = new Edge(M1, M2);
            this.E2 = new Edge(M2, M3);
            this.E3 = new Edge(M3, M1);

            this.V1 = V1;
            this.V2 = V2;
            this.V3 = V3;

        }


        public double GetValueEdge()
        {
            double a = Math.Abs(Math.Sqrt(Math.Pow(M2.x - M1.x, 2) + Math.Pow(M2.y - M1.y, 2)));
            double b = Math.Abs(Math.Sqrt(Math.Pow(M3.x - M2.x, 2) + Math.Pow(M3.y - M2.y, 2)));
            double c = Math.Abs(Math.Sqrt(Math.Pow(M3.x - M1.x, 2) + Math.Pow(M3.y - M1.y, 2)));
            double abc = a * b * c;

            return abc;
        }

        public double GetRadiusCircle()
        {
            //a : Mi*Mj; b : Mj*Mk; c : Mk*Mi;
            double Square = Math.Abs((((M3.x - M1.x) * (M2.y - M1.y)) - ((M3.y - M1.y) * (M2.x - M1.x))) / 2);

            double Radius = (GetValueEdge()) / (4 * Square);

            return Radius;
            
        }
        public override string ToString()
        {
            return M1.num.ToString() + M2.num.ToString() + M3.num.ToString();
        }
    }
}
