using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoProject
{
    class Graph
    {
        public List<Vertex> vertex;
        public List<Edge> edges;
        public DrawGraph draw;

        public Graph()
        {
            this.vertex = new List<Vertex>();
            this.edges = new List<Edge>();
        }
        public Graph (List <Vertex> vertex)
        {
            this.vertex = vertex;
            this.edges = new List<Edge>();
        }
        
        //public string GetVertexName()
        //{
        //    if (vertex.Count == 0)
        //        return "1";
        //    else
        //    {
        //        int i = 1;
        //        vertex.Sort();vertex.Find()
        //        foreach (Vertex vert in vertex)
        //        {
        //            while (vert )
        //        }
        //    }
        //}
    }
}
