namespace Railway.Forms
{
    partial class UserDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDetailForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkAdmin = new System.Windows.Forms.CheckBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.btSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 260);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(475, 66);
            this.panel3.TabIndex = 6;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(362, 19);
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
            this.btSave.Location = new System.Drawing.Point(251, 19);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkAdmin);
            this.panel1.Controls.Add(this.tbPhone);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbEmail);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbLogin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 260);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(84, 25);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(287, 20);
            this.tbUser.TabIndex = 1;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(84, 65);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(287, 20);
            this.tbLogin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Логин";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(84, 105);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(287, 20);
            this.tbPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пароль";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(84, 145);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(287, 20);
            this.tbEmail.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "E-mail";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(84, 183);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(287, 20);
            this.tbPhone.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Телефон";
            // 
            // checkAdmin
            // 
            this.checkAdmin.AutoSize = true;
            this.checkAdmin.Location = new System.Drawing.Point(84, 223);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(105, 17);
            this.checkAdmin.TabIndex = 11;
            this.checkAdmin.Text = "Администратор";
            this.checkAdmin.UseVisualStyleBackColor = true;
            // 
            // UserDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 326);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserDetailForm";
            this.Text = "Пользователь";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbUser;
        public System.Windows.Forms.TextBox tbLogin;
        public System.Windows.Forms.TextBox tbPassword;
        public System.Windows.Forms.TextBox tbEmail;
        public System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkAdmin;
    }
}