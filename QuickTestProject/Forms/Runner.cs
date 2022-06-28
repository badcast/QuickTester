using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickTestProject.Components;

namespace QuickTestProject
{
    public partial class Runner : Form
    {
        public class RunnerResult
        {
            public int incorrectlyAnswered;
            public int correctlyAnswered;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        extern static int GetSystemMetrics(int TYPE);
        static Question example = new Question() { active = true, answers = new List<string> { "Это большой ответ 1", "Это большой ответ 2" }, correctAnswers = new List<int> { 0, 1 }, question = "Где баран?" };


        Question[] questions;// = new Question[] { example, example, example, example, example };
        bool[][] userAnswers; // answererd
        Timer timer;
        int time;
        int m_index = 0;
        string nextText;
        bool asPreview;
        List<System.Windows.Forms.Button> mButtons = new List<System.Windows.Forms.Button>();
        public int index
        {
            get
            {
                return m_index;
            }
            set
            {
                mButtons[value].Focus();
                mButtons[m_index].Enabled = true;
                mButtons[value].Enabled = false;
                butPrev.Visible = butHSLeft.Enabled = value > 0;
                butHSRight.Enabled = value < mButtons.Count - 1;
                if (!butHSRight.Enabled)
                {
                    butNext.Text = "Завершить   ";
                }
                else
                {
                    butNext.Text = nextText;
                }
                m_index = value;
                drawQuestion();
            }
        }

        public PreviewDocument resultPreview;

        MenuItem menuFullscritem = new MenuItem("Полноэкранный режим")
        {
            Checked = false,
            Shortcut = Shortcut.F11
        };

        void updateTextTime()
        {
            string tm = (time / 60).ToString();
            tm += ":" + time % 60;
            timeLabel.Text = tm;
        }

        void loadEnd(bool timeEof)
        {
            asPreview = true;
            if (timeEof)
            {
                timer.Dispose();
                time = 0;
            }
            else
            {
                labelTimeResult.Text = "Тест завершен";
            }

            for (int i = 0; i < Controls.Count; i++)
                Controls[i].Visible = false;
            lostOfATime.Visible = true;
            eofTimePanel.Controls.Add(butResult);
            eofTimePanel.Controls.Add(butEofEnd);
            eofTimePanel.Visible = true;

            butEofEnd.Visible = true;
            butResult.Visible = true;
            butResult.Dock = DockStyle.Bottom;
            butEofEnd.Dock = DockStyle.Bottom;
        }

        void init_profile(Explorer.Profile profile)
        {
            Text += " - " + profile.name;
            if (profile.times <= 0 || profile.mode == Explorer.ProfileMode.unlimit)
                timeLabel.Text = "∞:∞";
            else
            {
                timer = new Timer();
                time = profile.times * 60 - 1;
                timer.Interval = 1000; // 1second
                //a time
                timer.Tick += (o, e) =>
                {
                    updateTextTime();
                    //subtract a 1 second
                    if (time-- <= 0)
                        loadEnd(true);
                };
                timer.Start();
                updateTextTime();
            }
        }

        void fullscreen(bool fs)
        {
            if (!fs)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            menuFullscritem.Checked = fs;
        }

        public Runner()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Icon = MainForm.instance.Icon;
        }

