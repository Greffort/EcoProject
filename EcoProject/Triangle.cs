﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using EcoProject;


namespace EcoProject
{
    public class Triangle
    {


        public int a, b, c;
        public int ab, bc, ac;  // adjacent edges index to neighbouring triangle.

        public Vertex M1;
        public Vertex M2;
        public Vertex M3;

        public Vertex[] vertexmas;

        public Edge E1;
        public Edge E2;
        public Edge E3;


        public float V4;
        public float DensityOfTriangle = new float();
        public Edge[] edgemas;



        // Position and radius squared of circumcircle Положение и радиус квадрата окружности
        public float circumcircleR2, circumcircleX, circumcircleY;

        public Triangle(int x, int y, int z)
        {
            a = x; b = y; c = z; ab = -1; bc = -1; ac = -1;
            circumcircleR2 = -1; //x = 0; y = 0;
        }

        public void Initialize(int a, int b, int c, int ab, int bc, int ac, List<Vertex> points)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.ab = ab;
            this.bc = bc;
            this.ac = ac;

            FindCircumcirclePrecisely(points);
        }

        /// <summary>
        /// If current orientation is not clockwise, swap b<->c
        /// Если текущая ориентация не по часовой стрелке, замените b <-> c
        /// </summary>
        public void MakeClockwise(List<Vertex> points)
        {
            float centroidX = (points[a].x + points[b].x + points[c].x) / 3.0f;
            float centroidY = (points[a].y + points[b].y + points[c].y) / 3.0f;

            float dr0 = points[a].x - centroidX, dc0 = points[a].y - centroidY;
            float dx01 = points[b].x - points[a].x, dy01 = points[b].y - points[a].y;

            float df = -dx01 * dc0 + dy01 * dr0;
            if (df > 0)
            {
                // Need to swap vertices b<->c and edges ab<->bc
                int t = b;
                b = c;
                c = t;

                t = ab;
                ab = ac;
                ac = t;
            }
        }

        /// <summary>
        /// Find location and radius ^2 of the circumcircle (through all 3 points)
        /// This is the most critical routine in the entire set of code.  It must
        /// be numerically stable when the points are nearly collinear.
        /// Найдите местоположение и радиус ^ 2 окружности (через все 3 точки)
        /// Это самая критическая процедура во всем наборе кода. Это должно
        /// быть численно устойчивым, когда точки почти коллинеарны.
        /// </summary>
        public bool FindCircumcirclePrecisely(List<Vertex> points)
        {
            // Use coordinates relative to point `a' of the triangle
            Vertex pa = points[a], pb = points[b], pc = points[c];

            double xba = pb.x - pa.x;
            double yba = pb.y - pa.y;
            double xca = pc.x - pa.x;
            double yca = pc.y - pa.y;

            this.M1 = points[a];
            this.M2 = points[b];
            this.M3 = points[c];

            this.E1 = new Edge(M1, M2);
            this.E2 = new Edge(M2, M3);
            this.E3 = new Edge(M3, M1);



            this.vertexmas = new Vertex[3];
            this.edgemas = new Edge[3];

            vertexmas[0] = this.M1;
            vertexmas[1] = this.M2;
            vertexmas[2] = this.M3;

            edgemas[0] = this.E1;
            edgemas[1] = this.E2;
            edgemas[2] = this.E3;






            // Squares of lengths of the edges incident to `a'
            double balength = xba * xba + yba * yba;
            double calength = xca * xca + yca * yca;

            // Calculate the denominator of the formulae. 
            double D = xba * yca - yba * xca;
            if (D == 0)
            {
                circumcircleX = 0;
                circumcircleY = 0;
                circumcircleR2 = -1;
                return false;
            }

            double denominator = 0.5 / D;

            // Calculate offset (from pa) of circumcenter
            double xC = (yca * balength - yba * calength) * denominator;
            double yC = (xba * calength - xca * balength) * denominator;

            double radius2 = xC * xC + yC * yC;
            if ((radius2 > 1e10 * balength || radius2 > 1e10 * calength))
            {
                circumcircleX = 0;
                circumcircleY = 0;
                circumcircleR2 = -1;
                return false;
            }

            circumcircleR2 = (float)radius2;
            circumcircleX = (float)(pa.x + xC);
            circumcircleY = (float)(pa.y + yC);

            return true;
        }

