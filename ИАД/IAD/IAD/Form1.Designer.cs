namespace IAD
{
    partial class IAD
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
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.модельАвторегрессииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.модельАвторегрессииToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.модельСкользящегоСреднегоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.модельСлучайногоБлужданияСоСдвигомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разработчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дляПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scene = new System.Windows.Forms.PictureBox();
            this.gridBtn = new System.Windows.Forms.Button();
            this.dataLoadBtn = new System.Windows.Forms.Button();
            this.scenepanel = new System.Windows.Forms.Panel();
            this.modelNameLbl = new System.Windows.Forms.Label();
            this.graphBuildBtn = new System.Windows.Forms.Button();
            this.qscaleNmr = new System.Windows.Forms.NumericUpDown();
            this.dataLbl = new System.Windows.Forms.Label();
            this.dataDGV = new System.Windows.Forms.DataGridView();
            this.xClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qLbl = new System.Windows.Forms.Label();
            this.stepsL = new System.Windows.Forms.Label();
            this.YScrBr = new System.Windows.Forms.VScrollBar();
            this.XScrBr = new System.Windows.Forms.HScrollBar();
            this.stepsT = new System.Windows.Forms.TextBox();
            this.modelNmr = new System.Windows.Forms.NumericUpDown();
            this.modelLbl = new System.Windows.Forms.Label();
            this.scaleValY = new System.Windows.Forms.Label();
            this.scaleValX = new System.Windows.Forms.Label();
            this.scaleYLbl = new System.Windows.Forms.Label();
            this.scaleYTrcBr = new System.Windows.Forms.TrackBar();
            this.scaleXLbl = new System.Windows.Forms.Label();
            this.scaleXTrcBr = new System.Windows.Forms.TrackBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scene)).BeginInit();
            this.scenepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qscaleNmr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelNmr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYTrcBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXTrcBr)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.модельАвторегрессииToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(778, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // модельАвторегрессииToolStripMenuItem
            // 
            this.модельАвторегрессииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.модельАвторегрессииToolStripMenuItem1,
            this.модельСкользящегоСреднегоToolStripMenuItem,
            this.модельСлучайногоБлужданияСоСдвигомToolStripMenuItem});
            this.модельАвторегрессииToolStripMenuItem.Name = "модельАвторегрессииToolStripMenuItem";
            this.модельАвторегрессииToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.модельАвторегрессииToolStripMenuItem.Text = "Главная";
            // 
            // модельАвторегрессииToolStripMenuItem1
            // 
            this.модельАвторегрессииToolStripMenuItem1.Name = "модельАвторегрессииToolStripMenuItem1";
            this.модельАвторегрессииToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            this.модельАвторегрессииToolStripMenuItem1.Text = "Модель авторегрессии";
            this.модельАвторегрессииToolStripMenuItem1.Click += new System.EventHandler(this.модельАвторегрессииToolStripMenuItem1_Click);
            // 
            // модельСкользящегоСреднегоToolStripMenuItem
            // 
            this.модельСкользящегоСреднегоToolStripMenuItem.Name = "модельСкользящегоСреднегоToolStripMenuItem";
            this.модельСкользящегоСреднегоToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.модельСкользящегоСреднегоToolStripMenuItem.Text = "Модель скользящего среднего";
            this.модельСкользящегоСреднегоToolStripMenuItem.Click += new System.EventHandler(this.модельСкользящегоСреднегоToolStripMenuItem_Click);
            // 
            // модельСлучайногоБлужданияСоСдвигомToolStripMenuItem
            // 
            this.модельСлучайногоБлужданияСоСдвигомToolStripMenuItem.Name = "модельСлучайногоБлужданияСоСдвигомToolStripMenuItem";
            this.модельСлучайногоБлужданияСоСдвигомToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.модельСлучайногоБлужданияСоСдвигомToolStripMenuItem.Text = "Модель случайного блуждания со сдвигом";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.разработчикToolStripMenuItem,
            this.дляПользователяToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // разработчикToolStripMenuItem
            // 
            this.разработчикToolStripMenuItem.Name = "разработчикToolStripMenuItem";
            this.разработчикToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.разработчикToolStripMenuItem.Text = "Разработчик";
            // 
            // дляПользователяToolStripMenuItem
            // 
            this.дляПользователяToolStripMenuItem.Name = "дляПользователяToolStripMenuItem";
            this.дляПользователяToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.дляПользователяToolStripMenuItem.Text = "Для пользователя";
            // 
            // scene
            // 
            this.scene.Location = new System.Drawing.Point(12, 7);
            this.scene.Name = "scene";
            this.scene.Size = new System.Drawing.Size(515, 401);
            this.scene.TabIndex = 0;
            this.scene.TabStop = false;
            // 
            // gridBtn
            // 
            this.gridBtn.Location = new System.Drawing.Point(11, 436);
            this.gridBtn.Name = "gridBtn";
            this.gridBtn.Size = new System.Drawing.Size(70, 45);
            this.gridBtn.TabIndex = 1;
            this.gridBtn.Text = "Построить сетку";
            this.gridBtn.UseVisualStyleBackColor = true;
            this.gridBtn.Click += new System.EventHandler(this.gridBtn_Click);
            // 
            // dataLoadBtn
            // 
            this.dataLoadBtn.Enabled = false;
            this.dataLoadBtn.Location = new System.Drawing.Point(87, 436);
            this.dataLoadBtn.Name = "dataLoadBtn";
            this.dataLoadBtn.Size = new System.Drawing.Size(70, 45);
            this.dataLoadBtn.TabIndex = 2;
            this.dataLoadBtn.Text = "Загрузить данные";
            this.dataLoadBtn.UseVisualStyleBackColor = true;
            this.dataLoadBtn.Visible = false;
            this.dataLoadBtn.Click += new System.EventHandler(this.dataLoadBtn_Click);
            // 
            // scenepanel
            // 
            this.scenepanel.Controls.Add(this.modelNameLbl);
            this.scenepanel.Controls.Add(this.graphBuildBtn);
            this.scenepanel.Controls.Add(this.qscaleNmr);
            this.scenepanel.Controls.Add(this.dataLbl);
            this.scenepanel.Controls.Add(this.dataDGV);
            this.scenepanel.Controls.Add(this.qLbl);
            this.scenepanel.Controls.Add(this.stepsL);
            this.scenepanel.Controls.Add(this.YScrBr);
            this.scenepanel.Controls.Add(this.XScrBr);
            this.scenepanel.Controls.Add(this.stepsT);
            this.scenepanel.Controls.Add(this.modelNmr);
            this.scenepanel.Controls.Add(this.modelLbl);
            this.scenepanel.Controls.Add(this.scaleValY);
            this.scenepanel.Controls.Add(this.scaleValX);
            this.scenepanel.Controls.Add(this.scaleYLbl);
            this.scenepanel.Controls.Add(this.scaleYTrcBr);
            this.scenepanel.Controls.Add(this.scaleXLbl);
            this.scenepanel.Controls.Add(this.scaleXTrcBr);
            this.scenepanel.Controls.Add(this.dataLoadBtn);
            this.scenepanel.Controls.Add(this.gridBtn);
            this.scenepanel.Controls.Add(this.scene);
            this.scenepanel.Location = new System.Drawing.Point(0, 27);
            this.scenepanel.Name = "scenepanel";
            this.scenepanel.Size = new System.Drawing.Size(777, 493);
            this.scenepanel.TabIndex = 1;
            // 
            // modelNameLbl
            // 
            this.modelNameLbl.AutoSize = true;
            this.modelNameLbl.Location = new System.Drawing.Point(573, 7);
            this.modelNameLbl.Name = "modelNameLbl";
            this.modelNameLbl.Size = new System.Drawing.Size(49, 13);
            this.modelNameLbl.TabIndex = 21;
            this.modelNameLbl.Text = "Модель:";
            // 
            // graphBuildBtn
            // 
            this.graphBuildBtn.Enabled = false;
            this.graphBuildBtn.Location = new System.Drawing.Point(163, 436);
            this.graphBuildBtn.Name = "graphBuildBtn";
            this.graphBuildBtn.Size = new System.Drawing.Size(70, 45);
            this.graphBuildBtn.TabIndex = 20;
            this.graphBuildBtn.Text = "Построить график";
            this.graphBuildBtn.UseVisualStyleBackColor = true;
            this.graphBuildBtn.Visible = false;
            this.graphBuildBtn.Click += new System.EventHandler(this.graphBuildBtn_Click);
            // 
            // qscaleNmr
            // 
            this.qscaleNmr.Enabled = false;
            this.qscaleNmr.Location = new System.Drawing.Point(676, 172);
            this.qscaleNmr.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.qscaleNmr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qscaleNmr.Name = "qscaleNmr";
            this.qscaleNmr.Size = new System.Drawing.Size(87, 20);
            this.qscaleNmr.TabIndex = 19;
            this.qscaleNmr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qscaleNmr.Visible = false;
            // 
            // dataLbl
            // 
            this.dataLbl.AutoSize = true;
            this.dataLbl.Location = new System.Drawing.Point(563, 199);
            this.dataLbl.Name = "dataLbl";
            this.dataLbl.Size = new System.Drawing.Size(102, 13);
            this.dataLbl.TabIndex = 18;
            this.dataLbl.Text = "Значение выборки";
            // 
            // dataDGV
            // 
            this.dataDGV.AllowUserToAddRows = false;
            this.dataDGV.AllowUserToDeleteRows = false;
            this.dataDGV.AllowUserToOrderColumns = true;
            this.dataDGV.AllowUserToResizeColumns = false;
            this.dataDGV.AllowUserToResizeRows = false;
            this.dataDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xClm,
            this.yClm});
            this.dataDGV.Enabled = false;
            this.dataDGV.Location = new System.Drawing.Point(561, 221);
            this.dataDGV.Name = "dataDGV";
            this.dataDGV.Size = new System.Drawing.Size(205, 269);
            this.dataDGV.TabIndex = 17;
            this.dataDGV.Visible = false;
            // 
            // xClm
            // 
            this.xClm.HeaderText = "X";
            this.xClm.Name = "xClm";
            this.xClm.Width = 70;
            // 
            // yClm
            // 
            this.yClm.HeaderText = "Y";
            this.yClm.Name = "yClm";
            this.yClm.Width = 70;
            // 
            // qLbl
            // 
            this.qLbl.AutoSize = true;
            this.qLbl.Enabled = false;
            this.qLbl.Location = new System.Drawing.Point(673, 153);
            this.qLbl.Name = "qLbl";
            this.qLbl.Size = new System.Drawing.Size(51, 13);
            this.qLbl.TabIndex = 16;
            this.qLbl.Text = "Порядок";
            this.qLbl.Visible = false;
            // 
            // stepsL
            // 
            this.stepsL.AutoSize = true;
            this.stepsL.Enabled = false;
            this.stepsL.Location = new System.Drawing.Point(563, 153);
            this.stepsL.Name = "stepsL";
            this.stepsL.Size = new System.Drawing.Size(50, 13);
            this.stepsL.TabIndex = 14;
            this.stepsL.Text = "Прогноз";
            this.stepsL.Visible = false;
            // 
            // YScrBr
            // 
            this.YScrBr.Location = new System.Drawing.Point(534, 7);
            this.YScrBr.Minimum = -100;
            this.YScrBr.Name = "YScrBr";
            this.YScrBr.Size = new System.Drawing.Size(21, 401);
            this.YScrBr.TabIndex = 13;
            this.YScrBr.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // XScrBr
            // 
            this.XScrBr.Location = new System.Drawing.Point(12, 415);
            this.XScrBr.Minimum = -100;
            this.XScrBr.Name = "XScrBr";
            this.XScrBr.Size = new System.Drawing.Size(515, 18);
            this.XScrBr.TabIndex = 12;
            this.XScrBr.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // stepsT
            // 
            this.stepsT.Enabled = false;
            this.stepsT.Location = new System.Drawing.Point(563, 172);
            this.stepsT.Name = "stepsT";
            this.stepsT.Size = new System.Drawing.Size(87, 20);
            this.stepsT.TabIndex = 11;
            this.stepsT.Text = "0";
            this.stepsT.Visible = false;
            this.stepsT.TextChanged += new System.EventHandler(this.stepsT_TextChanged);
            // 
            // modelNmr
            // 
            this.modelNmr.Enabled = false;
            this.modelNmr.Location = new System.Drawing.Point(563, 124);
            this.modelNmr.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.modelNmr.Name = "modelNmr";
            this.modelNmr.Size = new System.Drawing.Size(87, 20);
            this.modelNmr.TabIndex = 10;
            this.modelNmr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.modelNmr.Visible = false;
            // 
            // modelLbl
            // 
            this.modelLbl.AutoSize = true;
            this.modelLbl.Enabled = false;
            this.modelLbl.Location = new System.Drawing.Point(563, 108);
            this.modelLbl.Name = "modelLbl";
            this.modelLbl.Size = new System.Drawing.Size(92, 13);
            this.modelLbl.TabIndex = 9;
            this.modelLbl.Text = "Порядок модели";
            this.modelLbl.Visible = false;
            // 
            // scaleValY
            // 
            this.scaleValY.AutoSize = true;
            this.scaleValY.Location = new System.Drawing.Point(706, 84);
            this.scaleValY.Name = "scaleValY";
            this.scaleValY.Size = new System.Drawing.Size(35, 13);
            this.scaleValY.TabIndex = 8;
            this.scaleValY.Text = "label1";
            // 
            // scaleValX
            // 
            this.scaleValX.AutoSize = true;
            this.scaleValX.Location = new System.Drawing.Point(603, 84);
            this.scaleValX.Name = "scaleValX";
            this.scaleValX.Size = new System.Drawing.Size(35, 13);
            this.scaleValX.TabIndex = 7;
            this.scaleValX.Text = "label1";
            // 
            // scaleYLbl
            // 
            this.scaleYLbl.AutoSize = true;
            this.scaleYLbl.Location = new System.Drawing.Point(673, 36);
            this.scaleYLbl.Name = "scaleYLbl";
            this.scaleYLbl.Size = new System.Drawing.Size(78, 13);
            this.scaleYLbl.TabIndex = 6;
            this.scaleYLbl.Text = "Масштаб по Y";
            // 
            // scaleYTrcBr
            // 
            this.scaleYTrcBr.Location = new System.Drawing.Point(664, 52);
            this.scaleYTrcBr.Maximum = 20;
            this.scaleYTrcBr.Minimum = 2;
            this.scaleYTrcBr.Name = "scaleYTrcBr";
            this.scaleYTrcBr.Size = new System.Drawing.Size(104, 45);
            this.scaleYTrcBr.TabIndex = 5;
            this.scaleYTrcBr.Value = 10;
            this.scaleYTrcBr.Scroll += new System.EventHandler(this.scaleyTrcBr_Scroll);
            // 
            // scaleXLbl
            // 
            this.scaleXLbl.AutoSize = true;
            this.scaleXLbl.Location = new System.Drawing.Point(570, 36);
            this.scaleXLbl.Name = "scaleXLbl";
            this.scaleXLbl.Size = new System.Drawing.Size(78, 13);
            this.scaleXLbl.TabIndex = 4;
            this.scaleXLbl.Text = "Масштаб по Х";
            // 
            // scaleXTrcBr
            // 
            this.scaleXTrcBr.Location = new System.Drawing.Point(561, 52);
            this.scaleXTrcBr.Maximum = 20;
            this.scaleXTrcBr.Minimum = 2;
            this.scaleXTrcBr.Name = "scaleXTrcBr";
            this.scaleXTrcBr.Size = new System.Drawing.Size(104, 45);
            this.scaleXTrcBr.TabIndex = 5;
            this.scaleXTrcBr.Value = 10;
            this.scaleXTrcBr.Scroll += new System.EventHandler(this.scalexTrcBr_Scroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // IAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 520);
            this.Controls.Add(this.scenepanel);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "IAD";
            this.Text = "ИАД";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scene)).EndInit();
            this.scenepanel.ResumeLayout(false);
            this.scenepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qscaleNmr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelNmr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYTrcBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXTrcBr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem модельАвторегрессииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem модельАвторегрессииToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem модельСкользящегоСреднегоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem модельСлучайногоБлужданияСоСдвигомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разработчикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дляПользователяToolStripMenuItem;
        private System.Windows.Forms.PictureBox scene;
        private System.Windows.Forms.Button gridBtn;
        private System.Windows.Forms.Button dataLoadBtn;
        private System.Windows.Forms.Panel scenepanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label scaleYLbl;
        private System.Windows.Forms.TrackBar scaleYTrcBr;
        private System.Windows.Forms.Label scaleXLbl;
        private System.Windows.Forms.TrackBar scaleXTrcBr;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label scaleValY;
        private System.Windows.Forms.Label scaleValX;
        private System.Windows.Forms.NumericUpDown modelNmr;
        private System.Windows.Forms.Label modelLbl;
        private System.Windows.Forms.TextBox stepsT;
        private System.Windows.Forms.VScrollBar YScrBr;
        private System.Windows.Forms.HScrollBar XScrBr;
        private System.Windows.Forms.Label qLbl;
        private System.Windows.Forms.Label stepsL;
        private System.Windows.Forms.DataGridView dataDGV;
        private System.Windows.Forms.Label dataLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn xClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn yClm;
        private System.Windows.Forms.NumericUpDown qscaleNmr;
        private System.Windows.Forms.Button graphBuildBtn;
        private System.Windows.Forms.Label modelNameLbl;
    }
}

