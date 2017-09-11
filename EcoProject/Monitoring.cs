using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoProject
{
    class Monitoring
    {
       private List<Triangle> triangles;
        Dictionary<int, Triangle> multTriangle;


        public Monitoring()
        {
            triangles = new List<Triangle>();
        }

        public Monitoring(List<Triangle> tr)
        {
            triangles = tr;
        }

        public List<Triangle> DoCalculations()
        {
            GetArrayOfOutsideEdge();
            AllDensities();
            return triangles;
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
                                //if (i == 0 && ik == 2)
                                //{

                                //}
                                if (triangles[i].edgemas[ik].Equals(triangles[j].edgemas[jk]))
                                {
                                    
                                    unix = false;
                                    triangles[i].edgemas[ik].brother = triangles[j].edgemas[jk];
                                    triangles[j].edgemas[jk].brother = triangles[i].edgemas[ik];

                                }
                            }
                        }
                    }

                    if (unix)
                    {
                        triangles[i].edgemas[ik].Density = 1f;
                        triangles[i].edgemas[ik].isOutside = true;
                    }
                    
                }
            }
        }



        public void AllDensities()
        {
            bool end = false;
            int f = 0;
            while (!end)
            {
                СalculationOfDensities();
                end = true;

                for (int i = 0; i < triangles.Count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (triangles[i].edgemas[j].Density < 0) end = false;
                    }
                }

                Console.WriteLine(f++);
            }

            //СalculationOfDensities();
            //СalculationOfDensities();
            //СalculationOfDensities();
            //СalculationOfDensities();
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

                    foreach (Edge item in triangles[i].edgemas)
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
                            if (item.Density > 0)
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
