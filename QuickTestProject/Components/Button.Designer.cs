namespace QuickTestProject.Components
{
    partial class Button
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
            this.TextControl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextControl
            // 
            this.TextControl.BackColor = System.Drawing.Color.Transparent;
            this.TextControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextControl.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextControl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TextControl.Location = new System.Drawing.Point(0, 0);
            this.TextControl.Margin = new System.Windows.Forms.Padding(0);
            this.TextControl.Name = "TextControl";
            this.TextControl.Size = new System.Drawing.Size(100, 50);
            this.TextControl.TabIndex = 0;
            this.TextControl.Text = "Button";
            this.TextControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TextControl);
            this.Name = "Button";
            this.Size = new System.Drawing.Size(100, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TextControl;
    }
}
