using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulator
{
 public   class Edge
    {
        public Vertex vert1;
        public Vertex vert2;
        public Edge brother;
        public bool isOuside = false;

        public float Volume { get; set; }
        public float Density { get; set; }

        public Edge(Vertex v1, Vertex v2)
        {
            this.vert1 = v1;
            this.vert2 = v2;
        }
        public override bool Equals(object obj)
        {
            Edge edgeObj = obj as Edge;

            bool trushka = false; 

            if (edgeObj == null)
                return false;
            if (this.vert1.Equals(edgeObj.vert1))
            {
                if (this.vert2.Equals(edgeObj.vert2))
                {
                    trushka = true;
                }
            }
            else
            {
                if (this.vert1.Equals(edgeObj.vert2))
                {
                    if (this.vert2.Equals(edgeObj.vert1))
                    {
                        trushka = true;
                    }

                }
            }

            return trushka;
               
        }





    }
}
