using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoProject
{
    class Vertex: IComparable<Vertex>
    {
        public int x, y;
        

        public int CompareTo(Vertex other)
        {
            if (x == other.x)
            {
                return y.CompareTo(other.y);
            }
            else
            {
                return x.CompareTo(other.x);
            }
        }

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Edge
    {
        public Vertex vert1;
        public Vertex vert2;

        public int v1;
        public int v2;

        public Edge(Vertex v1, Vertex v2)
        {
            this.vert1 = v1;
            this.vert2 = v2;
        }
        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Pen somePen;
        public Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 5; //радиус окружности вершины

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            darkGoldPen = new Pen(Color.DarkGoldenrod);
            darkGoldPen.Width = 2;

            somePen = new Pen(Color.IndianRed);
            somePen.Width = 2;
            fo = new Font("Arial", 8);
            br = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void drawVertexName(Vertex vertex)
        {
            string str = "(" + vertex.x.ToString() + ";" + vertex.y.ToString() + ")";
            point = new PointF(vertex.x, vertex.y );
            gr.DrawString(str, fo, br, point);
        }

        public void drawVertex(Vertex vertex, string number)
        {
            gr.FillEllipse(Brushes.Black, (vertex.x - R), (vertex.y - R), 2 * R, 2 * R);
            point = new PointF(vertex.x , vertex.y );
            gr.DrawString(number + " " + point.ToString(), fo, br, point);
        }

        public void drawVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.Black, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x , y );
            gr.DrawString(point.ToString(), fo, br, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
        {
            if (E.v1 == E.v2)
            {
                gr.DrawArc(darkGoldPen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R));
                gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
            }
            else
            {
                gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y);
                point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
                gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
                drawVertex(V2.x, V2.y, (E.v2 + 1).ToString());
            }
        }

        public void drawEdge(DelaunayTriangulator.Edge edge)
        {
            gr.DrawLine(somePen, edge.vert1.x, edge.vert1.y, edge.vert2.x, edge.vert2.y);
        }

        public void drawEdge(DelaunayTriangulator.Edge edge, Pen pen)
        {
            gr.DrawLine(pen, edge.vert1.x, edge.vert1.y, edge.vert2.x, edge.vert2.y);
        }

        public void drawTriangle(DelaunayTriangulator.Triangle tr)
        {
            gr.DrawLine(darkGoldPen, tr.M1.x, tr.M1.y, tr.M2.x, tr.M2.y);
            gr.DrawLine(darkGoldPen, tr.M2.x, tr.M2.y, tr.M3.x, tr.M3.y);
            gr.DrawLine(darkGoldPen, tr.M3.x, tr.M3.y, tr.M1.x, tr.M1.y);
           
        }

        public void drawVector(DelaunayTriangulator.Triangle tr)
        {
            Pen pen = new Pen(Color.Green);
            pen.Width = 3;
            pen.StartCap = LineCap.RoundAnchor;
            pen.EndCap = LineCap.ArrowAnchor;
            gr.DrawLine(pen, tr.M1.x, tr.M1.y, tr.M1.x + tr.M1.Vector.x, tr.M1.y + tr.M1.Vector.y);
            gr.DrawLine(pen, tr.M2.x, tr.M2.y, tr.M2.x + tr.M2.Vector.x, tr.M2.y + tr.M2.Vector.y);
            gr.DrawLine(pen, tr.M3.x, tr.M3.y, tr.M3.x + tr.M3.Vector.x, tr.M3.y + tr.M3.Vector.y);
        }

      

        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].v1 == E[i].v2)
                {
                    gr.DrawArc(darkGoldPen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[E[i].v1].x - (int)(2.75 * R), V[E[i].v1].y - (int)(2.75 * R));
                    gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                }
                else
                {
                    gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y);
                    point = new PointF((V[E[i].v1].x + V[E[i].v2].x) / 2, (V[E[i].v1].y + V[E[i].v2].y) / 2);
                    gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                }
            }
            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i], (i + 1).ToString());
            }
        }

        //заполняет матрицу смежности
        public void fillAdjacencyMatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < numberV; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, E[i].v2] = 1;
                matrix[E[i].v2, E[i].v1] = 1;
            }
        }

        public void BrushTriangle(DelaunayTriangulator.Triangle triangle)
        {
            PointF[] myPoints1 = { new PointF(triangle.M1.x, triangle.M1.y), new PointF(triangle.M2.x, triangle.M2.y), new PointF(triangle.M3.x, triangle.M3.y) };
            //PathGradientBrush pgradBrush = new PathGradientBrush(myPoints1); 
            int i = (int) Math.Truncate((1 - triangle.DensityOfTriangle) * 255);
            SolidBrush redBrush = new SolidBrush(Color.FromArgb(i, i, i));
                GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddPolygon(myPoints1);
            gr.FillPath(redBrush, graphPath);
        }
    }
}