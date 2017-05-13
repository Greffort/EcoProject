using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YakimovMaket;

namespace EcoProject
{
     class Triangulator
    {
        List<Triangle> triangles;
        Graph graph;

        Triangle tr;

        public Triangulator(Graph graph)
        {
            this.graph = graph;
        }
        public Edge FindFirstEdge()
        {
            double max = 0;
            int j = 0;
            graph.vertex.Sort();
            for (int i = 1; i < graph.vertex.Count; i++)
            {
                if (MathPro.CosBy2Points(graph.vertex[0], graph.vertex[i]) > max)
                {
                    max = MathPro.CosBy2Points(graph.vertex[0], graph.vertex[i]);
                    j = i;
                }
            }
            return new Edge(graph.vertex[0], graph.vertex[j]);
        }
        public Vertex FindSosed(Edge edge)
        {
            List<Vertex> vert = new List<Vertex>(graph.vertex);
            vert.Remove(edge.vert1);
            vert.Remove(edge.vert2);
            double min = double.MaxValue;
            int k = 0;
            for (int i = 0; i < vert.Count; i++)
            {
                Triangle triangle = new Triangle(edge.vert1, edge.vert2, vert[i]);
                double radius = triangle.GetRadiusCircle();
                if (radius < min)
                {
                    min = radius;
                    k = i;
                }
            }
            return vert[k];
        }
        public List<Triangle> triangulate()
        {
            List<Triangle> triangles = new List<Triangle>();
            List<Edge> ed = new List<Edge>();
            ed.Add(FindFirstEdge());
            try
            {
                for (int i = 0; i < ed.Count; i++)
                {
                        Vertex vert3 = FindSosed(ed[i]);
                        triangles.Add(new Triangle(ed[i].vert1, ed[i].vert2, vert3));
                        //ed.Add(new Edge(ed[i].vert2, vert3));
                }
            }
            catch { }
            return triangles;
        }
    }
}
