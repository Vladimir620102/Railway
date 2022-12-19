namespace Railway
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.билетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.городаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.станцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типВагонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поездаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 37);
            this.panel2.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.билетToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // билетToolStripMenuItem
            // 
            this.билетToolStripMenuItem.Name = "билетToolStripMenuItem";
            this.билетToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.билетToolStripMenuItem.Text = "Билет";
            this.билетToolStripMenuItem.Click += new System.EventHandler(this.билетToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCountry,
            this.городаToolStripMenuItem,
            this.станцииToolStripMenuItem,
            this.типВагонаToolStripMenuItem,
            this.маршрутToolStripMenuItem,
            this.поездаToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // miCountry
            // 
            this.miCountry.Name = "miCountry";
            this.miCountry.Size = new System.Drawing.Size(180, 22);
            this.miCountry.Text = "Страны";
            this.miCountry.Click += new System.EventHandler(this.miCountry_Click);
            // 
            // городаToolStripMenuItem
            // 
            this.городаToolStripMenuItem.Name = "городаToolStripMenuItem";
            this.городаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.городаToolStripMenuItem.Text = "Города";
            this.городаToolStripMenuItem.Click += new System.EventHandler(this.городаToolStripMenuItem_Click);
            // 
            // станцииToolStripMenuItem
            // 
            this.станцииToolStripMenuItem.Name = "станцииToolStripMenuItem";
            this.станцииToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.станцииToolStripMenuItem.Text = "Станции";
            this.станцииToolStripMenuItem.Click += new System.EventHandler(this.станцииToolStripMenuItem_Click);
            // 
            // типВагонаToolStripMenuItem
            // 
            this.типВагонаToolStripMenuItem.Name = "типВагонаToolStripMenuItem";
            this.типВагонаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.типВагонаToolStripMenuItem.Text = "Тип вагона";
            // 
            // маршрутToolStripMenuItem
            // 
            this.маршрутToolStripMenuItem.Name = "маршрутToolStripMenuItem";
            this.маршрутToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.маршрутToolStripMenuItem.Text = "Маршрут";
            this.маршрутToolStripMenuItem.Click += new System.EventHandler(this.маршрутToolStripMenuItem_Click);
            // 
            // поездаToolStripMenuItem
            // 
            this.поездаToolStripMenuItem.Name = "поездаToolStripMenuItem";
            this.поездаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.поездаToolStripMenuItem.Text = "Поезда";
            this.поездаToolStripMenuItem.Click += new System.EventHandler(this.поездаToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Билеты";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem билетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCountry;
        private System.Windows.Forms.ToolStripMenuItem городаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem станцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типВагонаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маршрутToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поездаToolStripMenuItem;
    }
}

