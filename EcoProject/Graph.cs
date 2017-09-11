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
    }
}
