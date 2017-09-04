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
    //class Vertex: IComparable<Vertex>
    //{
    //    public int x, y;
        

    //    public int CompareTo(Vertex other)
    //    {
    //        if (x == other.x)
    //        {
    //            return y.CompareTo(other.y);
    //        }
    //        else
    //        {
    //            return x.CompareTo(other.x);
    //        }
    //    }

    //    public Vertex(int x, int y)
    //    {
    //        this.x = x;
    //        this.y = y;
    //    }
    //}

    //class Edge
    //{
    //    public Vertex vert1;
    //    public Vertex vert2;

    //    public int v1;
    //    public int v2;

    //    public Edge(Vertex v1, Vertex v2)
    //    {
    //        this.vert1 = v1;
    //        this.vert2 = v2;
    //    }
    //    public Edge(int v1, int v2)
    //    {
    //        this.v1 = v1;
    //        this.v2 = v2;
    //    }
    //}

     class  Drawing
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
        public int R = 3; //радиус окружности вершины

        public Drawing(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 1;
            redPen = new Pen(Color.Red);
            redPen.Width = 1;
            darkGoldPen = new Pen(Color.DarkGoldenrod);
            darkGoldPen.Width = 1;

            somePen = new Pen(Color.IndianRed);
            somePen.Width = 1;
            fo = new Font("Segoe UI Light", 6);
            br = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            // gr.Clear(Color.AliceBlue);
            gr.Clear(Color.FromArgb(0,0,0,0));
        }

        public void drawVertexName(Vertex vertex, Font font, Brush brush, PointF point)
        {
            string str = "(" + vertex.x.ToString() + ";" + vertex.y.ToString() + ")";
            point = new PointF(vertex.x, vertex.y );
            gr.DrawString(str, font, brush, point);
        }

        public void drawVertex(Vertex vertex, string number)
        {
            gr.FillEllipse(Brushes.Black, (vertex.x - R), (vertex.y - R), 2 * R, 2 * R);
            point = new PointF(vertex.x , vertex.y );
            gr.DrawString(number + " " + point.ToString(), fo, br, point);
        }

        public void drawEdge(Edge edge)
        {
            gr.DrawLine(somePen, edge.V1.x, edge.V1.y, edge.V2.x, edge.V2.y);
        }

        public void drawEdge(Edge edge, Pen pen)
        {
            gr.DrawLine(pen, edge.V1.x, edge.V1.y, edge.V2.x, edge.V2.y);
        }

        public void drawTriangle(Triangle tr)
        {
            gr.DrawLine(darkGoldPen, tr.M1.x, tr.M1.y, tr.M2.x, tr.M2.y);
            gr.DrawLine(darkGoldPen, tr.M2.x, tr.M2.y, tr.M3.x, tr.M3.y);
            gr.DrawLine(darkGoldPen, tr.M3.x, tr.M3.y, tr.M1.x, tr.M1.y);
           
        }

        public void drawVector(Triangle tr)
        {
            Pen pen = new Pen(Color.Aqua);
            pen.Width = 1;
            pen.StartCap = LineCap.RoundAnchor;
            pen.EndCap = LineCap.ArrowAnchor;
            gr.DrawLine(pen, tr.M1.x, tr.M1.y, tr.M1.x + tr.M1.Vector.x, tr.M1.y + tr.M1.Vector.y);
            gr.DrawLine(pen, tr.M2.x, tr.M2.y, tr.M2.x + tr.M2.Vector.x, tr.M2.y + tr.M2.Vector.y);
            gr.DrawLine(pen, tr.M3.x, tr.M3.y, tr.M3.x + tr.M3.Vector.x, tr.M3.y + tr.M3.Vector.y);
        }

        public void drawVector(Vertex v)
        {
            Pen pen = new Pen(Color.Chocolate);
            pen.Width = 1;
            pen.StartCap = LineCap.RoundAnchor;
            pen.EndCap = LineCap.ArrowAnchor;
            gr.DrawLine(pen, v.x, v.y, v.x + v.Vector.x, v.y + v.Vector.y);
        }

        public void drawALLGraph(Graph G)
        {
            //рисуем ребра
            for (int i = 0; i < G.edges.Count; i++)
            {
                drawEdge(G.edges[i]);
            }
            //рисуем вершины
            for (int i = 0; i < G.verts.Count; i++)
            {
                drawVertex(G.verts[i], (i + 1).ToString());
            }
        }

        public void BrushTriangle(Triangle triangle)
        {
            PointF[] myPoints1 = { new PointF(triangle.M1.x, triangle.M1.y), new PointF(triangle.M2.x, triangle.M2.y), new PointF(triangle.M3.x, triangle.M3.y) };
            //PathGradientBrush pgradBrush = new PathGradientBrush(myPoints1); 
            int i = (int) Math.Truncate((1 - triangle.DensityOfTriangle) * 255);
            //SolidBrush redBrush = new SolidBrush(Color.FromArgb(i, i, i));
            SolidBrush redBrush = new SolidBrush(Color.FromArgb(123,i,i,i));
            GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddPolygon(myPoints1);
            gr.FillPath(redBrush, graphPath);
        }
    }
}