using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickTestProject.Components
{
    public partial class EditorProjectExplorer : UserControl
    {
        public int count { get { return layout.Controls.Count; } }

        public EditorQuestionObjectView get(int index)
        {
            return layout.Controls[index] as EditorQuestionObjectView;
        }

        public EditorProjectExplorer()
        {
            InitializeComponent();
        }
        public bool RemoveItem(int indexItem)
        {
            Components.EditorQuestionObjectView qo = layout.Controls[indexItem] as Components.EditorQuestionObjectView;
            layout.Controls.RemoveAt(indexItem);
            layout.RowStyles.Clear();
            Invalidate();
            return true;
        }
        public void RemoveAll(bool destroy)
        {
            layout.Controls.Clear();
            Invalidate();
        }

        public bool AddItem(EditorQuestionObjectView item)
        {
            if (item == null)
                return false;

            var control = item;
            control.Dock = DockStyle.Fill;
            layout.Controls.Add(control, 0, layout.Controls.Count);
            return true;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
