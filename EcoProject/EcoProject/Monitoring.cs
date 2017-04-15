using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelaunayTriangulator;

namespace EcoProject
{
    class Monitoring
    {
       public List<Triangle> triangles;
        Dictionary<int, Triangle> multTriangle;


        public Monitoring()
        {
            triangles = new List<Triangle>();
        }

        public Monitoring(List<Triangle> tr)
        {
            this.triangles = new List<Triangle>();
            foreach (Triangle t in tr)
            {
                this.triangles.Add(t);
            }
        }

        public void AddTriangle()
        {

        }

        public void GetArrayOfOutsideEdge()
        {
            bool unix = true;
            for (int i = 0; i < triangles.Count; i++)
            {
                for (int ik=0; ik<3; ik++)
                {
                    unix = true;
                    
                    for (int j = 0; j < triangles.Count; j++)
                    {
                        if (i != j)
                        {
                            for (int jk = 0; jk < 3; jk++)
                            {
                                if (triangles[i].edgemas[ik].Equals(triangles[j].edgemas[jk]))
                                {
                                    unix = false;
                                }
                            }
                        }
                    }

                    if (unix)
                    {
                        triangles[i].edgemas[ik].Density = 1f;
                    }
                    
                }
            }
        }



        public void СalculationOfAllDensities()
        {
            for (int i = 0; i < this.triangles.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (triangles[i].edgemas[j].Density != 0 && triangles[i].edgemas[j].Volume > 0)
                    {
                        
                    }
                }
            }
        }

    }
}
