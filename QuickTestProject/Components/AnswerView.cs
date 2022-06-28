using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickTestProject.Components
{
    public partial class AnswerView : UserControl
    {
        public static bool[] vallawer;
        public int index;
        public bool Rechekable { get; set; }
        [Browsable(true)]
        public override string Text { get { return titleAnswer.Text; } set { titleAnswer.Text = value; } }
        bool m_state;
        bool throwIgnore = false;

        public void setAsIncorrect()
        {
            checkedControl.Image = Properties.Resources.icon_correct_red;
        }

        public void setAsCorrect()
        {
            checkedControl.Image = Properties.Resources.icon_correct_green;
        }

        [Browsable(true)]
        public bool Value
        {
            get
            {
                return m_state;
            }
            set
            {
                if (throwIgnore || !Rechekable && m_state)
                    return;
                m_state = value;

                checkedControl.Image = value ? Properties.Resources.checkmark_on : Properties.Resources.checkmark_off;
                throwIgnore = true;
                valueChanged?.Invoke();
                throwIgnore = false;
                if (vallawer != null)
                    vallawer[index] = value;
            }
        }

        public event Explorer.Method1 valueChanged;

        public AnswerView()
        {
            InitializeComponent();
            UsingCustomControl(checkedControl);
            UsingCustomControl(titleAnswer);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Value = !Value;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            titleAnswer.ForeColor = Color.Gray;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            titleAnswer.ForeColor = Color.Black;
        }

        void UsingCustomControl(Control second)
        {
            second.MouseEnter += (o, e) => OnMouseEnter(e);
            second.MouseDown += (o, e) => OnMouseDown(e);
            second.MouseUp += (o, e) => OnMouseUp(e);
            second.MouseLeave += (o, e) => OnMouseLeave(e);
            second.MouseClick += (o, e) => OnClick(e);
        }
    }
}
