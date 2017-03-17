using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoProject
{
    class Triangle
    {
        List<Vertex> vert;
        List<Edge> edge;

        public Triangle(List<Vertex> vert, List<Edge> edge)
        {
            this.vert = vert;
            this.edge = edge;
        }

        public double GetValueEdge()
        {
            //a : Mi*Mj; b : Mj*Mk; c : Mk*Mi;
            double a = Math.Abs(Math.Sqrt(Math.Pow(vert[1].x - vert[0].x, 2) + Math.Pow(vert[1].y - vert[0].y, 2)));
            double b = Math.Abs(Math.Sqrt(Math.Pow(vert[2].x - vert[1].x, 2) + Math.Pow(vert[2].y - vert[1].y, 2)));
            double c = Math.Abs(Math.Sqrt(Math.Pow(vert[2].x - vert[0].x, 2) + Math.Pow(vert[2].y - vert[0].y, 2)));
            double abc = a * b * c;

            return abc;
        }

        public double GetSquare()
        {
            double Square = Math.Abs((((vert[2].x - vert[0].x) * (vert[1].y - vert[0].y)) - ((vert[2].y - vert[0].y) * (vert[1].x - vert[0].x))));
            return Square;
        }

        public double GetRadiusCircle()
        {
            double Radius = (GetValueEdge()) / (4 * GetSquare());
            return Radius;
        }

        //вычисление косинуса вроде, но это не точно, переименуй
        public double GetHERNYA(Vertex V1, Vertex V2)
        {
            double HERNYA = (V1.y - V2.y) / Math.Sqrt(Math.Pow(V1.x - V2.x, 2) + Math.Pow(V1.y - V2.y, 2));

            return HERNYA;
        }
    }
}
