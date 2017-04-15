using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoProject
{
    class Graph
    {
        public List<DelaunayTriangulator.Vertex> verteex;
        public List<Vertex> vertex;
        public List<Edge> edges;
       

        public Graph()
        {
            this.verteex = new List<DelaunayTriangulator.Vertex>();
            this.vertex = new List<Vertex>();
            this.edges = new List<Edge>();
        }
        public Graph (List <Vertex> vertex)
        {
            this.vertex = vertex;
            for (int i = 0; i < vertex.Count; i++)
            {
                this.verteex[i].x = vertex[i].x;
                this.verteex[i].y = vertex[i].y;
            }
            this.edges = new List<Edge>();
        }
        
    }
}
