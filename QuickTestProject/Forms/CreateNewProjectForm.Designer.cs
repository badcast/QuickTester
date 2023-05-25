namespace QuickTestProject
{
    partial class CreateNewProjectForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.editPath = new System.Windows.Forms.TextBox();
            this.foldeDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.selectDir = new System.Windows.Forms.Button();
            this.editProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editDescribe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.examplePathPrev = new System.Windows.Forms.Label();
            this.permissionInvalid = new System.Windows.Forms.CheckBox();
            this.describeState = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.statusMessage = new System.Windows.Forms.Label();
            this.but_cancel = new QuickTestProject.Components.Button();
            this.but_create = new QuickTestProject.Components.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.but_cancel);
            this.panel1.Controls.Add(this.but_create);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 32);
            this.panel1.TabIndex = 1;
            // 
            // editPath
            // 
            this.editPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editPath.Location = new System.Drawing.Point(12, 351);
            this.editPath.Name = "editPath";
            this.editPath.Size = new System.Drawing.Size(462, 20);
            this.editPath.TabIndex = 2;
            // 
            // selectDir
            // 
            this.selectDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDir.Location = new System.Drawing.Point(480, 349);
            this.selectDir.Name = "selectDir";
            this.selectDir.Size = new System.Drawing.Size(48, 23);
            this.selectDir.TabIndex = 3;
            this.selectDir.Text = "...";
            this.selectDir.UseVisualStyleBackColor = true;
            // 
            // editProjectName
            // 
            this.editProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editProjectName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editProjectName.ForeColor = System.Drawing.Color.DimGray;
            this.editProjectName.Location = new System.Drawing.Point(12, 33);
            this.editProjectName.MaxLength = 48;
            this.editProjectName.Name = "editProjectName";
            this.editProjectName.Size = new System.Drawing.Size(516, 26);
            this.editProjectName.TabIndex = 2;
            this.editProjectName.Text = "Project Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // editDescribe
            // 
            this.editDescribe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editDescribe.Location = new System.Drawing.Point(12, 91);
            this.editDescribe.Multiline = true;
            this.editDescribe.Name = "editDescribe";
            this.editDescribe.Size = new System.Drawing.Size(516, 237);
            this.editDescribe.TabIndex = 5;
            this.editDescribe.Text = "{description}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Описание проекта:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Имя проекта:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Папка проекта:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::QuickTestProject.Properties.Resources.icon_app_backfill;
            this.pictureBox1.Location = new System.Drawing.Point(605, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(605, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quick Tester";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // examplePathPrev
            // 
            this.examplePathPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.examplePathPrev.AutoSize = true;
            this.examplePathPrev.Location = new System.Drawing.Point(12, 376);
            this.examplePathPrev.Name = "examplePathPrev";
            this.examplePathPrev.Size = new System.Drawing.Size(139, 13);
            this.examplePathPrev.TabIndex = 4;
            this.examplePathPrev.Text = "Примерная строка пути:";
            // 
            // permissionInvalid
            // 
            this.permissionInvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.permissionInvalid.AutoSize = true;
            this.permissionInvalid.Location = new System.Drawing.Point(322, 14);
            this.permissionInvalid.Name = "permissionInvalid";
            this.permissionInvalid.Size = new System.Drawing.Size(200, 17);
            this.permissionInvalid.TabIndex = 7;
            this.permissionInvalid.Text = "Использовать ненадежные имена";
            this.permissionInvalid.UseVisualStyleBackColor = true;
            // 
            // describeState
            // 
            this.describeState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.describeState.Location = new System.Drawing.Point(294, 75);
            this.describeState.Name = "describeState";
            this.describeState.Size = new System.Drawing.Size(234, 13);
            this.describeState.TabIndex = 4;
            this.describeState.Text = "Символов: {0}, слов: {1}, строк: {2}";
            this.describeState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.statusMessage);
            this.panel2.Location = new System.Drawing.Point(571, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 47);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::QuickTestProject.Properties.Resources.icon_info;
            this.pictureBox2.Location = new System.Drawing.Point(555, 190);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 28);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // statusMessage
            // 
            this.statusMessage.Location = new System.Drawing.Point(4, 4);
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(158, 43);
            this.statusMessage.TabIndex = 0;
            this.statusMessage.Text = "Info";
            this.statusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_cancel
            // 
            this.but_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_cancel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.but_cancel.HoverColor = System.Drawing.Color.DarkCyan;
            this.but_cancel.Location = new System.Drawing.Point(595, 3);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.NormalColor = System.Drawing.Color.DarkSlateGray;
            this.but_cancel.PressColor = System.Drawing.Color.SlateGray;
            this.but_cancel.Size = new System.Drawing.Size(68, 24);
            this.but_cancel.TabIndex = 0;
            this.but_cancel.Text = "Отмена";
            this.but_cancel.WidthBorder = 2;
            // 
            // but_create
            // 
            this.but_create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_create.BackColor = System.Drawing.Color.Tomato;
            this.but_create.HoverColor = System.Drawing.Color.OrangeRed;
            this.but_create.Location = new System.Drawing.Point(669, 3);
            this.but_create.Name = "but_create";
            this.but_create.NormalColor = System.Drawing.Color.Tomato;
            this.but_create.PressColor = System.Drawing.Color.DarkRed;
            this.but_create.Size = new System.Drawing.Size(68, 24);
            this.but_create.TabIndex = 0;
            this.but_create.Text = "Создать";
            this.but_create.WidthBorder = 2;
            // 
            // CreateNewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 424);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.permissionInvalid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.editDescribe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.examplePathPrev);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.describeState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectDir);
            this.Controls.Add(this.editProjectName);
            this.Controls.Add(this.editPath);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(758, 350);
            this.Name = "CreateNewProjectForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateNewProjectForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Button but_create;
        private System.Windows.Forms.Panel panel1;
        private Components.Button but_cancel;
        private System.Windows.Forms.TextBox editPath;
        private System.Windows.Forms.FolderBrowserDialog foldeDialog;
        private System.Windows.Forms.Button selectDir;
        private System.Windows.Forms.TextBox editProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editDescribe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label examplePathPrev;
        private System.Windows.Forms.CheckBox permissionInvalid;
        private System.Windows.Forms.Label describeState;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label statusMessage;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}