using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickTestProject.Components
{
    public partial class Button : UserControl
    {
        
        public Button()
        {
            WidthBorder = 2;
            NormalColor = Color.Gray;
            HoverColor = Color.LightGray;
            PressColor = Color.Black;
            pen = new Pen(Color.Black, WidthBorder);
            
            InitializeComponent();
            Text = this.Name;
            UsingCustomControl(TextControl);
        }

        [Browsable(true)]
        public override Font Font
        {
            get
            {
                return TextControl.Font;
            }
            set
            {
                TextControl.Font = value;
            }
        }

        [Browsable(true)]
        public override string Text
        {
            get
            {
                return TextControl.Text;
            }

            set
            {
                TextControl.Text = value;
            }
        }

        [Browsable(true)]
        public int WidthBorder { get; set; }

        private Color _normalColor;
        [Browsable(true)]
        public Color NormalColor
        {
            get
            {
                return _normalColor;
            }
            set
            {
                if (_normalColor == value)
                    return;

                _normalColor = value;
                Invalidate();
            }
        }

        private Color _hoverColor;
        [Browsable(true)]
        public Color HoverColor
        {
            get
            {
                return _hoverColor;
            }
            set
            {
                if (_hoverColor == value)
                    return;

                _hoverColor = value;
                Invalidate();
            }
        }

        private Color _pressColor;
        [Browsable(true)]
        public Color PressColor
        {
            get
            {
                return _pressColor;
            }
            set
            {
                if (_pressColor == value)
                    return;

                _pressColor = value;
                Invalidate();
            }
        }

        private GraphicButton.MouseStay mouseStay { get; set; }
        private Pen pen;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color select = NormalColor;
            Color textColor = Color.White;
            switch (mouseStay)
            {
                case GraphicButton.MouseStay.MouseHover:
                    select = HoverColor;
                    break;
                case GraphicButton.MouseStay.MouseDown:
                    select = PressColor;
                    textColor = HoverColor;
                    break;
            }
  
            TextControl.ForeColor = textColor;
            BackColor = select;

            pen.Width = WidthBorder;
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width, Height));
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            mouseStay = GraphicButton.MouseStay.MouseHover;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseStay = GraphicButton.MouseStay.MouseDown;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseStay = GraphicButton.MouseStay.MouseHover;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseStay = GraphicButton.MouseStay.None;
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
            usingThis.Click += (o, e) => OnClick(e);
        }
    }
}
