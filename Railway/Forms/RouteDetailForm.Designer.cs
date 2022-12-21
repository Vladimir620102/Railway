namespace Railway.Forms
{
    partial class RouteDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteDetailForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeparture = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsEndStation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpArrival = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDeparture = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbArrival = new System.Windows.Forms.ComboBox();
            this.cbDeparture = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbArrival = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(794, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 425);
            this.panel3.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.StationId,
            this.StationName,
            this.Arrived,
            this.Departure,
            this.IsDeparture,
            this.IsEndStation});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(794, 220);
            this.dataGridView1.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.HeaderText = "Идентификатор";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // StationId
            // 
            this.StationId.HeaderText = "Ид станции";
            this.StationId.Name = "StationId";
            this.StationId.ReadOnly = true;
            this.StationId.Visible = false;
            // 
            // StationName
            // 
            this.StationName.HeaderText = "Станция";
            this.StationName.Name = "StationName";
            this.StationName.ReadOnly = true;
            this.StationName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StationName.Width = 350;
            // 
            // Arrived
            // 
            this.Arrived.HeaderText = "Прибытие";
            this.Arrived.Name = "Arrived";
            this.Arrived.ReadOnly = true;
            // 
            // Departure
            // 
            this.Departure.HeaderText = "Отправление";
            this.Departure.Name = "Departure";
            this.Departure.ReadOnly = true;
            // 
            // IsDeparture
            // 
            this.IsDeparture.HeaderText = "Начальная";
            this.IsDeparture.Name = "IsDeparture";
            this.IsDeparture.ReadOnly = true;
            // 
            // IsEndStation
            // 
            this.IsEndStation.HeaderText = "Конечная";
            this.IsEndStation.Name = "IsEndStation";
            this.IsEndStation.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.toolStripSeparator1,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 180);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbAdd.Text = "Добавить";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbEdit.Text = "Изменить";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "Удалить";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbArrival);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.dtpArrival);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.dtpDeparture);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.toolStrip2);
            this.panel4.Controls.Add(this.tbNumber);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cbArrival);
            this.panel4.Controls.Add(this.cbDeparture);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(794, 180);
            this.panel4.TabIndex = 0;
            // 
            // dtpArrival
            // 
            this.dtpArrival.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpArrival.Location = new System.Drawing.Point(565, 87);
            this.dtpArrival.Name = "dtpArrival";
            this.dtpArrival.Size = new System.Drawing.Size(200, 20);
            this.dtpArrival.TabIndex = 10;
            this.dtpArrival.ValueChanged += new System.EventHandler(this.dtpArrival_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Прибытие";
            // 
            // dtpDeparture
            // 
            this.dtpDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDeparture.Location = new System.Drawing.Point(565, 54);
            this.dtpDeparture.Name = "dtpDeparture";
            this.dtpDeparture.Size = new System.Drawing.Size(200, 20);
            this.dtpDeparture.TabIndex = 8;
            this.dtpDeparture.ValueChanged += new System.EventHandler(this.dtpDeparture_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(485, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Отправление";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveAndClose,
            this.toolStripSeparator2,
            this.tsbExit});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(794, 25);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbSaveAndClose
            // 
            this.tsbSaveAndClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAndClose.Image")));
            this.tsbSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAndClose.Name = "tsbSaveAndClose";
            this.tsbSaveAndClose.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveAndClose.Text = "Сохранить и закрыть";
            this.tsbSaveAndClose.Click += new System.EventHandler(this.tsbSaveAndClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(23, 22);
            this.tsbExit.Text = "Закрыть";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(118, 29);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(100, 20);
            this.tbNumber.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Номер";
            // 
            // cbArrival
            // 
            this.cbArrival.FormattingEnabled = true;
            this.cbArrival.Location = new System.Drawing.Point(118, 86);
            this.cbArrival.Name = "cbArrival";
            this.cbArrival.Size = new System.Drawing.Size(324, 21);
            this.cbArrival.TabIndex = 3;
            this.cbArrival.SelectedValueChanged += new System.EventHandler(this.cbArrival_SelectedValueChanged);
            // 
            // cbDeparture
            // 
            this.cbDeparture.FormattingEnabled = true;
            this.cbDeparture.Location = new System.Drawing.Point(118, 54);
            this.cbDeparture.Name = "cbDeparture";
            this.cbDeparture.Size = new System.Drawing.Size(324, 21);
            this.cbDeparture.TabIndex = 2;
            this.cbDeparture.SelectedValueChanged += new System.EventHandler(this.cbDeparture_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Конечная станция";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начальная станция";
            // 
            // tbArrival
            // 
            this.tbArrival.Location = new System.Drawing.Point(565, 122);
            this.tbArrival.Name = "tbArrival";
            this.tbArrival.Size = new System.Drawing.Size(116, 20);
            this.tbArrival.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Число дней после отправления";
            // 
            // RouteDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RouteDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Маршрут поезда";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbSaveAndClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbArrival;
        public System.Windows.Forms.ComboBox cbDeparture;
        public System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpArrival;
        public System.Windows.Forms.DateTimePicker dtpDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrived;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departure;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDeparture;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsEndStation;
        public System.Windows.Forms.TextBox tbArrival;
        private System.Windows.Forms.Label label6;
    }
}