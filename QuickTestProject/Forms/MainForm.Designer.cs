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
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable. 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Example"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.файлMenuItem = new System.Windows.Forms.MenuItem();
            this.создатьMenuItem = new System.Windows.Forms.MenuItem();
            this.пустойПроектMenuItem = new System.Windows.Forms.MenuItem();
            this.шаблонныйПроектMenuItem = new System.Windows.Forms.MenuItem();
            this.открытьMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem_saveProjectAs = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.autosaveMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem_import = new System.Windows.Forms.MenuItem();
            this.excelCSVToolStripMenuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem_export = new System.Windows.Forms.MenuItem();
            this.excelCSVToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.ddToolStripMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.видMenuItem = new System.Windows.Forms.MenuItem();
            this.menu_run_test = new System.Windows.Forms.MenuItem();
            this.menu_run_test_fullscreen = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem_changeConfig = new System.Windows.Forms.MenuItem();
            this.помощьMenuItem = new System.Windows.Forms.MenuItem();
            this.справкаMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.оПрограммеMenuItem = new System.Windows.Forms.MenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.combobox_projectListSel = new System.Windows.Forms.ComboBox();
            this.pages = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.infoXPanel = new System.Windows.Forms.Panel();
            this.infoX_projectName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.editDescribeInfoX = new System.Windows.Forms.TextBox();
            this.deleteProj = new System.Windows.Forms.Button();
            this.buttonOpenProjDir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.const_top = new System.Windows.Forms.Panel();
            this.butAddQuest = new System.Windows.Forms.Button();
            this.contextMenuView = new System.Windows.Forms.Button();
            this.contexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideNumberQuests = new System.Windows.Forms.ToolStripMenuItem();
            this.hideDisallowQuest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.свернутьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расскрытьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_stats = new System.Windows.Forms.Label();
            this.projectExplorer = new QuickTestProject.Components.EditorProjectExplorer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.previewList = new System.Windows.Forms.ListView();
            this.previewContexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelStatusBottom = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.infoXPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.const_top.SuspendLayout();
            this.contexMenu.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.previewContexMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.файлMenuItem,
            this.menuItem5,
            this.видMenuItem,
            this.помощьMenuItem});
            // 
            // файлMenuItem
            // 
            this.файлMenuItem.Index = 0;
            this.файлMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.создатьMenuItem,
            this.открытьMenuItem,
            this.menuItem_saveProjectAs,
            this.menuItem8,
            this.menuItem7,
            this.autosaveMenuItem,
            this.menuItem3,
            this.menuItem_import,
            this.menuItem_export,
            this.toolStripMenuItem6,
            this.menuItem1,
            this.ddToolStripMenuItem});
            this.файлMenuItem.Text = "Файл";
            // 
            // создатьMenuItem
            // 
            this.создатьMenuItem.Index = 0;
            this.создатьMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.пустойПроектMenuItem,
            this.шаблонныйПроектMenuItem});
            this.создатьMenuItem.Text = "Создать новый проект";
            // 
            // пустойПроектMenuItem
            // 
            this.пустойПроектMenuItem.Index = 0;
            this.пустойПроектMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.пустойПроектMenuItem.Text = "Пустой проект";
            this.пустойПроектMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // шаблонныйПроектMenuItem
            // 
            this.шаблонныйПроектMenuItem.Index = 1;
            this.шаблонныйПроектMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftN;
            this.шаблонныйПроектMenuItem.Text = "Шаблонный проект";
            this.шаблонныйПроектMenuItem.Click += new System.EventHandler(this.шаблонныйПроектMenuItem_Click);
            // 
            // открытьMenuItem
            // 
            this.открытьMenuItem.Index = 1;
            this.открытьMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.открытьMenuItem.Text = "Добавить существующий проект";
            this.открытьMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // menuItem_saveProjectAs
            // 
            this.menuItem_saveProjectAs.Index = 2;
            this.menuItem_saveProjectAs.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.menuItem_saveProjectAs.Text = "Сохранить проект как ...";
            this.menuItem_saveProjectAs.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.Text = "Открыть папку проектов";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.Text = "-";
            // 
            // autosaveMenuItem
            // 
            this.autosaveMenuItem.Index = 5;
            this.autosaveMenuItem.Text = "Автосохранение";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 6;
            this.menuItem3.Text = "-";
            // 
            // menuItem_import
            // 
            this.menuItem_import.Index = 7;
            this.menuItem_import.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.excelCSVToolStripMenuItem1});
            this.menuItem_import.Text = "Импортировать в проект";
            // 
            // excelCSVToolStripMenuItem1
            // 
            this.excelCSVToolStripMenuItem1.Index = 0;
            this.excelCSVToolStripMenuItem1.Text = "Excel (*.CSV)";
            this.excelCSVToolStripMenuItem1.Click += new System.EventHandler(this.excelCSVToolStripMenuItem1_Click);
            // 
            // menuItem_export
            // 
            this.menuItem_export.Enabled = false;
            this.menuItem_export.Index = 8;
            this.menuItem_export.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.excelCSVToolStripMenuItem});
            this.menuItem_export.Text = "Экспортировать проект как";
            // 
            // excelCSVToolStripMenuItem
            // 
            this.excelCSVToolStripMenuItem.Index = 0;
            this.excelCSVToolStripMenuItem.Text = "Excel (*.CSV)";
            this.excelCSVToolStripMenuItem.Click += new System.EventHandler(this.excelCSVToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Index = 9;
            this.toolStripMenuItem6.Text = "Экспортировать шаблон для импорта";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 10;
            this.menuItem1.Text = "-";
            // 
            // ddToolStripMenuItem
            // 
            this.ddToolStripMenuItem.Index = 11;
            this.ddToolStripMenuItem.Text = "Выход";
            this.ddToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6});
            this.menuItem5.Text = "Вид";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "Параметры";
            // 
            // видMenuItem
            // 
            this.видMenuItem.Index = 2;
            this.видMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_run_test,
            this.menu_run_test_fullscreen,
            this.menuItem2,
            this.menuItem_changeConfig});
            this.видMenuItem.Text = "Запустить тест";
            // 
            // menu_run_test
            // 
            this.menu_run_test.Index = 0;
            this.menu_run_test.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menu_run_test.Text = "Запустить {0}";
            this.menu_run_test.Click += new System.EventHandler(this.menu_run_test_Click);
            // 
            // menu_run_test_fullscreen
            // 
            this.menu_run_test_fullscreen.Index = 1;
            this.menu_run_test_fullscreen.Shortcut = System.Windows.Forms.Shortcut.CtrlF5;
            this.menu_run_test_fullscreen.Text = "Запустить в полноэкранном режиме {0}";
            this.menu_run_test_fullscreen.Click += new System.EventHandler(this.menu_run_test_fullscreen_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // menuItem_changeConfig
            // 
            this.menuItem_changeConfig.Index = 3;
            this.menuItem_changeConfig.Text = "Изменить профиль";
            this.menuItem_changeConfig.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // помощьMenuItem
            // 
            this.помощьMenuItem.Index = 3;
            this.помощьMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.справкаMenuItem,
            this.menuItem4,
            this.оПрограммеMenuItem});
            this.помощьMenuItem.Text = "Помощь";
            // 
            // справкаMenuItem
            // 
            this.справкаMenuItem.Enabled = false;
            this.справкаMenuItem.Index = 0;
            this.справкаMenuItem.Text = "Справка";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "-";
            // 
            // оПрограммеMenuItem
            // 
            this.оПрограммеMenuItem.Index = 2;
            this.оПрограммеMenuItem.Text = "О программе";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(297, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(297, 6);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(321, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 6);
            // 
            // combobox_projectListSel
            // 
            this.combobox_projectListSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_projectListSel.DropDownWidth = 500;
            this.combobox_projectListSel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.combobox_projectListSel.ItemHeight = 19;
            this.combobox_projectListSel.Items.AddRange(new object[] {
            "Item 1"});
            this.combobox_projectListSel.Location = new System.Drawing.Point(11, 21);
            this.combobox_projectListSel.Name = "combobox_projectListSel";
            this.combobox_projectListSel.Size = new System.Drawing.Size(241, 27);
            this.combobox_projectListSel.TabIndex = 0;
            // 
            // tabControl4
            // 
            this.pages.Controls.Add(this.tabPage1);
            this.pages.Controls.Add(this.tabPage2);
            this.pages.Controls.Add(this.tabPage3);
            this.pages.Controls.Add(this.tabPage4);
            this.pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pages.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pages.HotTrack = true;
            this.pages.Location = new System.Drawing.Point(0, 0);
            this.pages.Name = "tabControl4";
            this.pages.Padding = new System.Drawing.Point(10, 10);
            this.pages.SelectedIndex = 0;
            this.pages.Size = new System.Drawing.Size(907, 337);
            this.pages.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.infoXPanel);
            this.tabPage1.Controls.Add(this.deleteProj);
            this.tabPage1.Controls.Add(this.buttonOpenProjDir);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.combobox_projectListSel);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(899, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Проекты";
            // 
            // infoXPanel
            // 
            this.infoXPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoXPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoXPanel.Controls.Add(this.infoX_projectName);
            this.infoXPanel.Controls.Add(this.label3);
            this.infoXPanel.Controls.Add(this.editDescribeInfoX);
            this.infoXPanel.Location = new System.Drawing.Point(11, 60);
            this.infoXPanel.Name = "infoXPanel";
            this.infoXPanel.Size = new System.Drawing.Size(716, 227);
            this.infoXPanel.TabIndex = 8;
            // 
            // infoX_projectName
            // 
            this.infoX_projectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoX_projectName.BackColor = System.Drawing.Color.Silver;
            this.infoX_projectName.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoX_projectName.Location = new System.Drawing.Point(22, 33);
            this.infoX_projectName.Name = "infoX_projectName";
            this.infoX_projectName.Size = new System.Drawing.Size(677, 32);
            this.infoX_projectName.TabIndex = 0;
            this.infoX_projectName.Text = "Example";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Имя проекта: (щелчок чтобы редактировать)";
            // 
            // editDescribeInfoX
            // 
            this.editDescribeInfoX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editDescribeInfoX.BackColor = System.Drawing.Color.Silver;
            this.editDescribeInfoX.Location = new System.Drawing.Point(22, 68);
            this.editDescribeInfoX.Multiline = true;
            this.editDescribeInfoX.Name = "editDescribeInfoX";
            this.editDescribeInfoX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.editDescribeInfoX.Size = new System.Drawing.Size(677, 154);
            this.editDescribeInfoX.TabIndex = 6;
            // 
            // deleteProj
            // 
            this.deleteProj.BackColor = System.Drawing.Color.Silver;
            this.deleteProj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteProj.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.deleteProj.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.deleteProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteProj.Location = new System.Drawing.Point(389, 21);
            this.deleteProj.Name = "deleteProj";
            this.deleteProj.Size = new System.Drawing.Size(125, 27);
            this.deleteProj.TabIndex = 7;
            this.deleteProj.Text = "Удалить проект";
            this.deleteProj.UseVisualStyleBackColor = false;
            this.deleteProj.Click += new System.EventHandler(this.deleteProj_Click);
            // 
            // buttonOpenProjDir
            // 
            this.buttonOpenProjDir.BackColor = System.Drawing.Color.Silver;
            this.buttonOpenProjDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonOpenProjDir.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.buttonOpenProjDir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonOpenProjDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenProjDir.Location = new System.Drawing.Point(258, 21);
            this.buttonOpenProjDir.Name = "buttonOpenProjDir";
            this.buttonOpenProjDir.Size = new System.Drawing.Size(125, 27);
            this.buttonOpenProjDir.TabIndex = 7;
            this.buttonOpenProjDir.Text = "Открыть папку";
            this.buttonOpenProjDir.UseVisualStyleBackColor = false;
            this.buttonOpenProjDir.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(795, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Quick Tester";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(795, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите проект";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(899, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Шаблоны";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel1.Location = new System.Drawing.Point(373, 357);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(150, 22);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Перейдите сюда";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(234, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 100);
            this.label2.TabIndex = 1;
            this.label2.Text = "Упс! \r\nЗдесь пока пусто. В дальнейшем что нибудь придумаем. \r\nА пока";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(348, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.const_top);
            this.tabPage3.Controls.Add(this.projectExplorer);
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(899, 295);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Конструктор";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // const_top
            // 
            this.const_top.BackColor = System.Drawing.Color.Gray;
            this.const_top.Controls.Add(this.butAddQuest);
            this.const_top.Controls.Add(this.contextMenuView);
            this.const_top.Controls.Add(this.label_stats);
            this.const_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.const_top.Location = new System.Drawing.Point(0, 0);
            this.const_top.Name = "const_top";
            this.const_top.Size = new System.Drawing.Size(899, 32);
            this.const_top.TabIndex = 5;
            // 
            // butAddQuest
            // 
            this.butAddQuest.BackColor = System.Drawing.Color.Silver;
            this.butAddQuest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butAddQuest.Dock = System.Windows.Forms.DockStyle.Left;
            this.butAddQuest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.butAddQuest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.butAddQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddQuest.Location = new System.Drawing.Point(65, 0);
            this.butAddQuest.Name = "butAddQuest";
            this.butAddQuest.Size = new System.Drawing.Size(95, 32);
            this.butAddQuest.TabIndex = 1;
            this.butAddQuest.Text = "+ Добавить";
            this.butAddQuest.UseVisualStyleBackColor = false;
            this.butAddQuest.Click += new System.EventHandler(this.butAddQuest_Click);
            // 
            // contextMenuView
            // 
            this.contextMenuView.BackColor = System.Drawing.Color.Silver;
            this.contextMenuView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.contextMenuView.ContextMenuStrip = this.contexMenu;
            this.contextMenuView.Dock = System.Windows.Forms.DockStyle.Left;
            this.contextMenuView.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.contextMenuView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.contextMenuView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contextMenuView.Location = new System.Drawing.Point(0, 0);
            this.contextMenuView.Name = "contextMenuView";
            this.contextMenuView.Size = new System.Drawing.Size(65, 32);
            this.contextMenuView.TabIndex = 3;
            this.contextMenuView.Text = "Вид ▼";
            this.contextMenuView.UseVisualStyleBackColor = false;
            // 
            // contexMenu
            // 
            this.contexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideNumberQuests,
            this.hideDisallowQuest,
            this.toolStripMenuItem8,
            this.свернутьВсеToolStripMenuItem,
            this.расскрытьВсеToolStripMenuItem});
            this.contexMenu.Name = "contextMenuStrip1";
            this.contexMenu.ShowCheckMargin = true;
            this.contexMenu.ShowImageMargin = false;
            this.contexMenu.Size = new System.Drawing.Size(189, 98);
            // 
            // hideNumberQuests
            // 
            this.hideNumberQuests.CheckOnClick = true;
            this.hideNumberQuests.Name = "hideNumberQuests";
            this.hideNumberQuests.Size = new System.Drawing.Size(188, 22);
            this.hideNumberQuests.Text = "Скрыть порядок";
            // 
            // hideDisallowQuest
            // 
            this.hideDisallowQuest.CheckOnClick = true;
            this.hideDisallowQuest.Name = "hideDisallowQuest";
            this.hideDisallowQuest.Size = new System.Drawing.Size(188, 22);
            this.hideDisallowQuest.Text = "Скрыть недоступное";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(185, 6);
            // 
            // свернутьВсеToolStripMenuItem
            // 
            this.свернутьВсеToolStripMenuItem.Name = "свернутьВсеToolStripMenuItem";
            this.свернутьВсеToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.свернутьВсеToolStripMenuItem.Text = "Свернуть все";
            this.свернутьВсеToolStripMenuItem.Click += new System.EventHandler(this.свернутьВсеToolStripMenuItem_Click);
            // 
            // расскрытьВсеToolStripMenuItem
            // 
            this.расскрытьВсеToolStripMenuItem.Name = "расскрытьВсеToolStripMenuItem";
            this.расскрытьВсеToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.расскрытьВсеToolStripMenuItem.Text = "Расскрыть все";
            this.расскрытьВсеToolStripMenuItem.Click += new System.EventHandler(this.расскрытьВсеToolStripMenuItem_Click);
            // 
            // label_stats
            // 
            this.label_stats.BackColor = System.Drawing.Color.Gainsboro;
            this.label_stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_stats.Location = new System.Drawing.Point(0, 0);
            this.label_stats.Name = "label_stats";
            this.label_stats.Size = new System.Drawing.Size(899, 32);
            this.label_stats.TabIndex = 4;
            this.label_stats.Text = "Общее число вопросов: {0}; Общее число ответов: {1}";
            this.label_stats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // projectExplorer
            // 
            this.projectExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectExplorer.AutoScroll = true;
            this.projectExplorer.BackColor = System.Drawing.Color.LightGray;
            this.projectExplorer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectExplorer.ForeColor = System.Drawing.Color.Transparent;
            this.projectExplorer.Location = new System.Drawing.Point(0, 31);
            this.projectExplorer.MinimumSize = new System.Drawing.Size(300, 150);
            this.projectExplorer.Name = "projectExplorer";
            this.projectExplorer.Size = new System.Drawing.Size(899, 264);
            this.projectExplorer.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.previewList);
            this.tabPage4.Location = new System.Drawing.Point(4, 38);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(899, 295);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Результаты";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // previewList
            // 
            this.previewList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.previewList.AutoArrange = false;
            this.previewList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.previewList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.previewList.ContextMenuStrip = this.previewContexMenu;
            this.previewList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewList.GridLines = true;
            this.previewList.HideSelection = false;
            listViewItem2.StateImageIndex = 0;
            this.previewList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.previewList.LargeImageList = this.imageList1;
            this.previewList.Location = new System.Drawing.Point(3, 3);
            this.previewList.Name = "previewList";
            this.previewList.Size = new System.Drawing.Size(893, 289);
            this.previewList.SmallImageList = this.imageList1;
            this.previewList.StateImageList = this.imageList1;
            this.previewList.TabIndex = 0;
            this.previewList.UseCompatibleStateImageBehavior = false;
            this.previewList.DoubleClick += new System.EventHandler(this.previewList_DoubleClick);
            // 
            // previewContexMenu
            // 
            this.previewContexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.toolStripMenuItem9,
            this.toolStripMenuItem5});
            this.previewContexMenu.Name = "previewContexMenu";
            this.previewContexMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.previewContexMenu.Size = new System.Drawing.Size(170, 76);
            this.previewContexMenu.Opening += new System.ComponentModel.CancelEventHandler(this.previewContexMenu_Opening);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem4.Text = "Открыть";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem9.Text = "Архивировать {0}";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem5.Text = "Удалить {0}";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon-document.png");
            // 
            // labelStatusBottom
            // 
            this.labelStatusBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatusBottom.Location = new System.Drawing.Point(0, 0);
            this.labelStatusBottom.Name = "labelStatusBottom";
            this.labelStatusBottom.Size = new System.Drawing.Size(907, 24);
            this.labelStatusBottom.TabIndex = 8;
            this.labelStatusBottom.Text = "Message";
            this.labelStatusBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelStatusBottom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 337);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 24);
            this.panel1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(907, 361);
            this.Controls.Add(this.pages);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick Tester";
            this.pages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.infoXPanel.ResumeLayout(false);
            this.infoXPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
           //this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.const_top.ResumeLayout(false);
            this.contexMenu.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.previewContexMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            //this.ResumeLayout(false);

        }

        #endregion
        private MainMenu mainMenu;
        private MenuItem файлMenuItem;
        private MenuItem создатьMenuItem;
        private MenuItem пустойПроектMenuItem;
        private MenuItem шаблонныйПроектMenuItem;
        private MenuItem открытьMenuItem;
        private MenuItem menuItem_saveProjectAs;
        private ToolStripSeparator toolStripMenuItem1;
        private MenuItem menuItem_import;
        private MenuItem excelCSVToolStripMenuItem1;
        private MenuItem menuItem_export;
        private MenuItem excelCSVToolStripMenuItem;
        private MenuItem toolStripMenuItem6;
        private ToolStripSeparator toolStripMenuItem2;
        private MenuItem ddToolStripMenuItem;
        private MenuItem видMenuItem;
        private MenuItem menu_run_test;
        private MenuItem menu_run_test_fullscreen;
        private ToolStripSeparator toolStripMenuItem7;
        private MenuItem помощьMenuItem;
        private MenuItem справкаMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private MenuItem оПрограммеMenuItem;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private ComboBox combobox_projectListSel;
        private TabControl pages;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private TabPage tabPage3;
        private Button butAddQuest;
        public Components.EditorProjectExplorer projectExplorer;
        private Panel const_top;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private Button contextMenuView;
        private ContextMenuStrip contexMenu;
        private ToolStripMenuItem hideNumberQuests;
        private ToolStripMenuItem hideDisallowQuest;
        private PictureBox pictureBox1;
        private Label label5;
        private TextBox editDescribeInfoX;
        private PictureBox pictureBox2;
        private Label label2;
        private LinkLabel linkLabel1;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem свернутьВсеToolStripMenuItem;
        private ToolStripMenuItem расскрытьВсеToolStripMenuItem;
        private Label label_stats;
        private Label labelStatusBottom;
        private Panel panel1;
        private MenuItem autosaveMenuItem;
        private MenuItem menuItem7;
        private MenuItem menuItem8;
        private Button buttonOpenProjDir;
        private MenuItem menuItem_changeConfig;
        private Panel infoXPanel;
        private Label infoX_projectName;
        private Label label3;
        private Button deleteProj;
        private TabPage tabPage4;
        private ListView previewList;
        private ImageList imageList1;
        private ContextMenuStrip previewContexMenu;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem5;
    }
}