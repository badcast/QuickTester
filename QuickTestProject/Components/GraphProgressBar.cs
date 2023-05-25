using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace QuickTestProject.Components
{
    public partial class GraphProgressBar : UserControl
    {
        public GraphProgressBar()
        {
            this.BackColor   = Color.DarkGray;
            this.BorderColor = Color.Black;
            this.BorderWidth = 1F;
            this.FillColor   = Color.Cyan;
            this.HandleColor = Color.Gray;
            this.HandleWidth = 2;
            this.MaxValue    = 100;
            this.MinValue    = 0;
            this.Value       = MaxValue;
            HandleColor      = Color.Gray;
            HandleWidth      = 1;
            FillColor        = Color.White;
            brush            = new SolidBrush(FillColor);
            PenDraw          = new Pen(BorderColor, BorderWidth);

            InitializeComponent();
        }
        #region Свойство Ползунка
        private Color _handleColor;
        [Browsable(true)]
        public Color HandleColor
        {
            get
            {
                return _handleColor;
            }
            set
            {
                _handleColor = value;
                Invalidate();
            }
        }

        private int _handleWidth;
        [Browsable(true)]
        public int HandleWidth
        {
            get
            {
                return _handleWidth;
            }
            set
            {
                _handleWidth = value;
                Invalidate();
            }
        }

        private Color _fillColor;
        [Browsable(true)]
        public Color FillColor
        {
            get
            {
                return _fillColor;
            }
            set
            {
                _fillColor = value;
                Invalidate();
            }
        }

        private Color _borderColor;
        [Browsable(true)]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        private float _borderWidth;
        [Browsable(true)]
        public float BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public Pen PenDraw { get; set; }

        private int _value;
        [Browsable(true)]
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                value = value > MaxValue ? MaxValue : value < MinValue ? MinValue : value;

                if (_value == value)
                    return;

                _value = value;
                Invalidate();
            }
        }

        private int _mxValue;
        [Browsable(true)]
        public int MaxValue
        {
            get
            {
                return _mxValue;
            }
            set
            {
                _mxValue = value;
                if (Value > value)
                    Value = value;
                Invalidate();
            }
        }

        private int _minValue;
        [Browsable(true)]
        public int MinValue
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
                if (Value < value)
                    Value = value;
                Invalidate();
            }
        }
#endregion

        private SolidBrush brush;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int xPos = ((Width - MinValue) * Value / MaxValue) + MinValue;


            //Draw FILL
            brush.Color = FillColor;
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, xPos, Height));

            //Draw Handle
            brush.Color = HandleColor;
            e.Graphics.FillRectangle(brush, new Rectangle(xPos - HandleWidth / 2, 0, HandleWidth, Height));

            //Draw Rect
            PenDraw.Color = BorderColor;
            PenDraw.Width = BorderWidth;
            e.Graphics.DrawRectangle(PenDraw, new Rectangle(0, 0, Width-1, Height-1));
        }
    }
}