        void init()
        {
            top.HorizontalScroll.Visible = true;
            top.HorizontalScroll.Enabled = false;
            top.Height += GetSystemMetrics(21);
            nextText = butNext.Text;
            void prev(object o, EventArgs e)
            {
                if (index > 0)
                    --index;
            }

            void next(object o, EventArgs e)
            {
                if (index < mButtons.Count - 1)
                    ++index;
            }

            this.KeyUp += (o, e) =>
            {
                if (e.KeyCode == Keys.Left)
                    prev(o, e);
                else if (e.KeyCode == Keys.Right)
                    next(o, e);
            };

            butHSLeft.Click += prev;
            butHSRight.Click += next;

            butEofEnd.Visible = false;
            butResult.Visible = false;
            butResult.Click += (o, e) =>
            {
                lostOfATime.Visible = false;
                Controls[0].Visible = true;
                Controls[1].Visible = true;
                AnswerView.vallawer = null;
                index = 0;
            };
            butPrev.Click += prev;
            butNext.Click += (o, e) =>
            {
                if (index < mButtons.Count - 1)
                    next(o, e);
                else
                    this.Close();
            };

            butEofEnd.Click += (o, e) =>
            {
                this.Close();
            };

            this.FormClosing += (o, e) =>
            {
                bool isNotanswered = false;
                int indexOf = -1;

                if (asPreview || timer != null && time <= 0)
                    return;
                e.Cancel = true;

                //Check a not answered and confirm continue 
                for (int x = 0; !isNotanswered && x < userAnswers.Length; ++x)
                    if (!(isNotanswered = userAnswers[indexOf = x] == null))
                        isNotanswered = userAnswers[x].All((f) => !f);

                if (isNotanswered)
                {
                    if (MessageBox.Show(this, "Есть вопросы оставленные без внимания. Вы уверены, что хотите продолжить? \n\n\tПропущенные ответы не засчитаются.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        index = indexOf;
                        return;
                    }
                }

                //end of a test
                loadEnd(false);
            };

            this.FormClosed += (o, e) =>
            {
                timer?.Dispose(); // free a time
                AnswerView.vallawer = null;
            };

            prototypeButton = content.Controls[0] as System.Windows.Forms.Button;
            focusedFont = new Font(prototypeButton.Font, FontStyle.Underline | FontStyle.Bold);
            if (!asPreview)
                userAnswers = new bool[questions.Length][];


            MainMenu m = new MainMenu();
            this.Menu = m;
            MenuItem view = new MenuItem();
            view.Text = "Вид";
            menuFullscritem.Click += (o, e) =>
            {
                fullscreen(menuFullscritem.Checked = !menuFullscritem.Checked);
            };

            view.MenuItems.Add(menuFullscritem);
            m.MenuItems.Add(view);
            eofTimePanel.Visible = false;

            createButtons();
            index = 0;
        }

        System.Windows.Forms.Button prototypeButton;
        Font focusedFont;
        void createButtons()
        {
            int x;
            mButtons.Clear();
            content.Controls.Clear();
            for (x = 0; x < questions.Length; ++x)
            {
                var but = new System.Windows.Forms.Button();
                int y = x;

                but.Size = prototypeButton.Size;
                but.Text = (1 + x).ToString();
                but.Dock = prototypeButton.Dock;
                but.BackColor = prototypeButton.BackColor;
                but.ForeColor = prototypeButton.ForeColor;
                but.FlatStyle = prototypeButton.FlatStyle;
                but.FlatAppearance.BorderSize = prototypeButton.FlatAppearance.BorderSize;
                but.FlatAppearance.BorderColor = prototypeButton.FlatAppearance.BorderColor;
                but.FlatAppearance.CheckedBackColor = prototypeButton.FlatAppearance.CheckedBackColor;
                but.FlatAppearance.MouseOverBackColor = prototypeButton.FlatAppearance.MouseOverBackColor;
                but.FlatAppearance.MouseDownBackColor = prototypeButton.FlatAppearance.MouseDownBackColor;
                but.Font = prototypeButton.Font;
                but.MinimumSize = but.Size;
                but.Click += (o, e) =>
                {
                    index = y;
                };
                but.EnabledChanged += (o, e) =>
                {
                    if (but.Enabled)
                    {
                        but.Font = prototypeButton.Font;
                        but.BackColor = prototypeButton.BackColor;
                    }
                    else
                    {
                        but.Font = focusedFont;
                        but.BackColor = Color.DarkGray;
                    }
                };
                mButtons.Add(but);
                content.Controls.Add(but);
            }
        }

        Color colorCorrect = Color.FromArgb(128, 80, 240, 58), colorIncorrect = Color.FromArgb(128, 243, 83, 83);
        void drawQuestion()
        {
            int x, y;
            bool w = false;
            bool multiSelection = questions[index].correctAnswers.Count > 1;

            label1.Text = (index + 1) + ". " + questions[index].question;
            if (!asPreview)
            {
                labelSelectInfo.Text = (multiSelection ?
                    "Выберите несколько вариантов ответа:" : "Выберите один вариант ответа:");
                //dynamic create array
                if (userAnswers[index] == null || questions[index].answers.Count != userAnswers[index].Length)
                    userAnswers[index] = new bool[questions[index].answers.Count];

                AnswerView.vallawer = userAnswers[index]; // set as global param
            }
            else
            {
                //question is skipped ?
                w = userAnswers[index] == null || userAnswers[index].All(f => !f);
            }

            //initalize selectors 
            for (x = answersContent.Controls.Count; x < questions[index].answers.Count; ++x)
            {
                var sel = new Components.AnswerView();
                sel.Dock = DockStyle.Top;
                sel.Height = 32;
                sel.Enabled = !asPreview;
                if (!asPreview)
                {
                    //select a answer value
                    sel.Click += (o, e) =>
                    {
                        if (mButtons[this.index].Text.LastIndexOf("*") == -1)
                        {
                            mButtons[this.index].Text += "\n*";
                            mButtons[this.index].FlatAppearance.BorderSize = 1;
                        }
                        if (questions[index].correctAnswers.Count == 1)
                        {
                            for (int z = 0; z < questions[index].answers.Count; ++z)
                            {
                                var chex = answersContent.Controls[z] as AnswerView;

                                if (chex != sel)
                                {
                                    bool lst = chex.Rechekable;
                                    chex.Rechekable = true;
                                    chex.Value = false;
                                    chex.Rechekable = lst;
                                }
                            }
                        }
                        else
                        {
                            sel.Rechekable = true;
                        }

                    };
                }
                answersContent.Controls.Add(sel);
            }

            //draw selectors
            for (x = 0, y = 0; x < questions[index].answers.Count; ++x)
            {
                var answer = answersContent.Controls[x] as AnswerView;
                answer.Visible = true;
                answer.Text = questions[index].answers[x];
                answer.Enabled = !asPreview;
                if (!asPreview)
                {
                    answer.index = x;
                    bool lst = answer.Rechekable;
                    answer.Rechekable = true;
                    answer.Value = userAnswers[index][x];
                    answer.Rechekable = lst;
                }
                else
                {
                    // Red - user select and incorrect
                    // Green - Correct select
                    answer.Rechekable = true;
                    answer.BackColor = BackColor;
                    answer.Value = false;

                    //current stay
                    bool correctAnswer = x == (multiSelection ? questions[index].correctAnswers[x] : questions[index].correctAnswers[0]);

                    //User question skipped
                    if (w)
                    {
                        //set as RED 
                        if (correctAnswer)
                        {
                            answer.setAsIncorrect();
                        }
                    }
                    else // user selected state
                    {
                        //user select an answer
                        if (userAnswers[index][x])
                        {
                            if (correctAnswer)
                            {
                                ++y;
                                answer.setAsCorrect();
                                answer.BackColor = colorCorrect;
                            }
                            else
                            {
                                --y;
                                answer.setAsCorrect();
                                answer.BackColor = colorIncorrect;
                            }
                        }
                        else
                        {
                            if (correctAnswer)
                            {
                                answer.setAsIncorrect();
                            }
                            else // the default state (is empty)
                                answer.Value = false;
                        }
                    }
                }
            }

            if (asPreview)
            {
                string tmp;
                Color cc;
                if (y == questions[index].correctAnswers.Count((f) => f != -1))
                {
                    tmp = "Верно";
                    cc = colorCorrect;
                }
                else if (questions[index].correctAnswers.Count > 1 && y > 1)
                {
                    tmp = "Близко";
                    cc = colorIncorrect;
                }
                else
                {
                    tmp = "Не верно";
                    cc = colorIncorrect;
                }
                labelSelectInfo.Text = tmp;
                labelSelectInfo.BackColor = cc;
            }

            //hide unallow selectors
            for (; x < answersContent.Controls.Count; ++x)
            {
                var obj = answersContent.Controls[x] as AnswerView;
                obj.Visible = false;
            }

        }

        public void showAsPreview(PreviewDocument previewDocument, bool fullscreen)
        {
            this.questions = previewDocument.questions;
            this.userAnswers = previewDocument.userAnswers;
            this.asPreview = true;
            pictureBox1.Visible = false;
            Text = previewDocument.name;
            timeLabel.Text = "Просмотр";
            init();
            this.fullscreen(fullscreen);

            this.Show();
        }

        public PreviewDocument show(Explorer.Profile profile, Question[] questions, bool fullscreen)
        {
            DialogResult result;
            this.questions = questions;
            this.asPreview = false;
            resultPreview = new PreviewDocument();
            resultPreview.writedTime = DateTime.Now;
            init();
            init_profile(profile);
            this.fullscreen(fullscreen);
            result = this.ShowDialog();
            resultPreview.name = "Результат тестирование за " + resultPreview.writedTime.ToString();
            resultPreview.questions = questions;
            resultPreview.userAnswers = this.userAnswers;
            return resultPreview;
        }
    }
}
