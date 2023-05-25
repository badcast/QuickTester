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
    public partial class EditorAnswerObjectView : UserControl
    {
        static bool can_check_radio = true;
        public static bool try_only_check_cable;

        Components.EditorQuestionObjectView owner;
        bool inited;
        Control checkedControl;

        public int answerIndex;

        public EditorAnswerObjectView()
        {
            InitializeComponent();

        }

        void setControl(object o, EventArgs e)
        {
            const int region = 22;
            if (!Enabled || region > PointToClient(MousePosition).X)
                return;
            TextBox temp = new TextBox();
            temp.BorderStyle = BorderStyle.None;
            temp.BackColor = Color.DarkGray;
            temp.Left = region;
            temp.Top = 11;
            temp.Text = checkedControl.Text;
            temp.Size = checkedControl.Size;
            temp.Font = checkedControl.Font;
            temp.ForeColor = checkedControl.ForeColor;
            Controls.Add(temp);
            temp.Focus();
            checkedControl.Width = region;
            checkedControl.Dock = DockStyle.Left;

            void submit(object o2, EventArgs e2)
            {
                if (temp == null)
                    return;
                TextBox _tmp = temp;
                EditorQuestionObjectView qo = this.Parent.Parent as EditorQuestionObjectView;
                if (!string.IsNullOrEmpty(_tmp.Text))
                    Explorer.instance.currentProject.getNativeQuestion(qo.questionIndex).answers[answerIndex] =
                    checkedControl.Text = temp.Text;
                checkedControl.Dock = DockStyle.Fill;
                temp = null;
                _tmp.Dispose();
            }

            temp.KeyDown += (o3, e3) =>
            {
                if (e3.KeyCode == Keys.Enter)
                    submit(o3, e3);
            };
            temp.Leave += submit;
        }

        void autoCheckBox(CheckBox cb)
        {
            Project cp = Explorer.instance.currentProject;
            Question q = cp.getNativeQuestion(owner.questionIndex);
            q.correctAnswers[answerIndex] = (cb.Checked ? answerIndex : -1);

            // cancel a multi state 
            if (q.correctAnswers.Count((x => x != -1))==1)
                owner.multipleAnswersCheck.Checked = false;
        }

        void autoCheckRadio(RadioButton rb)
        {
            int x;

            if (rb == null || !can_check_radio)
                return;
            Project cp = Explorer.instance.currentProject;
            Question q = cp.getNativeQuestion(owner.questionIndex);
            var cc = owner.answerContents.Controls;
            can_check_radio = false;
            for (x = 1; x < cc.Count; ++x)
            {
                RadioButton rx = cc[x].Controls[1] as RadioButton;// as RadioButton;
                if (rx != null && (rx.Checked = rb == rx))
                {
                    q.correctAnswers[0] = answerIndex;
                }
            }
            can_check_radio = true;
        }

        public void setCheck(bool val)
        {
            RadioButton rb;
            CheckBox cb;
            if ((rb = checkedControl as RadioButton) != null)
            {
                rb.Checked = val;
            }
            else if ((cb = checkedControl as CheckBox) != null)
            {
                cb.Checked = val;
            }
        }

        public void setMultiState(bool multistate)
        {
            Control lastControl = checkedControl;
            Control newControl = null;
            Question q = Explorer.instance.currentProject.getNativeQuestion(owner.questionIndex);

            if (multistate)
            {
                RadioButton rb = checkedControl as RadioButton;
                if (rb != null)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = rb.Text;
                    cb.Checked = rb.Checked;
                    cb.CheckedChanged += (o, e) => autoCheckBox(cb);
                    newControl = cb;
                }
            }
            else
            {
                CheckBox cb = checkedControl as CheckBox;
                if (cb != null)
                {
                    RadioButton rb = new RadioButton();
                    rb.Text = cb.Text;
                    if (rb.Checked = cb.Checked && try_only_check_cable)
                        try_only_check_cable = false;
                    rb.CheckedChanged += (o, e) => autoCheckRadio(rb);
                    newControl = rb;
                }

            }

            if (newControl != null)
            {
                checkedControl = newControl;
                checkedControl.Cursor = Cursors.IBeam;
                checkedControl.Click += setControl;
                Controls.Remove(lastControl);
                Controls.Add(newControl);
                newControl.Dock = lastControl.Dock;
                lastControl.Dispose();
            }
        }

        public void set(EditorQuestionObjectView parent, string value, bool check, int answerIndex, bool isMultichecks = false)
        {
            Control lastControl = checkedControl;
            bool created = false;
            owner = parent;
            this.answerIndex = answerIndex;

            if (isMultichecks)
            {
                CheckBox cb = checkedControl as CheckBox;
                if (cb == null)
                {
                    cb = new CheckBox();
                    created = true;
                    cb.CheckedChanged += (o, e) => autoCheckBox(cb);
                }
                if (value != null)
                    cb.Text = value;
                cb.Checked = check;
                checkedControl = cb;
            }
            else
            {
                RadioButton rb = checkedControl as RadioButton;
                if (rb == null)
                {
                    rb = new RadioButton();
                    rb.CheckedChanged += (o, e) => autoCheckRadio(rb);
                    created = true;
                }
                if (value != null)
                    rb.Text = value;
                rb.Checked = check;
                checkedControl = rb;
            }

            if (created)
            {
                checkedControl.Cursor = Cursors.IBeam;
                if (lastControl != null)
                {
                    Controls.Remove(lastControl);
                    lastControl.Dispose();
                }
                checkedControl.Click += setControl;
                Controls.Add(checkedControl);
                checkedControl.Dock = DockStyle.Fill;
                if (!inited)
                {
                    deleteAnswer.Click += (o, e) =>
                    {
                        MainForm.instance.updateAnswer(owner.questionIndex, this.answerIndex, true);
                    };
                    inited = true;
                }
            }

        }
    }
}
