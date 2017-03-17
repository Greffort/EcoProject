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

        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            vert.Add(v1);
            vert.Add(v2);
            vert.Add(v3);
        }

        public double GetValueEdge()
        {
            double a = Math.Abs(Math.Sqrt(Math.Pow(vert[1].x - vert[0].x, 2) + Math.Pow(vert[1].y - vert[0].y, 2)));
            double b = Math.Abs(Math.Sqrt(Math.Pow(vert[2].x - vert[1].x, 2) + Math.Pow(vert[2].y - vert[1].y, 2)));
            double c = Math.Abs(Math.Sqrt(Math.Pow(vert[2].x - vert[0].x, 2) + Math.Pow(vert[2].y - vert[0].y, 2)));
            double abc = a * b * c;

            return abc;
        }

        public double GetRadiusCircle()
        {
            //a : Mi*Mj; b : Mj*Mk; c : Mk*Mi;
            

            double Square = Math.Abs((((vert[2].x - vert[0].x) * (vert[1].y - vert[0].y)) - ((vert[2].y - vert[0].y) * (vert[1].x - vert[0].x))));

            double Radius = (GetValueEdge()) / (4 * Square);

            return Radius;
            
        }

        //вычисление косинуса вроде, но это не точно, переименуй
    }
}
