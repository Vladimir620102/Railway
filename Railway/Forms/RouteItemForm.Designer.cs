namespace Railway.Forms
{
    partial class RouteItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteItemForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTrain = new System.Windows.Forms.Label();
            this.dtpArrivalTime = new System.Windows.Forms.DateTimePicker();
            this.dtpArrivalDate = new System.Windows.Forms.DateTimePicker();
            this.cbStation = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDepartureTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDepartureDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 352);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(486, 71);
            this.panel3.TabIndex = 3;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(376, 23);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSave.Location = new System.Drawing.Point(265, 23);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Станция";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTrain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 53);
            this.panel1.TabIndex = 7;
            // 
            // labelTrain
            // 
            this.labelTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTrain.Location = new System.Drawing.Point(0, 0);
            this.labelTrain.Name = "labelTrain";
            this.labelTrain.Size = new System.Drawing.Size(486, 53);
            this.labelTrain.TabIndex = 0;
            this.labelTrain.Text = "Поезд №";
            this.labelTrain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpArrivalTime
            // 
            this.dtpArrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpArrivalTime.Location = new System.Drawing.Point(89, 51);
            this.dtpArrivalTime.Name = "dtpArrivalTime";
            this.dtpArrivalTime.Size = new System.Drawing.Size(200, 20);
            this.dtpArrivalTime.TabIndex = 8;
            // 
            // dtpArrivalDate
            // 
            this.dtpArrivalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpArrivalDate.Location = new System.Drawing.Point(89, 23);
            this.dtpArrivalDate.Name = "dtpArrivalDate";
            this.dtpArrivalDate.Size = new System.Drawing.Size(200, 20);
            this.dtpArrivalDate.TabIndex = 9;
            // 
            // cbStation
            // 
            this.cbStation.FormattingEnabled = true;
            this.cbStation.Location = new System.Drawing.Point(129, 59);
            this.cbStation.Name = "cbStation";
            this.cbStation.Size = new System.Drawing.Size(325, 21);
            this.cbStation.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpArrivalTime);
            this.groupBox1.Controls.Add(this.dtpArrivalDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(40, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Прибытие";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Время";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpDepartureTime);
            this.groupBox2.Controls.Add(this.dtpDepartureDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(40, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отправление";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Время";
            // 
            // dtpDepartureTime
            // 
            this.dtpDepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDepartureTime.Location = new System.Drawing.Point(89, 51);
            this.dtpDepartureTime.Name = "dtpDepartureTime";
            this.dtpDepartureTime.Size = new System.Drawing.Size(200, 20);
            this.dtpDepartureTime.TabIndex = 8;
            // 
            // dtpDepartureDate
            // 
            this.dtpDepartureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepartureDate.Location = new System.Drawing.Point(89, 23);
            this.dtpDepartureDate.Name = "dtpDepartureDate";
            this.dtpDepartureDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDepartureDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Дата";
            // 
            // RouteItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 423);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbStation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RouteItemForm";
            this.Text = "Станция";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label labelTrain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtpDepartureTime;
        public System.Windows.Forms.DateTimePicker dtpDepartureDate;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dtpArrivalTime;
        public System.Windows.Forms.DateTimePicker dtpArrivalDate;
        public System.Windows.Forms.ComboBox cbStation;
    }
}