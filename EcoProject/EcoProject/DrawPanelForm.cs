using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace EcoProject
{
    public partial class DrawPanelForm : Form
    {
        Graph graph;
        Drawing draw;
        List<Vertex> V;
        List<Edge> E;
        List<Triangle> Triangles;
        
        int selected1; //выбранные вершины, для соединения линиями
        int selected2;

        public DrawPanelForm()
        {
            InitializeComponent();
            V = new List<Vertex>();
            draw = new Drawing(sheet.Width, sheet.Height);
            E = new List<Edge>();
            //graph = new Graph();
            sheet.Image = draw.GetBitmap();

            selectButton.Visible = false;
            drawEdgeButton.Visible = false;
            deleteALLButton.Visible = false;
            deleteButton.Visible = false;
        }

        //кнопка - выбрать вершину
        private void selectButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            draw.clearSheet();
            draw.drawALLGraph(graph);
            sheet.Image = draw.GetBitmap();
            selected1 = -1;
        }

        //кнопка - рисовать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            draw.clearSheet();
            //draw.drawALLGraph(graph);
            sheet.Image = draw.GetBitmap();
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            draw.clearSheet();
            draw.drawALLGraph(graph);
            sheet.Image = draw.GetBitmap();
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                draw.clearSheet();
                sheet.Image = draw.GetBitmap();
            }
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //нажата кнопка "выбрать вершину"
            if (selectButton.Enabled == false)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= draw.R * draw.R) // Поиск нажатой вершины
                    {
                        // Написать метод, чтобы при нажатии вершины всплывало окошко, где можно было бы изменить координаты вершины и вектора
                    }
                }
            }
            //нажата кнопка "рисовать вершину"
            if (drawVertexButton.Enabled == false)
            {
                Vertex vert = new Vertex(e.X, e.Y);
                V.Add(vert);
                draw.drawVertex(vert, V.Count.ToString());              
                dataGridView1.Rows.Add(V.Count.ToString(), vert);
                sheet.Image = draw.GetBitmap();
            }

            //нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= draw.R * draw.R) // Поиск нажатой вершины
                    {
                        // Написать метод удаления вершны
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    draw.clearSheet();
                    draw.drawALLGraph(graph);
                    sheet.Image = draw.GetBitmap();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsTableFilled())
            {
                Triangulator triangulate = new Triangulator();
                List<Vertex> listvertex = new List<Vertex>();

                SetVectors();
                foreach (Vertex vert in V)
                {
                    draw.drawVector(vert);
                }
                List<Triangle> tr = triangulate.Triangulation(V);
                Monitoring monitor = new Monitoring(tr);
                monitor.GetArrayOfOutsideEdge();
                monitor.AllDensities();
                foreach (Triangle t in monitor.triangles)
                {
                    draw.BrushTriangle(t);
                    richTextBox1.Text += t.ToString();
                }

                foreach (Triangle t in tr)
                {
                    draw.drawTriangle(t);
                }

                //переписать не под вызов конструктора, а под вызов метода, который будет сравнивать треугольники.
                //т.е. Equals для треугольников, который сравнивает по вершинам.

                foreach (Triangle t in tr)
                {
                    for (int i = 0; i < t.edgemas.Length; i++)
                    {
                        if (t.edgemas[i].isOutside) draw.drawEdge(t.edgemas[i]);
                        //if (t.edgemas[i].brother != null) G.drawEdge(t.edgemas[i].brother, new Pen(Color.Aqua));
                    }
                }
                sheet.Image = draw.GetBitmap();
            }
            else
            {
                MessageBox.Show("Заполните значения векторов", "Ошибка заполнения");
            }

        }

        private void SetVectors()
        {
            for (int i = 0; i < V.Count; i++)
            {
                //дописать tryparse-условие
                float x = Convert.ToSingle(dataGridView1.Rows[i].Cells[2].Value.ToString());
                float y = Convert.ToSingle(dataGridView1.Rows[i].Cells[3].Value.ToString());
                V[i].Vector = new Vector(x, y);
            }
        }

        private bool IsTableFilled()
        {
            bool flagempty = true;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value == null || dataGridView1.Rows[i].Cells[3].Value == null)
                {
                    flagempty = false;
                }
            }

            return flagempty;
        }

        private void detail_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
