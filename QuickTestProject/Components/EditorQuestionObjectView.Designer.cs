using System.Windows.Forms;
using System.Drawing;

namespace QuickTestProject.Components
{
    partial class EditorQuestionObjectView
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
            this.ItemLabel = new System.Windows.Forms.Label();
            this.ItemDescription = new System.Windows.Forms.Label();
            this.componentState = new System.Windows.Forms.PictureBox();
            this.top = new System.Windows.Forms.Panel();
            this.collapseIcon = new System.Windows.Forms.PictureBox();
            this.deleteQuest = new QuickTestProject.Components.GraphicButton();
            this.answerContents = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.multipleAnswersCheck = new System.Windows.Forms.CheckBox();
            this.but_add_answer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.componentState)).BeginInit();
            this.top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collapseIcon)).BeginInit();
            this.answerContents.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemLabel
            // 
            this.ItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ItemLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ItemLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ItemLabel.Location = new System.Drawing.Point(55, 5);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(327, 28);
            this.ItemLabel.TabIndex = 1;
            this.ItemLabel.Text = "Label";
            // 
            // ItemDescription
            // 
            this.ItemDescription.AutoSize = true;
            this.ItemDescription.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ItemDescription.ForeColor = System.Drawing.Color.DimGray;
            this.ItemDescription.Location = new System.Drawing.Point(58, 35);
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.Size = new System.Drawing.Size(73, 13);
            this.ItemDescription.TabIndex = 2;
            this.ItemDescription.Text = "Description";
            // 
            // componentState
            // 
            this.componentState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.componentState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.componentState.Image = global::QuickTestProject.Properties.Resources.icon_proc_on;
            this.componentState.Location = new System.Drawing.Point(25, 10);
            this.componentState.MaximumSize = new System.Drawing.Size(50, 50);
            this.componentState.Name = "componentState";
            this.componentState.Size = new System.Drawing.Size(25, 27);
            this.componentState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.componentState.TabIndex = 0;
            this.componentState.TabStop = false;
            this.componentState.Click += new System.EventHandler(this.checkmark_Click);
            // 
            // top
            // 
            this.top.BackColor = System.Drawing.Color.Transparent;
            this.top.Controls.Add(this.collapseIcon);
            this.top.Controls.Add(this.deleteQuest);
            this.top.Controls.Add(this.componentState);
            this.top.Controls.Add(this.ItemLabel);
            this.top.Controls.Add(this.ItemDescription);
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(435, 50);
            this.top.TabIndex = 4;
            // 
            // collapseIcon
            // 
            this.collapseIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.collapseIcon.Image = global::QuickTestProject.Properties.Resources.icon_list_arrow_pin;
            this.collapseIcon.Location = new System.Drawing.Point(3, 15);
            this.collapseIcon.Name = "collapseIcon";
            this.collapseIcon.Size = new System.Drawing.Size(17, 17);
            this.collapseIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.collapseIcon.TabIndex = 4;
            this.collapseIcon.TabStop = false;
            // 
            // deleteQuest
            // 
            this.deleteQuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteQuest.BackgroundImage = global::QuickTestProject.Properties.Resources.icon_remove;
            this.deleteQuest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteQuest.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteQuest.hoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteQuest.Location = new System.Drawing.Point(385, 0);
            this.deleteQuest.Margin = new System.Windows.Forms.Padding(0);
            this.deleteQuest.MaximumSize = new System.Drawing.Size(50, 50);
            this.deleteQuest.Name = "deleteQuest";
            this.deleteQuest.normalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteQuest.pressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteQuest.Size = new System.Drawing.Size(50, 50);
            this.deleteQuest.TabIndex = 3;
            // 
            // answerContents
            // 
            this.answerContents.AutoSize = true;
            this.answerContents.BackColor = System.Drawing.Color.Silver;
            this.answerContents.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.answerContents.ColumnCount = 1;
            this.answerContents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.answerContents.Controls.Add(this.panel1, 0, 0);
            this.answerContents.Dock = System.Windows.Forms.DockStyle.Top;
            this.answerContents.ForeColor = System.Drawing.Color.Black;
            this.answerContents.Location = new System.Drawing.Point(0, 50);
            this.answerContents.Name = "answerContents";
            this.answerContents.RowCount = 1;
            this.answerContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.answerContents.Size = new System.Drawing.Size(435, 34);
            this.answerContents.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.multipleAnswersCheck);
            this.panel1.Controls.Add(this.but_add_answer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 26);
            this.panel1.TabIndex = 6;
            // 
            // multipleAnswersCheck
            // 
            this.multipleAnswersCheck.AutoSize = true;
            this.multipleAnswersCheck.BackColor = System.Drawing.Color.Transparent;
            this.multipleAnswersCheck.Dock = System.Windows.Forms.DockStyle.Right;
            this.multipleAnswersCheck.Location = new System.Drawing.Point(270, 0);
            this.multipleAnswersCheck.Name = "multipleAnswersCheck";
            this.multipleAnswersCheck.Size = new System.Drawing.Size(125, 26);
            this.multipleAnswersCheck.TabIndex = 4;
            this.multipleAnswersCheck.Text = "Несколько ответов";
            this.multipleAnswersCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.multipleAnswersCheck.UseVisualStyleBackColor = false;
            // 
            // but_add_answer
            // 
            this.but_add_answer.BackgroundImage = global::QuickTestProject.Properties.Resources.icon_add;
            this.but_add_answer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.but_add_answer.Dock = System.Windows.Forms.DockStyle.Right;
            this.but_add_answer.FlatAppearance.BorderSize = 0;
            this.but_add_answer.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.but_add_answer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.but_add_answer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_add_answer.Location = new System.Drawing.Point(395, 0);
            this.but_add_answer.Name = "but_add_answer";
            this.but_add_answer.Size = new System.Drawing.Size(32, 26);
            this.but_add_answer.TabIndex = 3;
            this.but_add_answer.UseVisualStyleBackColor = true;
            // 
            // QuestionObjectView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.answerContents);
            this.Controls.Add(this.top);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(250, 50);
            this.Name = "QuestionObjectView";
            this.Size = new System.Drawing.Size(435, 84);
            ((System.ComponentModel.ISupportInitialize)(this.componentState)).EndInit();
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collapseIcon)).EndInit();
            this.answerContents.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        public Label ItemLabel;
        public Label ItemDescription;
        public PictureBox componentState;
        private Panel top;
        private GraphicButton deleteQuest;
        private PictureBox collapseIcon;
        private Panel panel1;
        public TableLayoutPanel answerContents;
        private System.Windows.Forms.Button but_add_answer;
        public CheckBox multipleAnswersCheck;
    }

}
