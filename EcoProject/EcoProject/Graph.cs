using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoProject
{
    class Graph
    {
        public List<Vertex> verts;
        public List<Edge> edges;
       

        public Graph()
        {
            this.verts = new List<Vertex>();
            this.edges = new List<Edge>();
        }
        //public Graph (List <Vertex> vertex)
        //{
        //    this.vertex = vertex;
        //    for (int i = 0; i < vertex.Count; i++)
        //    {
        //        this.verts[i].x = vertex[i].x;
        //        this.verts[i].y = vertex[i].y;
        //    }
        //    this.edges = new List<Edge>();
        //}
        
    }
}
