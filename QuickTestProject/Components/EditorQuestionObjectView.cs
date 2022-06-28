using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickTestProject.Components
{

    public partial class EditorQuestionObjectView : UserControl
    {
        public enum MouseAction
        {
            MouseEnter,
            MouseDown,
            MouseNone
        }

        public enum ReportType
        {
            rprTreatment = 0,
            rprAborted = 1,
            rprSended = 2
        }

        private Color startColor;

        public bool collapse
        {
            get { return !answerContents.Visible; }
            set
            {
                Size sz = Size;
                if (!(answerContents.Visible = !value))
                {
                    sz.Height = MinimumSize.Height;
                }
                else
                {
                    sz.Height = answerContents.Height + MinimumSize.Height;
                }
                Size = sz;

                collapseIcon.Image = value ? Properties.Resources.icon_list_arrow_unpin : Properties.Resources.icon_list_arrow_pin;

                if (MainForm.instance.projectExplorer.count > questionIndex)
                    MainForm.instance.updateAnswers(questionIndex);

                Invalidate();
            }
        }
        public int questionIndex = -1;

        MouseAction mouseStay = MouseAction.MouseNone;
        public bool active
        {
            get { return Explorer.instance.currentProject.getNativeQuestion(questionIndex).active; }
            set
            {
                if (Explorer.instance.currentProject.getNativeQuestion(questionIndex).active == value)
                    return;

                componentState.Image = value ? Properties.Resources.icon_proc_on : Properties.Resources.icon_proc_off;
                Explorer.instance.currentProject.getNativeQuestion(questionIndex).active = value;
                for (int x = 0; x < Controls[0].Controls.Count; ++x)
                    Controls[0].Controls[x].Enabled = value;
            }
        }
        public EditorQuestionObjectView()
        {
            InitializeComponent();

            if (DesignMode)
                return;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);

            startColor = BackColor;

            componentState.MouseUp += (o, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    active = !active;
            };
            collapseIcon.MouseUp += (o, e) =>
            {
                collapse = !collapse;
            };

            but_add_answer.Click += (o, e) =>
            {
                MainForm.instance.updateAnswers(this.questionIndex, "Ответ #" + (MainForm.instance.getAnswersCount(questionIndex) + 1));
                MainForm.instance.updateQuestion(this.questionIndex);
            };

            deleteQuest.Click += (o, e) =>
            {
                const int maxView = 32;
                string qs = Explorer.instance.currentProject.getNativeQuestion(this.questionIndex).question;
                qs = qs.Substring(0, Math.Min(maxView, qs.Length));
                if ((Explorer.instance.currentProject.getNativeQuestion(this.questionIndex).question.Length >= maxView))
                    qs += "...";

                if (MessageBox.Show((IWin32Window)MainForm.instance, string.Format("Удалить \"{0}\"?", qs), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MainForm.instance.updateQuestion(this.questionIndex, true);
                }
            };

            multipleAnswersCheck.CheckedChanged += (o, e) =>
            {
                int x;
                int y;
                int z;
                Question q;
                if (!multipleAnswersCheck.Enabled)
                    return;
                q = Explorer.instance.currentProject.getNativeQuestion(questionIndex);

                EditorAnswerObjectView.try_only_check_cable = true;
                if (multipleAnswersCheck.Checked)
                {
                    //set a multi state

                    //find correct answer

                    //full
                    for (x = 1; x < q.answers.Count; ++x)
                        q.correctAnswers.Add(-1);

                    x = q.correctAnswers[0];
                    q.correctAnswers[x] = x;
                    q.correctAnswers[y = (x != 0 ? 0 : x + 1)] = y;
                }
                else
                {
                    if (q.correctAnswers.Count > 1)
                    {
                        y = ~0;
                        //find correct answer as default
                        for (x = 0; y == -1 && x < q.correctAnswers.Count; ++x)
                            y = q.correctAnswers[x];
                        q.correctAnswers.RemoveRange(1, q.correctAnswers.Count - 1);
                    }
                    else
                        y = q.correctAnswers[0];
                    q.correctAnswers[0] = y == -1 ? 0 : y; // set as default
                }

                for (x = 1; x < answerContents.Controls.Count; ++x)
                {
                    EditorAnswerObjectView v = answerContents.Controls[x] as EditorAnswerObjectView;
                    v.setMultiState(multipleAnswersCheck.Checked);
                }
                MainForm.instance.updateAnswers(questionIndex);
                EditorAnswerObjectView.try_only_check_cable = false;
            };

            ItemLabel.Click += (o, e) =>
            {
                var temp = new TextBox();
                top.Controls.Add(temp);
                temp.Location = ItemLabel.Location;
                temp.Multiline = true;
                temp.Size = ItemLabel.Size;
                temp.BorderStyle = BorderStyle.None;
                temp.Font = ItemLabel.Font;
                temp.BackColor = Color.DarkGray;
                temp.ForeColor = ItemLabel.ForeColor;
                Question q = Explorer.instance.currentProject.getNativeQuestion(this.questionIndex);
                temp.Text = q.question;
                ItemLabel.Visible = false;
                temp.Focus();

                void submit(object o2, EventArgs e2)
                {
                    if (temp == null)
                        return;
                    TextBox _tmp = temp;
                    if (!string.IsNullOrEmpty(temp.Text))
                    {
                        string confirmed = temp.Text;
                        confirmed = confirmed.Replace(Environment.NewLine, " ");
                        confirmed = confirmed.Replace('\n', ' ');
                        q.question = confirmed;
                    }
                    ItemLabel.Visible = true;

                    temp = null;
                    _tmp.Dispose();
                    MainForm.instance.updateQuestion(this.questionIndex);
                }

                temp.KeyDown += (o3, e3) =>
                {
                    if (e3.KeyCode == Keys.Enter)
                        submit(o3, e3);
                };
                temp.Leave += submit;
            };

            UsingCustomControl(ItemLabel);
            UsingCustomControl(ItemDescription);
            UsingCustomControl(top);
            UsingCustomControl(componentState);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            collapse = !collapse;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            return; // ignore color state
            Color color = startColor;
            switch (mouseStay)
            {
                case MouseAction.MouseEnter:
                    color = Color.FromArgb(40, 0, 0, 0);
                    break;
                case MouseAction.MouseDown:
                    color = Color.FromArgb(70, 0, 0, 0);
                    break;
            }

            BackColor = color;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (DesignMode)
                return;

            mouseStay = MouseAction.MouseEnter;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (DesignMode)
                return;

            mouseStay = MouseAction.MouseDown;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (DesignMode)
                return;

            mouseStay = MouseAction.MouseEnter;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (DesignMode)
                return;

            mouseStay = MouseAction.MouseNone;
            this.Invalidate();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
        public void UsingCustomControl(Control second)
        {
            second.MouseEnter += (o, e) => OnMouseEnter(e);
            second.MouseDown += (o, e) => OnMouseDown(e);
            second.MouseUp += (o, e) => OnMouseUp(e);
            second.MouseLeave += (o, e) => OnMouseLeave(e);
            second.MouseClick += (o, e) => OnClick(e);
        }

        private void checkmark_Click(object sender, EventArgs e)
        {
        }
    }
}
