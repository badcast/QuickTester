namespace QuickTestProject.Forms
{
    partial class ConfirmationDialog
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yes = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(72, 59);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(218, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Удалить проект с физического диска\r\n";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Подтвердите удаление проекта \"{0}\"?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yes
            // 
            this.yes.BackColor = System.Drawing.Color.Silver;
            this.yes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.yes.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.yes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yes.Location = new System.Drawing.Point(203, 99);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(125, 27);
            this.yes.TabIndex = 8;
            this.yes.Text = "Удалить проект";
            this.yes.UseVisualStyleBackColor = false;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            // 
            // no
            // 
            this.no.BackColor = System.Drawing.Color.Silver;
            this.no.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.no.DialogResult = System.Windows.Forms.DialogResult.No;
            this.no.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.no.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no.Location = new System.Drawing.Point(72, 99);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(125, 27);
            this.no.TabIndex = 8;
            this.no.Text = "Отменить";
            this.no.UseVisualStyleBackColor = false;
            this.no.Click += new System.EventHandler(this.yes_Click);
            // 
            // ConfirmationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(340, 138);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подтверждение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Button no;
    }
}