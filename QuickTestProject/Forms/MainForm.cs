using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuickTestProject
{
    public partial class MainForm : Form
    {
        public static MainForm instance;
        public static string captionFormat = "";

        string formatRunProfTest0;
        string formatRunProfTest1;
        string formatMenuItemPRev0;
        string formatMenuItemPRev1;

        string tabPage3Caption;
        string formatStats;
        Timer timer;

        bool canFocusProject = true;
        bool canChangeQuests = true;
        bool canDrawableProject = true;
        bool canUpdateStatsOne = true;

        public Explorer explorer;
        public MainForm()
        {
            instance = this;
            InitializeComponent();
            formatStats = label_stats.Text;
            label_stats.Text = "";
            this.Menu = mainMenu;

            if (DesignMode)
                return;

            formatRunProfTest0 = menu_run_test.Text;
            formatRunProfTest1 = menu_run_test_fullscreen.Text;
            formatMenuItemPRev0 = toolStripMenuItem9.Text;
            formatMenuItemPRev1 = toolStripMenuItem5.Text;


            captionFormat = Text + " - {0}";
            explorer = new Explorer(this);
            message("");

            previewList.Groups.Clear();
            previewList.Groups.Add(new ListViewGroup("Сегодня"));
            _groups = new List<DateTime>() { DateTime.Today };

            infoX_init();

            editDescribeInfoX.TextChanged += (o, e) =>
            {
                explorer.currentProject.description = editDescribeInfoX.Text;
            };

            this.оПрограммеMenuItem.Click += (o, e) =>
            {
                new About().ShowDialog(this);
            };

            FormClosing += (o, e) =>
            {
                Project[] projects;
                if (explorer.requireSave(out projects))
                {
                    if (Explorer.projectConfiguration.autoSave)
                    {
                        autosave(false);
                        explorer.saveAll(true);
                    }
                    else
                    {
                        string strongMsg;
                        if (projects.Length > 0)
                            strongMsg = String.Format("Вы хотите сохранить изменения в проекте \n\"{0}\"?", projects[0].name);
                        else
                            strongMsg = "Вы хотите сохранить изменения всех проектов?";

                        DialogResult dr = MessageBox.Show(this, strongMsg,
                            "Сохранение как..", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                for (int i = 0; i < projects.Length; i++)
                                {
                                    if (string.IsNullOrEmpty(projects[i].filename))
                                        explorer.saveProjectAsDlg(projects[i]);
                                    else
                                        explorer.saveProject(projects[i]);
                                }
                                break;
                            case DialogResult.Cancel:
                                e.Cancel = true;
                                break;
                        }
                    }
                }
            };
            FormClosed += (o, e) =>
            {
                explorer.queryQuit();
            };

            combobox_projectListSel.SelectedIndexChanged += (o, e) =>
            {
                if (canFocusProject)
                    explorer.focusProject_internal(combobox_projectListSel.SelectedIndex);
            };

            explorer.onProjectFocusChanged += (l, n) =>
            {
                bool lst = canFocusProject;
                canFocusProject = false;
                combobox_projectListSel.SelectedIndex = explorer.currentProjectIndex;
                drawProject(n);
                canFocusProject = lst;
            };

            hideNumberQuests.CheckedChanged += (o, e) =>
            {
                Explorer.projectConfiguration.hideNumberQuests = hideNumberQuests.Checked;
                updateQuestions();
            };
            hideDisallowQuest.CheckedChanged += (o, e) =>
            {
                Explorer.projectConfiguration.hideDisallowQuests = hideDisallowQuest.Checked;
                updateQuestions();
            };
            contextMenuView.Click += (o, e) =>
            {
                Point p = (Point)contextMenuView.Size;
                p.X = 0;
                contextMenuView.ContextMenuStrip.Show((Control)o, p);
            };

            //can focus project
            canDrawableProject = false;

            explorer.init();

            explorer.onProjectListChanged += updateProjectList;
            tabPage3Caption = tabPage3.Text;
            canChangeQuests = false;
            hideDisallowQuest.Checked = Explorer.projectConfiguration.hideDisallowQuests;
            hideNumberQuests.Checked = Explorer.projectConfiguration.hideNumberQuests;
            canChangeQuests = true;
            canDrawableProject = true;
            createEdit(infoX_projectName);

            if (Explorer.projectConfiguration.firstRun && Explorer.projects.Count == 0)
            {
                Explorer.projectConfiguration.firstRun = false;
                explorer.createNewProject();
            }

            previewList.Items.Clear();

            updateProjectList();

            explorer.onPreviewDocumentListChanged += updatePreviews;

            //check autosaver
            autosave(autosaveMenuItem.Checked = Explorer.projectConfiguration.autoSave);
            autosaveMenuItem.Click += (o, e) =>
            {
                autosave(Explorer.projectConfiguration.autoSave = autosaveMenuItem.Checked = !autosaveMenuItem.Checked);
            };

            pages.SelectedIndexChanged += (o, e) =>
            {
                if (pages.SelectedTab == tabPage3)
                    updateQuestions();
            };


            this.WindowState = FormWindowState.Maximized;
            return;
            int j, x, y, w;
            y = 0;
            using (var sr = new StreamReader(File.Open(@"C:\Users\badcast\Desktop\Новый текстовый документ.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                Project project = Explorer.createEmptyProject();
                List<Question> questions = project.model.questions;
                char[] filter = new[] { '2', '3', '4', '5', '6', '7', '8', '9', '1', '0', '.', ' ' };
                string[] lines = new string[32];
                while (!sr.EndOfStream)
                {
                    Question q = new Question();
                    string line;
                    j = 0;
                    w = -1;
                    do
                    {
                        line = sr.ReadLine().TrimStart().TrimStart(filter).TrimEnd();
                        y++; // lines
                        if (line.Length == 0)
                            continue;
                        if (line.StartsWith("*") || sr.EndOfStream)
                            break;

                        x = line.LastIndexOf("//");
                        if (x != -1)
                            line = line.Remove(x, line.Length - x);
                        x = line.IndexOf('+');
                        if (x != -1)
                        {
                            w = j - 1;
                            line = line.Remove(x, 1);
                        }
                        lines[j++] = line;

                    } while (!sr.EndOfStream);
                    if (w == -1)
                    {
                        throw new Exception("Нет правильного ответа, что-то надо с этим делать");
                    }
                    q.question = lines[0];
                    q.answers = new List<string>();
                    for (x = 1; x < j; ++x)
                        q.answers.Add(lines[x]);
                    q.correctAnswers = new List<int>();
                    q.correctAnswers.Add(w);
                    questions.Add(q);
                }
                explorer.registerProjectInRuntime(project);
            }

        }

        List<DateTime> _groups;
        public void updatePreviews()
        {
            int x, y;
            ListViewItem lst;

            tabPage4.Text = Explorer.previews.Count > 0 ? "Результаты" : "Результаты (пусто)";

            for (x = previewList.Items.Count; x < Explorer.previews.Count; ++x)
            {
                lst = new System.Windows.Forms.ListViewItem(Explorer.previews[x].data.name, -1);
                lst.StateImageIndex = 0;
                y = _groups.IndexOf(Explorer.previews[x].data.writedTime.Date);
                if (y == -1)
                {
                    _groups.Add(Explorer.previews[x].data.writedTime.Date);
                    previewList.Groups.Add(new ListViewGroup(Explorer.previews[x].data.writedTime.ToShortDateString()));
                }
                previewList.Items.Add(lst);
            }

            //update preview info
            for (x = 0; x < Explorer.previews.Count; ++x)
            {
                lst = previewList.Items[x];
                lst.Text = Explorer.previews[x].data.name;
                y = _groups.IndexOf(Explorer.previews[x].data.writedTime.Date);
                lst.Group = previewList.Groups[y];
            }
            //delete ui element
            for (; x < previewList.Items.Count;)
                previewList.Items.RemoveAt(x);



        }

        public static void createEdit(Label upset)
        {
            void method(object o, EventArgs e)
            {
                var temp = new TextBox();
                upset.Parent.Controls.Add(temp);
                temp.Location = upset.Location;
                temp.Multiline = true;
                temp.Size = upset.Size;
                temp.BorderStyle = BorderStyle.None;
                temp.Font = upset.Font;
                temp.BackColor = Color.DarkGray;
                temp.ForeColor = upset.ForeColor;
                temp.Text = upset.Text;
                upset.Visible = false;
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
                        upset.Text = confirmed;
                    }
                    upset.Visible = true;

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

            upset.Cursor = Cursors.IBeam;
            upset.Click += method;
        }

        public void autosave(bool run)
        {
            if (run)
            {
                if (timer == null)
                {
                    timer = new Timer();
                    timer.Tick += (o, e) =>
                    {
                        int x;
                        bool[] visibles;
                        if (explorer.check_autosave())
                        {
                            Cursor = Cursors.WaitCursor;
                            visibles = new bool[Controls.Count];
                            for (x = 0; x < Controls.Count; ++x)
                            {
                                visibles[x] = Controls[x].Visible;
                                //Controls[x].Visible = false;
                            }

                            message("Автосохранение...");
                            System.Threading.Thread.Sleep(10);
                            explorer.saveAll(true);
                            System.Threading.Thread.Sleep(10);

                            message("Автосохранение выполнено успешно.");

                            for (x = 0; x < Controls.Count; ++x)
                            {
                                //Controls[x].Visible = visibles[x];
                            }

                            Cursor = Cursors.Default;
                        }
                    };
                    timer.Interval = 5000; // per a 5 sec
                }
            }

            if (timer != null)
                timer.Enabled = run;
        }

        public void message(string msg)
        {
            labelStatusBottom.Text = msg;
            labelStatusBottom.Update();
        }

        bool canInfoXupdate = false;
        void infoX_init()
        {
            infoX_projectName.TextChanged += (o, e) =>
            {
                if (!canInfoXupdate)
                    return;
                explorer.currentProject.name = infoX_projectName.Text; // update
                explorer.currentProject.pushChange();
                combobox_projectListSel.Items[explorer.currentProjectIndex] = explorer.currentProject.name;
            };
        }

        void updateProfile()
        {
            Explorer.Profile c = Explorer.projectConfiguration.profiles[Explorer.projectConfiguration.selectedProfile];
            menu_run_test.Text = string.Format(formatRunProfTest0, c.name);
            menu_run_test_fullscreen.Text = string.Format(formatRunProfTest1, c.name);
            updatePreviews();
        }

        void updateProjectInfoX(Project project)
        {
            canInfoXupdate = false;
            infoX_projectName.Text = "Проект не выбран";
            editDescribeInfoX.Text = "";
            if ((infoXPanel.Enabled = project != null))
            {
                editDescribeInfoX.Text = project.description ?? String.Empty;
                infoX_projectName.Text = project.name;
            }
            canInfoXupdate = true;
        }

        public void updateProjectList()
        {
            bool last = canFocusProject;
            canFocusProject = false;
            combobox_projectListSel.Items.Clear();
            int focusedIndex = -1;
            for (int i = 0; i < Explorer.projects.Count; ++i)
            {
                combobox_projectListSel.Items.Add(Explorer.projects[i].name);
                if (focusedIndex == -1 && explorer.currentProject == Explorer.projects[i])
                    focusedIndex = i;
            }
            combobox_projectListSel.SelectedIndex = focusedIndex;
            canFocusProject = last;
            drawProject(explorer.currentProject);
        }

        public void drawProject(Project project)
        {
            if (!canDrawableProject)
                return;
            projectExplorer.RemoveAll(true);

            updateProjectInfoX(project);

            bool existProject = explorer.currentProject != null;
            this.Text = string.Format(captionFormat, existProject ? project.name : "(Выберите проект)");
            tabPage3.Text = existProject ? tabPage3Caption : tabPage3Caption + " (Недоступно)";
            buttonOpenProjDir.Enabled = existProject;
            (tabPage3 as Panel).Enabled = existProject;
            editDescribeInfoX.Enabled = existProject;
            deleteProj.Enabled = existProject;
            menu_run_test.Enabled = existProject;
            menu_run_test_fullscreen.Enabled = existProject;
            menuItem_export.Enabled = existProject;
            menuItem_import.Enabled = existProject;
            menuItem_saveProjectAs.Enabled = existProject;

            updateProfile();

            if (project == null)
            {
                message("Проект не выбран, создайте или откройте существующий проект");
            }
            else
            {
                updateQuestions();
                message("Проект \"" + project.name + "\" загружен");
            }
        }

        public void updateQuestions()
        {
            int x, y;
            Project project = explorer.currentProject;

            if (!canChangeQuests || pages.SelectedTab != tabPage3 || !(tabPage3 as Panel).Enabled)
                return;
            Cursor = Cursors.WaitCursor;
            projectExplorer.Visible = false;
            y = project.questionCount - projectExplorer.count; // update at 32 objects
            Control[] optimizedVersion = y > 0 ? new Control[y] : null;
            for (x = 0; x < y; ++x)
            {
                Components.EditorQuestionObjectView fc = new Components.EditorQuestionObjectView();
                fc.questionIndex = x;
                fc.collapse = true;
                fc.Dock = DockStyle.Fill;
                optimizedVersion[x] = fc;
            }
            if (optimizedVersion != null)
            {
                projectExplorer.layout.Controls.AddRange(optimizedVersion);
                optimizedVersion = null;
            }

            //refresh
            for (x = 0; x < projectExplorer.count; ++x)
                updateQuestion(x);
            Cursor = Cursors.Default;
            projectExplorer.Visible = true;

            GC.Collect(0, GCCollectionMode.Forced, true, true);
        }

        public void updateQuestion(int questionIndex, bool queueDelete = false)
        {
            Project cp = explorer.currentProject;
            Question q;
            bool visib = projectExplorer.Visible;
            projectExplorer.Visible = false;
            var fc = projectExplorer.get(questionIndex);
            if (queueDelete)
            {
                cp.deleteQuestion(questionIndex);
                projectExplorer.RemoveItem(questionIndex);
                updateQuestions();
                return;
            }
            q = cp.model.questions[questionIndex];
            fc.multipleAnswersCheck.Enabled = q.answers.Count > 2;
            fc.questionIndex = questionIndex;
            fc.ItemLabel.Text = !Explorer.projectConfiguration.hideNumberQuests ?
                            "#" + (questionIndex + 1) + ": " + q.question : q.question;
            fc.Visible = !(Explorer.projectConfiguration.hideDisallowQuests && !fc.active);
            fc.ItemDescription.Text = string.Format("Ответов {0}", q.answers.Count);
            fc.questionIndex = questionIndex;
            fc.active = q.active;
            updateAnswers(questionIndex);
            projectExplorer.Visible = visib;
        }

        public string[] getAnswers(int questionIndex)
        {
            return explorer.currentProject.getNativeQuestion(questionIndex).answers.ToArray();
        }

        public int getAnswersCount(int questionIndex)
        {
            return explorer.currentProject.getNativeQuestion(questionIndex).answers.Count;
        }

        public void updateAnswers(int questionIndex, params string[] append)
        {
            Project project = explorer.currentProject;
            Question q = project.getNativeQuestion(questionIndex);
            var view = projectExplorer.get(questionIndex);
            var content = view.answerContents;
            int x, y, z;
            bool multiValues;
            int singleValue;
            bool check;

            if (q.correctAnswers == null)
                q.correctAnswers = new List<int>(q.answers.Count) { 0 }; // set as default

            multiValues = q.correctAnswers.Count > 1;
            singleValue = q.correctAnswers[0];
            if (canUpdateStatsOne)
            {
                label_stats.Text = string.Format(formatStats, project.questionCount, project.totalAnswers);
            }

            project.addAnswers(questionIndex, append);
            z = content.Controls.Count - 1;
            y = q.answers.Count - z; // update at 32 objects
            Control[] optimizedVersion = y > 0 ? new Control[y] : null;
            for (x = 0; x < y; ++x)
            {
                var element = new Components.EditorAnswerObjectView();

                element.set(view, "", false, x);
                element.ForeColor = Color.Black;
                element.Dock = DockStyle.Fill;
                optimizedVersion[x] = element;
            }
            if (optimizedVersion != null)
                content.Controls.AddRange(optimizedVersion);

            for (x = 1; x < content.Controls.Count; ++x)
            {
                Components.EditorAnswerObjectView element = view.answerContents.Controls[x] as Components.EditorAnswerObjectView;
                if (element == null)
                    continue;

                if (multiValues)
                    for (y = 0, check = false; !check && y < q.correctAnswers.Count; ++y)
                        check = q.correctAnswers[y] == x - 1;
                else
                    check = singleValue == x - 1;
                element.set(view, q.answers[x - 1], check, x - 1, multiValues);
            }
            bool w = view.multipleAnswersCheck.Enabled;
            view.multipleAnswersCheck.Enabled = false;
            view.multipleAnswersCheck.Checked = multiValues;
            view.multipleAnswersCheck.Enabled = w;
        }

        public void updateAnswer(int questionIndex, int answerIndex, bool queueDelete = false)
        {
            Project cp = explorer.currentProject;
            Question q = cp.getNativeQuestion(questionIndex);
            var view = projectExplorer.get(questionIndex);
            Control answerControl = view.Controls[0].Controls[answerIndex + 1];
            if (queueDelete)
            {
                answerControl.Dispose();
                q.answers.RemoveAt(answerIndex);
                if (view.multipleAnswersCheck.Checked)
                    q.correctAnswers.RemoveAt(answerIndex);
                else
                {
                    if (answerIndex != 0)
                        q.correctAnswers[0] = 0;
                }
                if (q.answers.Count < 3)
                    view.multipleAnswersCheck.Checked = false;
            }
            updateQuestion(questionIndex);
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            explorer.createNewProject();
            updateProjectList();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            explorer.openProjectFile();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            explorer.saveProjectAsDlg(explorer.currentProject);
        }

        private void excelCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            explorer.exportTestCsv();
        }

        private void excelCSVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            explorer.importTestCsv();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            explorer.queryQuit();
            this.Close();
        }

        private void menu_run_test_Click(object sender, EventArgs e)
        {
            Visible = false;
            explorer.run(false);
            Visible = true;
        }

        private void menu_run_test_fullscreen_Click(object sender, EventArgs e)
        {
            Visible = false;
            explorer.run(true);
            Visible = true;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            explorer.saveProjectTemplate();
        }

        private void butAddQuest_Click(object sender, EventArgs e)
        {
            var answers = new List<string> { "Правильный ответ", "Неправильный ответ" };
            int ix = explorer.currentProject.addQuestion(true, "Безымянный вопрос #" + (explorer.currentProject.questionCount + 1), answers, new List<int> { 0 });
            updateQuestions();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pages.SelectedIndex = 0;
        }

        private void свернутьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x;
            for (x = 0; x < projectExplorer.count; ++x)
            {
                var fc = projectExplorer.get(x);
                fc.collapse = true;
            }
        }

        private void расскрытьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x;
            for (x = 0; x < projectExplorer.count; ++x)
            {
                var fc = projectExplorer.get(x);
                fc.collapse = false;
            }
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Explorer.projectDirectory());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(explorer.currentProject.filename))
            {
                MessageBox.Show(this, "Данного проекта отсутствует место назначение, пожалуйста сохраните проект, а потом попробуйте снова.");
                return;
            }
            System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(explorer.currentProject.filename));
        }

        private void шаблонныйПроектMenuItem_Click(object sender, EventArgs e)
        {
            explorer.createNewFromDefaultTemplate();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            explorer.saveAll();
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            explorer.showProfileDialog();
            updateProfile();
        }

        private void deleteProj_Click(object sender, EventArgs e)
        {
            var x = new Forms.ConfirmationDialog();
            x.go(explorer.currentProject);
            x.Dispose();
        }

        private void previewList_DoubleClick(object sender, EventArgs e)
        {
            if (previewList.SelectedIndices.Count == 0)
                return;
            PreviewDocument document = Explorer.previews[previewList.SelectedIndices[0]].data;
            explorer.openPreview(document, false);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            previewList_DoubleClick(null, e);
        }

        private void previewContexMenu_Opening(object sender, CancelEventArgs e)
        {
            int x;
            previewContexMenu.Enabled = (previewList.SelectedIndices.Count != 0);

            x = previewList.SelectedIndices.Count;
            string contents = (x == 0 ? "" : x + " элемент(ов)");
            toolStripMenuItem9.Text = string.Format(formatMenuItemPRev0, contents);
            toolStripMenuItem5.Text = string.Format(formatMenuItemPRev1, contents);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            int x;
            int c = 0;
            PreviewLink[] documents = Explorer.previews.Where((i, y) =>
            {
                int z = previewList.SelectedIndices.IndexOf(y);
                return z != -1;
            }).ToArray();
            for (x = 0; x < documents.Length; ++x)
            {
                PreviewLink document = documents[x];
                if (explorer.toArchive(document))
                    ++c;
            }

            MessageBox.Show(this, String.Format("Успешно архивировано: {0} элемент(ов)\n" +
                "Не архивированных: {1} элемент(ов)" +
                "\nВсе архивированные тесты лежат в папке Previews\\Archives. " +
                "\tСовет: Вы можете в любое время восстановить их в папку " +
                "Previews любым другим архиватором, рекомендованные и ныне популярные: WinRAR, 7zip, arc", c, x - c), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            int x;
            PreviewLink[] documents = Explorer.previews.Where((i, y) =>
            {
                int z = previewList.SelectedIndices.IndexOf(y);
                return z != -1;
            }).ToArray();
            x = explorer.removePreviews(documents);
            message("Удален " + x + " элемент(ов)");
        }
    }
}