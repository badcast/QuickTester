using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using Json;

namespace Installer
{
    public partial class main : Form
    {
        const int waittime =
#if DEBUG
            300;
#else 
1000;
#endif
        bool is_installed = false;

        public main()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            checkBox1.Visible = false;

        }

        public static string applicationDirectory()
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\QuickTest";
            Directory.CreateDirectory(path);
            return path;
        }
        public static string projectDirectory()
        {
            string path = applicationDirectory() + "\\Projects";
            Directory.CreateDirectory(path);
            return path;
        }

        private void appShortcutToDesktop(string linkName, string app)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");
                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
                writer.Flush();
            }
        }

        void sleep(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        void install()
        {
            but.Enabled = false;
            label1.Text = "Подготовка файлов.";
            Update();
            sleep(waittime);
            label1.Text = "Подготовка файлов..";
            Update();
            sleep(waittime);
            label1.Text = "Подготовка файлов..";
            Update();
            sleep(waittime);

            label1.Text = "Копирование файлов.";
            Update();
            sleep(waittime);
            installing();

        }

        public class ProjectIdentity
        {
            public string projectPath;
            public int projectID;
            public string version = "1.0.0";
        }
        public class ProjectConfiguration
        {
            public object[] profiles;
            public List<ProjectIdentity> projects;
            public object[] histories;
            public int focused;
            public bool permissionInvalidName;
            public bool hideNumberQuests;
            public bool hideDisallowQuests;
            public int maxHistoryView = 5;
            public bool firstRun = true;
            public bool autoSave = true;
            public int selectedProfile = 0;
        }

        string exeFilename;
        void installing()
        {
            string installDir = applicationDirectory() + "\\";
            byte[] buf = new byte[4098];
            using (ZipArchive zip = new ZipArchive(new MemoryStream(Properties.Resources.sources)))
            {
                foreach (var x in zip.Entries)
                {
                    if (x.FullName.EndsWith("/"))
                        Directory.CreateDirectory(installDir + x.FullName); // create a dir
                    else
                    {
                        label1.Text = "Копирование " + x.Name;
                        Update();
                        using (var s = new BinaryWriter(File.OpenWrite(installDir + x.FullName)))
                        {
                            int c;
                            int total = 0;
                            BinaryReader br = new BinaryReader(x.Open());
                            do
                            {
                                c = br.Read(buf, 0, buf.Length);
                                total += c;
                                s.Write(buf, 0, c);
                            } while (c != 0);
                        }
                    }
                    sleep(waittime / 4);
                }
            }

            label1.Text = "Копирование завершено.";
            Update();
            sleep(waittime);


            string[] files = Directory.GetFiles(projectDirectory());
            ProjectConfiguration prop = new ProjectConfiguration();
            prop.projects = new List<ProjectIdentity>();
            for (int x = 0; x < files.Length; ++x)
            {
                prop.projects.Add(new ProjectIdentity()
                {
                    projectID = x + 1,
                    projectPath = files[x]
                });
            }
            prop.focused = 1; //first project as focus

            File.WriteAllText(installDir + "settings.json", Json.SimpleJson.SerializeObject(prop));

            appShortcutToDesktop("Quick Tester", exeFilename = installDir + "QuickTestProject.exe");
            installed();
        }

        void installed()
        {
            is_installed = true;
            but.Enabled = true;
            checkBox1.Visible = true;
            label1.Visible = false;
            but.Text = "Завершить";
        }

        private void buttonOpenProjDir_Click(object sender, EventArgs e)
        {
            if (!is_installed)
            {
                install();
            }
            else
            {
                if (this.checkBox1.Checked)
                {
                    System.Diagnostics.Process.Start("explorer.exe", exeFilename);
                }
                this.Close();
            }
        }
    }
}
