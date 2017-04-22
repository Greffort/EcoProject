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
            deleteALLButton.Visible = false;
            deleteButton.Visible = false;
        }

        //кнопка - выбрать вершину
        private void selectButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
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
            draw.clearSheet();
            draw.drawALLGraph(graph);
            sheet.Image = draw.GetBitmap();
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
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

                //SetVectors();
                List<Triangle> tr = triangulate.Triangulation(V);
                Monitoring monitor = new Monitoring(tr);
                monitor.GetArrayOfOutsideEdge();
                monitor.AllDensities();
                foreach (Triangle t in monitor.triangles)
                {
                    draw.BrushTriangle(t);
                    draw.drawTriangle(t);
                    for (int i = 0; i < t.edgemas.Length; i++)
                    {
                        if (t.edgemas[i].isOutside) draw.drawEdge(t.edgemas[i]);
                        //if (t.edgemas[i].brother != null) G.drawEdge(t.edgemas[i].brother, new Pen(Color.Aqua));
                    }
                    richTextBox1.Text += t.ToString();
                }
                for (int i = 0; i < V.Count; i++)
                {
                    draw.drawVertex(V[i], (i + 1).ToString());
                }

                //переписать не под вызов конструктора, а под вызов метода, который будет сравнивать треугольники.
                //т.е. Equals для треугольников, который сравнивает по вершинам.

                foreach (Vertex vert in V)
                {
                    draw.drawVector(vert);
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
            flagempty = true; // удалить эту строчку
            return flagempty;
        }

        private void detail_btn_Click(object sender, EventArgs e)
        {

        }

        private void example_button_Click(object sender, EventArgs e)
        {
            V.Clear();
            E.Clear();
            // умножаем все значения на 20
            float multipl = 20f;
            V.Add(new Vertex(2 * multipl, 8 * multipl));
            V[0].Vector = new Vector(0 * multipl, 0 * multipl);
            V.Add(new Vertex(100, 300));
            V[1].Vector = new Vector(1 * multipl, -1 * multipl);
            V.Add(new Vertex(120, 40));
            V[2].Vector = new Vector(1 * multipl, 1 * multipl);
            V.Add(new Vertex(160, 200));
            V[3].Vector = new Vector(2 * multipl, 1 * multipl);
            V.Add(new Vertex(220, 320));
            V[4].Vector = new Vector(3 * multipl, 0 * multipl);
            V.Add(new Vertex(240, 100));
            V[5].Vector = new Vector(0 * multipl, 0 * multipl);
            V.Add(new Vertex(260, 180));
            V[6].Vector = new Vector(2 * multipl, 1 * multipl);
            V.Add(new Vertex(17 * multipl, 1 * multipl));
            V[7].Vector = new Vector(1 * multipl, 0 * multipl);
            V.Add(new Vertex(17 * multipl, 7 * multipl));
            V[8].Vector = new Vector(1 * multipl, 2 * multipl);
            V.Add(new Vertex(18 * multipl, 13 * multipl));
            V[9].Vector = new Vector(3 * multipl, 1 * multipl);
            V.Add(new Vertex(20 * multipl, 9 * multipl));
            V[10].Vector = new Vector(2 * multipl, 2 * multipl);
            for (int i = 0; i < V.Count; i++)
            {
                draw.drawVertex(V[i], (i + 1).ToString());
                draw.drawVector(V[i]);
                dataGridView1.Rows.Add(i + 1, V[i], V[i].Vector.x, V[i].Vector.y);
            }
            sheet.Image = draw.GetBitmap();
        }
    }
}