        /// <summary>
        /// Return true iff Vertex p is inside the circumcircle of this triangle
        /// Возвращает true, если вершина p находится внутри окружности этого треугольника
        /// </summary>
        public bool InsideCircumcircle(Vertex p)
        {
            float dx = circumcircleX - p.x;
            float dy = circumcircleY - p.y;
            float r2 = dx * dx + dy * dy;
            return r2 < circumcircleR2;
        }

        /// <summary>
        /// Change any adjacent triangle index that matches fromIndex, to toIndex
        /// Измените любой соседний индекс треугольника, который соответствует fromIndex, toIndex
        /// </summary>
        public void ChangeAdjacentIndex(int fromIndex, int toIndex)
        {
            if (ab == fromIndex)
                ab = toIndex;
            else if (bc == fromIndex)
                bc = toIndex;
            else if (ac == fromIndex)
                ac = toIndex;
            else
                Debug.Assert(false);
        }

        /// <summary>
        /// Determine which edge matches the triangleIndex, then which vertex the vertexIndex
        /// Set the indices of the opposite vertex, left and right edges accordingly
        /// Определите, какая грань соответствует треугольникуIndex, затем какая вершина vertexIndex
        /// Установить индексы противоположной вершины, соответственно левого и правого краев
        /// </summary>
        public void FindAdjacency(int vertexIndex, int triangleIndex, out int indexOpposite, out int indexLeft, out int indexRight)
        {
            if (ab == triangleIndex)
            {
                indexOpposite = c;

                if (vertexIndex == a)
                {
                    indexLeft = ac;
                    indexRight = bc;
                }
                else
                {
                    indexLeft = bc;
                    indexRight = ac;
                }
            }
            else if (ac == triangleIndex)
            {
                indexOpposite = b;

                if (vertexIndex == a)
                {
                    indexLeft = ab;
                    indexRight = bc;
                }
                else
                {
                    indexLeft = bc;
                    indexRight = ab;
                }
            }
            else if (bc == triangleIndex)
            {
                indexOpposite = a;

                if (vertexIndex == b)
                {
                    indexLeft = ab;
                    indexRight = ac;
                }
                else
                {
                    indexLeft = ac;
                    indexRight = ab;
                }
            }
            else
            {
                Debug.Assert(false);
                indexOpposite = indexLeft = indexRight = 0;
            }
        }

        public override string ToString()
        {
            string s = "Вершины: \n";
            s += "E[0]: (" + this.edgemas[0].V1.x + "; " + this.edgemas[0].V1.y + ")   " + "(" + this.edgemas[0].V2.x + "; " + this.edgemas[0].V2.y + ") Плотность: "+ this.edgemas[0].Density + " Объём: " + this.edgemas[0].Volume + "\n";
            s += "E[1]: (" + this.edgemas[1].V1.x + "; " + this.edgemas[1].V1.y + ")   " + "(" + this.edgemas[1].V2.x + "; " + this.edgemas[1].V2.y + ") Плотность: " + this.edgemas[1].Density + " Объём: " + this.edgemas[1].Volume + "\n";
            s += "E[2]: (" + this.edgemas[2].V1.x + "; " + this.edgemas[2].V1.y + ")   " + "(" + this.edgemas[2].V2.x + "; " + this.edgemas[2].V2.y + ") Плотность: " + this.edgemas[2].Density + " Объём: " + this.edgemas[2].Volume + "\n";
            s += "Плотность треугольника: "+this.DensityOfTriangle+ "\n";
            return s;
        }
    }
}
