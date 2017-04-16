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
                                    triangles[i].edgemas[ik].brother = triangles[j].edgemas[jk];
                                    triangles[j].edgemas[jk].brother = triangles[i].edgemas[jk];
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


        public void AllDensities()
        {
            while (!this.СalculationOfDensities())
            {
                
            }
        }

        public bool СalculationOfDensities()
        {
            bool flag = true;
            bool isEverythingDone = true;
            float DensityAndVolumes = 0f;
            float Volumes = 0f;


            for (int i = 0; i < this.triangles.Count; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (triangles[i].edgemas[j].Volume > 0)
                    {
                        if (triangles[i].edgemas[j].Density < 0)
                        {
                            flag = false;
                            isEverythingDone = false;
                        }
                        else
                        {
                            DensityAndVolumes += triangles[i].edgemas[j].Volume * triangles[i].edgemas[j].Density;
                            Volumes += triangles[i].edgemas[j].Volume;
                        }
                    }
                }

                if (flag)
                {
                    if (triangles[i].V4 > 0) Volumes += triangles[i].V4;

                    triangles[i].DensityOfTriangle = DensityAndVolumes / Volumes;

                    foreach (DelaunayTriangulator.Edge item in triangles[i].edgemas)
                    {
                        if (item.Volume < 0)
                        {
                            item.Density = triangles[i].DensityOfTriangle;

                            if (item.brother != null)
                            {
                                item.brother.Density = item.Density;
                            }

                        }
                        else
                        {
                            if (item.Density == 0)
                            {
                                if (item.brother != null)
                                {
                                    item.Density = item.brother.Density;
                                }
                            }
                        }
                    }
                }

                flag = true;
                Volumes = 0f;
                DensityAndVolumes = 0f;
            }
            return isEverythingDone;
        }

    }
}
