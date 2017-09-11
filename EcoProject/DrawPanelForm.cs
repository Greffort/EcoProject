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
        Triangulator _triangulator = new Triangulator();
        private BindingList<Vertex> VV;
        private BindingSource bs;
        private List<Edge> E;
        int selected1; //выбранные вершины, для соединения линиями
        int selected2;

        public DrawPanelForm()
        {
            InitializeComponent();
            V = new List<Vertex>();
            VV = new BindingList<Vertex>();
            draw = new Drawing(sheet.Width, sheet.Height);
            E = new List<Edge>();
            //graph = new Graph();
            sheet.Image = draw.GetBitmap();
            mainTable.AutoGenerateColumns = false;

            mainTable.Columns.Add("num", "№ вершины");
            mainTable.Columns.Add("xVertex", "X вершины");
            mainTable.Columns.Add("yVertex", "Y вершины");
            mainTable.Columns.Add("xVector", "X вектора");
            mainTable.Columns.Add("xVector", "Y вектора");

            //создание столбца кнопок
            DataGridViewButtonColumn button_column = new DataGridViewButtonColumn();
            button_column.Name = "deleteVertex";
            button_column.HeaderText = "Удаление";
            button_column.FlatStyle = FlatStyle.Popup;
            button_column.DefaultCellStyle.BackColor = Color.Firebrick;


            mainTable.Columns.Add(button_column);

            mainTable.Columns[1].DataPropertyName = "x";
            mainTable.Columns[2].DataPropertyName = "y";
            mainTable.Columns[3].DataPropertyName = "xVector";
            mainTable.Columns[4].DataPropertyName = "yVector";

            // mainTab_dataGridView.Columns[3].DataPropertyName = "";

            //// Bind the list to the BindingSource.
            //this.customersBindingSource.DataSource = VV;

            //// Attach the BindingSource to the DataGridView.
            //this.coordinate_dGV.DataSource = this.customersBindingSource;



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
            ClearPictureBox();
        }

        private void ClearPictureBox()
        {
            draw.clearSheet();
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

        //private BindingSource customersBindingSource = new BindingSource();

        //метод удаления строки из датагрида и соответсвующей ей вершины (до триангуляции) 

        // private void Delete 

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

                Update_mainTab_dgv();
                UpdatePictureBox();


                // BindingList<Vertex> VV =
                //this.customersBindingSource.DataSource as BindingList<Vertex>;

                // VV.Add(vert);

                //добавление в таблицу
                //mainTable.Rows.Add(V.Count.ToString(), vert);


                //dataGridView1.Columns[2].Visible = false;


                //var bindingList = new BindingList<Vertex>(V);
                //var source = new BindingSource(bindingList, null);
                //coordinate_dGV.DataSource = source;


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

        private void UpdatePictureBox()
        {
            ClearPictureBox();
            int i = 1;
            foreach (Vertex item in V)
            {
                draw.drawVertex(item, i++.ToString());
                draw.drawVector(item);
            }
            sheet.Image = draw.GetBitmap();
        }

        private void Update_mainTab_dgv()
        {
            mainTable.DataSource = null;
            mainTable.DataSource = V;

            for (int i = 0; i < mainTable.RowCount; i++)
            {
                mainTable.Rows[i].Cells[0].Value = i + 1;
                mainTable.Rows[i].Cells["deleteVertex"].Value = "✕";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsTableFilled())
            {
                SetVectors();
                Monitoring monitor = new Monitoring(_triangulator.Triangulation(V));
                //monitor.GetArrayOfOutsideEdge();
                //monitor.AllDensities();
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
                float x = Convert.ToSingle(mainTable.Rows[i].Cells[3].Value);
                float y = Convert.ToSingle(mainTable.Rows[i].Cells[4].Value);
                V[i].Vector = new Vector(x, y);
            }
        }

        private bool IsTableFilled()
        {
            if (mainTable.Rows.Count > 0)
            {
                for (int i = 0; i < mainTable.Rows.Count; i++)
                {
                    if (mainTable.Rows[i].Cells[3].Value == null || mainTable.Rows[i].Cells[4].Value == null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private void detail_btn_Click(object sender, EventArgs e)
        {

        }

        private void example_button_Click(object sender, EventArgs e)
        {
            ClearPictureBox();
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
                mainTable.Rows.Add(i + 1, V[i], V[i].Vector.x, V[i].Vector.y);
            }
            sheet.Image = draw.GetBitmap();
        }

        private void Example()
        {
            mainTable.Rows.Clear();
            V.Clear();
            E.Clear();
            // умножаем все значения на 20
            float multipl = 20f;
            Random r1 = new Random();
            Random r2 = new Random();
            V.Add(new Vertex(132, 155));

            V[0].Vector = new Vector(1 * multipl * r1.Next(-2, 2), -1 * multipl * r2.Next(-1, 2));
            Thread.Sleep(12);

            V.Add(new Vertex(345, 180));
            V[1].Vector = new Vector(1 * multipl * r1.Next(-1, 2), 1 * multipl * r2.Next(-2, 2));
            Thread.Sleep(12);

            V.Add(new Vertex(158, 234));
            V[2].Vector = new Vector(2 * multipl * r1.Next(-1, 2), 1 * multipl * r2.Next(-1, 2));
            Thread.Sleep(12);

            V.Add(new Vertex(393, 358));
            V[3].Vector = new Vector(3 * multipl * r1.Next(-1, 2), 0 * multipl * r2.Next(-1, 2));
            Thread.Sleep(12);

            V.Add(new Vertex(492, 312));
            V[4].Vector = new Vector(0 * multipl, 0 * multipl * r2.Next(-1, 2));
            Thread.Sleep(12);

            V.Add(new Vertex(469, 250));
            V[5].Vector = new Vector(2 * multipl * r1.Next(-1, 2), 1 * multipl * r2.Next(-1, 2));
            Thread.Sleep(12);

            V.Add(new Vertex(478, 165));
            V[6].Vector = new Vector(1 * multipl * r1.Next(-1, 2), 0 * multipl * r2.Next(-1, 2));
            Thread.Sleep(12);

            V.Add(new Vertex(398, 217));
            V[7].Vector = new Vector(1 * multipl * r1.Next(-1, 2), 2 * multipl * r2.Next(-1, 2));
            Thread.Sleep(12);

            V.Add(new Vertex(315, 258));
            V[8].Vector = new Vector(3 * multipl * r1.Next(-1, 2), 1 * multipl * r2.Next(-1, 2));
            Thread.Sleep(12);
            for (int i = 0; i < V.Count; i++)
            {
                draw.drawVertex(V[i], (i + 1).ToString());
                draw.drawVector(V[i]);
                mainTable.Rows.Add(i + 1, V[i], V[i].Vector.x, V[i].Vector.y);
            }
            sheet.Image = draw.GetBitmap();


        }

        private void AddVertex_button_Click(object sender, EventArgs e)
        {

        }

        private void DrawPanelForm_Load(object sender, EventArgs e)
        {
            //вынести условия


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void inputPoint_rb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void putPoint_rb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ReverseVisible(Control c)
        {
            if (c.Visible) c.Visible = false;
            else c.Visible = true;
        }

        private void coordinate_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainTab_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) //индекс столбца, в которой находится кнопка.
            {
                V.RemoveAt(e.RowIndex);
                Update_mainTab_dgv();
                UpdatePictureBox();
            }

        }

        private void mainTab_dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int check = e.ColumnIndex;

            switch (check)
            {
                case 1: //изменение координаты X вершины
                    {
                        float number;
                        string cellsValue = mainTable.Rows[e.RowIndex].Cells[check].Value.ToString();
                        if (float.TryParse(cellsValue, out number))
                        {
                            V[e.RowIndex].x = number;
                        }

                        break;
                    }
                case 2: //изменение координаты Y вершины
                    {
                        float number;
                        string cellsValue = mainTable.Rows[e.RowIndex].Cells[check].Value.ToString();
                        if (float.TryParse(cellsValue, out number))
                        {
                            V[e.RowIndex].y = number;
                        }

                        break;
                    }
                case 3: //изменение координаты X вектора
                    {
                        float number;
                        string cellsValue = mainTable.Rows[e.RowIndex].Cells[check].Value.ToString();
                        if (float.TryParse(cellsValue, out number))
                        {
                            V[e.RowIndex].xVector = number;
                        }
                        break;
                    }
                case 4: //изменение координаты Y вектора
                    {
                        float number;
                        string cellsValue = mainTable.Rows[e.RowIndex].Cells[check].Value.ToString();
                        if (float.TryParse(cellsValue, out number))
                        {
                            V[e.RowIndex].yVector = number;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            UpdatePictureBox();
            float a = V[0].x;
        }

        private void addEmptyVertex_btn_Click(object sender, EventArgs e)
        {
            Vertex vert = new Vertex();
            V.Add(vert);
            Update_mainTab_dgv();
        }

        //private void mainTab_dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    switch (e.ColumnIndex)
        //    {
        //        case 3:
        //            {
        //                V[e.RowIndex].xVector = (float)mainTab_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //                break;
        //            }
        //        case 4:
        //            {
        //                V[e.RowIndex].yVector = (float)mainTab_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //                break;
        //            }
        //    }
            
        //}
    }
}
