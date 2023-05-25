using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickTestProject.Components
{
    public partial class GraphicButton : UserControl
    {
        public enum MouseStay
        {
            None,
            MouseHover,
            MouseDown
        }

        public GraphicButton()
        {
            InitializeComponent();

            mouseStay = MouseStay.None;

            normalColor = Color.Gray;
            hoverColor = Color.DarkGray;
            pressColor = Color.Gainsboro;
        }

        [Browsable(true)]
        public Color normalColor { get; set; }

        [Browsable(true)]
        public Color hoverColor { get; set; }

        [Browsable(true)]
        public Color pressColor { get; set; }
        
        private MouseStay mouseStay { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color select = normalColor;

            switch (mouseStay)
            {
                case MouseStay.MouseHover:
                    select = hoverColor;
                    break;
                case MouseStay.MouseDown:
                    select = pressColor;
                    break;
            }

            BackColor = select;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            mouseStay = MouseStay.MouseHover;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseStay = MouseStay.MouseDown;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseStay = MouseStay.MouseHover;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseStay = MouseStay.None;
            Invalidate();
        }

        void UsingCustomControl(Control usingThis)
        {

            if (DesignMode)
                return;

            usingThis.MouseEnter += (o, e) => OnMouseEnter(e);
            usingThis.MouseDown += (o, e) => OnMouseDown(e);
            usingThis.MouseUp += (o, e) => OnMouseUp(e);
            usingThis.MouseLeave += (o, e) => OnMouseLeave(e);
        }

    }
}
