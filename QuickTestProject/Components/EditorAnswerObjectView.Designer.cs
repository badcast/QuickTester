namespace QuickTestProject.Components
{
    partial class EditorAnswerObjectView
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
            this.deleteAnswer = new QuickTestProject.Components.GraphicButton();
            this.SuspendLayout();
            // 
            // deleteQuest
            // 
            this.deleteAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteAnswer.BackgroundImage = global::QuickTestProject.Properties.Resources.icon_remove;
            this.deleteAnswer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteAnswer.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteAnswer.hoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteAnswer.Location = new System.Drawing.Point(131, 0);
            this.deleteAnswer.Margin = new System.Windows.Forms.Padding(0);
            this.deleteAnswer.MaximumSize = new System.Drawing.Size(50, 50);
            this.deleteAnswer.Name = "deleteQuest";
            this.deleteAnswer.normalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteAnswer.pressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteAnswer.Size = new System.Drawing.Size(32, 32);
            this.deleteAnswer.TabIndex = 4;
            // 
            // AnswerObjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.deleteAnswer);
            this.MinimumSize = new System.Drawing.Size(0, 32);
            this.Name = "AnswerObjectView";
            this.Size = new System.Drawing.Size(163, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private GraphicButton deleteAnswer;
    }
}
