namespace EcoProject
{
    partial class DrawPanelForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawPanelForm));
            this.detail_btn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.AddVertex_button = new System.Windows.Forms.Button();
            this.example_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.mainTable = new System.Windows.Forms.DataGridView();
            this.addEmptyVertex_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTable)).BeginInit();
            this.SuspendLayout();
            // 
            // detail_btn
            // 
            this.detail_btn.Location = new System.Drawing.Point(92, 456);
            this.detail_btn.Name = "detail_btn";
            this.detail_btn.Size = new System.Drawing.Size(129, 23);
            this.detail_btn.TabIndex = 16;
            this.detail_btn.Text = "Детализировать";
            this.detail_btn.UseVisualStyleBackColor = true;
            this.detail_btn.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(762, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(299, 438);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // AddVertex_button
            // 
            this.AddVertex_button.Location = new System.Drawing.Point(238, 456);
            this.AddVertex_button.Name = "AddVertex_button";
            this.AddVertex_button.Size = new System.Drawing.Size(98, 23);
            this.AddVertex_button.TabIndex = 20;
            this.AddVertex_button.Text = "Добавить точку";
            this.AddVertex_button.Visible = false;
            // 
            // example_button
            // 
            this.example_button.Location = new System.Drawing.Point(2, 456);
            this.example_button.Name = "example_button";
            this.example_button.Size = new System.Drawing.Size(68, 23);
            this.example_button.TabIndex = 21;
            this.example_button.Text = "Пример";
            this.example_button.Click += new System.EventHandler(this.example_button_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(2, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 54);
            this.button1.TabIndex = 15;
            this.button1.Text = "Δ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectButton
            // 
            this.selectButton.Image = global::EcoProject.Properties.Resources.cursor;
            this.selectButton.Location = new System.Drawing.Point(12, 291);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(45, 45);
            this.selectButton.TabIndex = 9;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Visible = false;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.Image = global::EcoProject.Properties.Resources.deleteAll;
            this.deleteALLButton.Location = new System.Drawing.Point(12, 240);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(45, 45);
            this.deleteALLButton.TabIndex = 5;
            this.deleteALLButton.UseVisualStyleBackColor = true;
            this.deleteALLButton.Visible = false;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::EcoProject.Properties.Resources.delete;
            this.deleteButton.Location = new System.Drawing.Point(12, 345);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(45, 45);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.Enabled = false;
            this.drawVertexButton.Image = global::EcoProject.Properties.Resources.vertex;
            this.drawVertexButton.Location = new System.Drawing.Point(11, 12);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(45, 45);
            this.drawVertexButton.TabIndex = 1;
            this.drawVertexButton.UseVisualStyleBackColor = true;
            this.drawVertexButton.Visible = false;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.Color.White;
            this.sheet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sheet.Image = global::EcoProject.Properties.Resources.cursor;
            this.sheet.Location = new System.Drawing.Point(111, 12);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(645, 287);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // mainTable
            // 
            this.mainTable.AllowUserToAddRows = false;
            this.mainTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainTable.Location = new System.Drawing.Point(111, 305);
            this.mainTable.Name = "mainTable";
            this.mainTable.Size = new System.Drawing.Size(645, 145);
            this.mainTable.TabIndex = 25;
            this.mainTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainTab_dataGridView_CellContentClick);
            this.mainTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainTab_dataGridView_CellEndEdit);
            // 
            // addEmptyVertex_btn
            // 
            this.addEmptyVertex_btn.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEmptyVertex_btn.Location = new System.Drawing.Point(717, 456);
            this.addEmptyVertex_btn.Name = "addEmptyVertex_btn";
            this.addEmptyVertex_btn.Size = new System.Drawing.Size(39, 37);
            this.addEmptyVertex_btn.TabIndex = 26;
            this.addEmptyVertex_btn.Text = "+";
            this.addEmptyVertex_btn.UseVisualStyleBackColor = true;
            this.addEmptyVertex_btn.Click += new System.EventHandler(this.addEmptyVertex_btn_Click);
            // 
            // DrawPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1073, 486);
            this.Controls.Add(this.addEmptyVertex_btn);
            this.Controls.Add(this.mainTable);
            this.Controls.Add(this.example_button);
            this.Controls.Add(this.AddVertex_button);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.detail_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.deleteALLButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawVertexButton);
            this.Controls.Add(this.sheet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DrawPanelForm";
            this.Text = "iВолга, Инновации и экология";
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.Button selectButton;
       
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button detail_btn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button AddVertex_button;
        private System.Windows.Forms.Button example_button;
        private System.Windows.Forms.DataGridView mainTable;
        private System.Windows.Forms.Button addEmptyVertex_btn;

    }
}

