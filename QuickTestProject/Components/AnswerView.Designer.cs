namespace QuickTestProject.Components
{
    partial class AnswerView
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleAnswer = new System.Windows.Forms.Label();
            this.checkedControl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.checkedControl)).BeginInit();
            this.SuspendLayout();
            // 
            // titleAnswer
            // 
            this.titleAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleAnswer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titleAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleAnswer.Location = new System.Drawing.Point(44, 0);
            this.titleAnswer.Name = "titleAnswer";
            this.titleAnswer.Size = new System.Drawing.Size(241, 32);
            this.titleAnswer.TabIndex = 0;
            this.titleAnswer.Text = "label1";
            this.titleAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkedControl
            // 
            this.checkedControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkedControl.Image = global::QuickTestProject.Properties.Resources.checkmark_off;
            this.checkedControl.Location = new System.Drawing.Point(5, 0);
            this.checkedControl.Name = "checkedControl";
            this.checkedControl.Size = new System.Drawing.Size(33, 32);
            this.checkedControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.checkedControl.TabIndex = 1;
            this.checkedControl.TabStop = false;
            // 
            // AnswerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkedControl);
            this.Controls.Add(this.titleAnswer);
            this.Name = "AnswerView";
            this.Size = new System.Drawing.Size(285, 32);
            ((System.ComponentModel.ISupportInitialize)(this.checkedControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleAnswer;
        private System.Windows.Forms.PictureBox checkedControl;
    }
}
