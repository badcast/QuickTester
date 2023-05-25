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
    partial class TestRunnerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listbox_mode = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.limitsValues = new System.Windows.Forms.NumericUpDown();
            this.generateCheckbox = new System.Windows.Forms.CheckBox();
            this.testingProfile = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.playBytton = new System.Windows.Forms.Button();
            this.checboxFullscreen = new System.Windows.Forms.CheckBox();
            this.timerSelector = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.infoQuest = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limitsValues)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.timerSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox_mode
            // 
            this.listbox_mode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listbox_mode.BackColor = System.Drawing.Color.Silver;
            this.listbox_mode.FormattingEnabled = true;
            this.listbox_mode.Items.AddRange(new object[] {
            "• Неограниченное время",
            "• С временем"});
            this.listbox_mode.Location = new System.Drawing.Point(14, 46);
            this.listbox_mode.Name = "listbox_mode";
            this.listbox_mode.Size = new System.Drawing.Size(196, 43);
            this.listbox_mode.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.timerSelector);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.limitsValues);
            this.groupBox1.Controls.Add(this.generateCheckbox);
            this.groupBox1.Controls.Add(this.testingProfile);
            this.groupBox1.Controls.Add(this.listbox_mode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 183);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите профиль тестирования";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Silver;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(243, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(21, 21);
            this.button3.TabIndex = 8;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(216, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 21);
            this.button1.TabIndex = 8;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Количество вопросов";
            // 
            // limitsValues
            // 
            this.limitsValues.Location = new System.Drawing.Point(336, 64);
            this.limitsValues.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.limitsValues.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.limitsValues.Name = "limitsValues";
            this.limitsValues.Size = new System.Drawing.Size(57, 20);
            this.limitsValues.TabIndex = 10;
            this.limitsValues.Value = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            // 
            // generateCheckbox
            // 
            this.generateCheckbox.AutoSize = true;
            this.generateCheckbox.Location = new System.Drawing.Point(216, 46);
            this.generateCheckbox.Name = "generateCheckbox";
            this.generateCheckbox.Size = new System.Drawing.Size(104, 17);
            this.generateCheckbox.TabIndex = 3;
            this.generateCheckbox.Text = "Перемещевать";
            this.generateCheckbox.UseVisualStyleBackColor = true;
            // 
            // testingProfile
            // 
            this.testingProfile.FormattingEnabled = true;
            this.testingProfile.Items.AddRange(new object[] {
            "(по умолчанию)"});
            this.testingProfile.Location = new System.Drawing.Point(14, 19);
            this.testingProfile.Name = "testingProfile";
            this.testingProfile.Size = new System.Drawing.Size(196, 21);
            this.testingProfile.TabIndex = 2;
            this.testingProfile.TextChanged += new System.EventHandler(this.testingProfile_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox2.Controls.Add(this.infoQuest);
            this.groupBox2.Controls.Add(this.playBytton);
            this.groupBox2.Controls.Add(this.checboxFullscreen);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 160);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // playBytton
            // 
            this.playBytton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playBytton.BackColor = System.Drawing.Color.Silver;
            this.playBytton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playBytton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.playBytton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.playBytton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playBytton.Image = global::QuickTestProject.Properties.Resources.icon_play;
            this.playBytton.Location = new System.Drawing.Point(348, 38);
            this.playBytton.Name = "playBytton";
            this.playBytton.Size = new System.Drawing.Size(189, 110);
            this.playBytton.TabIndex = 8;
            this.playBytton.Text = "Запустить тест";
            this.playBytton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.playBytton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.playBytton.UseVisualStyleBackColor = false;
            this.playBytton.Click += new System.EventHandler(this.button2_Click);
            // 
            // checboxFullscreen
            // 
            this.checboxFullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checboxFullscreen.AutoSize = true;
            this.checboxFullscreen.BackColor = System.Drawing.Color.Transparent;
            this.checboxFullscreen.Checked = true;
            this.checboxFullscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checboxFullscreen.Location = new System.Drawing.Point(370, 15);
            this.checboxFullscreen.Name = "checboxFullscreen";
            this.checboxFullscreen.Size = new System.Drawing.Size(145, 17);
            this.checboxFullscreen.TabIndex = 9;
            this.checboxFullscreen.Text = "Полноэкранный режим";
            this.checboxFullscreen.UseVisualStyleBackColor = false;
            // 
            // timerSelector
            // 
            this.timerSelector.Controls.Add(this.radioButton4);
            this.timerSelector.Controls.Add(this.radioButton3);
            this.timerSelector.Controls.Add(this.radioButton2);
            this.timerSelector.Controls.Add(this.radioButton1);
            this.timerSelector.Location = new System.Drawing.Point(14, 95);
            this.timerSelector.Name = "timerSelector";
            this.timerSelector.Size = new System.Drawing.Size(379, 75);
            this.timerSelector.TabIndex = 12;
            this.timerSelector.TabStop = false;
            this.timerSelector.Text = "Выберите уровень сложности тестирования";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(194, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Новичок (неограниченное время)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(217, 42);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(94, 17);
            this.radioButton4.TabIndex = 10;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "КОУЧ (5 мин)";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(217, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(129, 17);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Специалист (60 мин)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(126, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Любитель (120 мин)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // infoQuest
            // 
            this.infoQuest.AutoSize = true;
            this.infoQuest.Location = new System.Drawing.Point(29, 38);
            this.infoQuest.Name = "infoQuest";
            this.infoQuest.Size = new System.Drawing.Size(35, 13);
            this.infoQuest.TabIndex = 10;
            this.infoQuest.Text = "label2";
            // 
            // TestRunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(556, 361);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestRunnerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигурация запуска";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limitsValues)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.timerSelector.ResumeLayout(false);
            this.timerSelector.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ListBox listbox_mode;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button playBytton;
        private CheckBox checboxFullscreen;
        private ComboBox testingProfile;
        private CheckBox generateCheckbox;
        private Label label1;
        private NumericUpDown limitsValues;
        private Button button3;
        private Button button1;
        private GroupBox timerSelector;
        private RadioButton radioButton1;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton2;
        private Label infoQuest;
    }
}