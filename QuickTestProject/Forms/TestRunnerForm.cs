using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickTestProject
{
    public partial class TestRunnerForm : Form
    {
        public Explorer explorer;
        public Project project;
        bool canChangeProfile = true;
        Timer tmr = new Timer();

        public int[] timesMinutes = new[]{
        0,
        120,
        60,
        5
        };

        Explorer.Profile selectedProfile { get { if (testingProfile.SelectedIndex == -1) return null; return Explorer.projectConfiguration.profiles[testingProfile.SelectedIndex]; } }
        Explorer.Profile lastSelectedProfile;

        public TestRunnerForm()
        {
            InitializeComponent();
        }


        void updateList()
        {
            int x;
            testingProfile.Items.Clear();

            for (x = 0; x < Explorer.projectConfiguration.profiles.Count; ++x)
                testingProfile.Items.Add(Explorer.projectConfiguration.profiles[x].name);
        }

        void profile_changed()
        {
            if (testingProfile.SelectedIndex == 0 || testingProfile.SelectedIndex == -1)
                button1.PerformClick();
        }

        void eval()
        {
            int totalAnswers, totalQuestions, totalMultiAnswers, totalSingleAnswers, totalCorrectedAnswers;
            int x;
            Question[] qq;
            if (project == null)
            {
                infoQuest.Text = "Проект не выбран для вычисления результатов";
                return;
            }

            qq = explorer.getQuestionsByFilter(project, selectedProfile.mix, true, selectedProfile.count);
            totalQuestions = qq.Length;
            //eval
            for (x = 0,
                totalAnswers = 0,
                totalCorrectedAnswers = 0,
                totalMultiAnswers = 0,
                totalSingleAnswers = 0; x < totalQuestions; ++x)
            {
                Question q = qq[x];
                totalAnswers += q.answers.Count;
                totalCorrectedAnswers += q.correctAnswers.Count((f) => f != -1);
                if (q.correctAnswers.Count > 1)
                    ++totalMultiAnswers;
                else
                    ++totalSingleAnswers;
            }

            infoQuest.Text = String.Format(
                @"Информационная панель
                Вопросов: {0}
                Ответов: {1}
                Множественных ответов: {2}
                Одиночных ответов: {3}
                Правильных ответов: {4}
                Время на тестирование: {5}
                Случайный порядок: {6}",
                totalQuestions,
                totalAnswers,
                totalMultiAnswers,
                totalSingleAnswers,
                totalCorrectedAnswers,
                
                selectedProfile.times == 0 || selectedProfile.mode == Explorer.ProfileMode.unlimit ? 
                "не ограничено" : (selectedProfile.times + " мин"),
                selectedProfile.mix ? "да":"нет"
                );

        }

        int indexof_timeMethod(object o)
        {
            int x;
            if (o == radioButton2)
                x = 1;
            else if (o == radioButton3)
                x = 2;
            else if (o == radioButton4)
                x = 3;
            else
                x = 0;
            return x;
        }

        public void show(Explorer explorer, Project project)
        {
            int x, y, z;
            this.project = project;
            this.Text = "Конфигурация запуска";
            this.explorer = explorer;

            updateList();

            testingProfile.SelectedIndexChanged += (o, e) =>
            {
                z = testingProfile.SelectedIndex;
                if (z == -1)
                    return;
                canChangeProfile = z != 0;
                limitsValues.Value = selectedProfile.count;
                generateCheckbox.Checked = selectedProfile.mix;
                listbox_mode.SelectedIndex = (int)selectedProfile.mode;
                Explorer.projectConfiguration.selectedProfile = z;
                lastSelectedProfile = selectedProfile;

                y = selectedProfile.times;
                RadioButton upset = radioButton1;
                if (y == timesMinutes[1])
                    upset = radioButton2;
                else if (y == timesMinutes[2])
                    upset = radioButton3;
                else if (y == timesMinutes[3])
                    upset = radioButton4;
                upset.Checked = true;
                canChangeProfile = true;

                eval();
            };
            listbox_mode.SelectedIndexChanged += (o, e) =>
            {
                if (!canChangeProfile)
                    return;
                profile_changed();
                selectedProfile.mode = (Explorer.ProfileMode)listbox_mode.SelectedIndex;
                timerSelector.Enabled = selectedProfile.mode == Explorer.ProfileMode.limit;
                eval();
            };
            generateCheckbox.CheckedChanged += (o, e) =>
            {
                if (!canChangeProfile)
                    return;
                profile_changed();
                selectedProfile.mix = generateCheckbox.Checked;
                eval();
            };
            limitsValues.ValueChanged += (o, e) =>
            {
                if (!canChangeProfile)
                    return;
                profile_changed();
                selectedProfile.count = (int)limitsValues.Value;
                eval();
            };
            void methodClick(object o, EventArgs e)
            {
                selectedProfile.times = timesMinutes[indexof_timeMethod(o)];
                eval();
            }
            radioButton4.CheckedChanged += methodClick;
            radioButton3.CheckedChanged += methodClick;
            radioButton1.CheckedChanged += methodClick;
            radioButton2.CheckedChanged += methodClick;


            z = Explorer.projectConfiguration.selectedProfile;
            if (z < 0)
                z = 0;
            else if (z > Explorer.projectConfiguration.profiles.Count - 1)
                z = 0;
            testingProfile.SelectedIndex = z;


            playBytton.Enabled = project != null;
            if (!playBytton.Enabled)
            {
                playBytton.Text = "Проект не выбран для запуска";
            }
            this.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            explorer.run(checboxFullscreen.Checked, selectedProfile);
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add profile as new name

            Explorer.Profile profNew = new Explorer.Profile(lastSelectedProfile);
            if (testingProfile.SelectedIndex == -1)
                profNew.name = testingProfile.Text;
            else
                profNew.name = "Скопированный профиль " + Explorer.projectConfiguration.profiles.Count;
            Explorer.projectConfiguration.profiles.Add(profNew);
            updateList();
            testingProfile.SelectedIndex = Explorer.projectConfiguration.profiles.Count - 1;
        }

        private void testingProfile_TextChanged(object sender, EventArgs e)
        {
            int z = testingProfile.SelectedIndex;
            if (z == -1 || z == 0)
                return;
            testingProfile.Items[z] = selectedProfile.name = testingProfile.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete profile
            int z = testingProfile.SelectedIndex;
            if (z == 0 || z == -1)
                return;
            Explorer.projectConfiguration.profiles.RemoveAt(z);
            updateList();
            testingProfile.SelectedIndex = --z;
        }
    }
}
