namespace QuickTestProject.Components
{
    public partial class EditorProjectExplorer
    {
        private void InitializeComponent()
        {
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.AutoSize = true;
            this.layout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Dock = System.Windows.Forms.DockStyle.Top;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.RowCount = 1;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.Size = new System.Drawing.Size(420, 2);
            this.layout.TabIndex = 1;
            // 
            // EditorProjectExplorer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.layout);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "EditorProjectExplorer";
            this.Size = new System.Drawing.Size(420, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.TableLayoutPanel layout;
    }
}
