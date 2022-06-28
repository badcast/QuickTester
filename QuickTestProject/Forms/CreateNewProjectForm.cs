using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickTestProject
{
    public partial class CreateNewProjectForm : Form
    {
        public string formatCast;
        string formatDescribe;
        Color startColorPN;
        public CreateNewProjectForm()
        {
            InitializeComponent();

            but_create.Click += (o, e) =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            but_cancel.Click += (o, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            permissionInvalid.Checked = Explorer.projectConfiguration.permissionInvalidName;

            editProjectName.TextChanged += (o, e) => setProjectName(editProjectName.Text);
            editPath.TextChanged += (o, e) => setProjectName(editProjectName.Text);
            permissionInvalid.CheckedChanged += (o, e) =>
            {
                setProjectName(editProjectName.Text);
                Explorer.projectConfiguration.permissionInvalidName = permissionInvalid.Checked;
            };

            formatCast = examplePathPrev.Text;
            startColorPN = editProjectName.ForeColor;
            editPath.Text = Explorer.projectDirectory();

            foldeDialog.Description = "Выберите папку проекта";
            selectDir.Click += (o, e) =>
            {
                foldeDialog.SelectedPath = editPath.Text + "\\";
                if (foldeDialog.ShowDialog() != DialogResult.OK)
                    return;
                editPath.Text = foldeDialog.SelectedPath;
            };
            editProjectName.Text = "Новый проект";
            editDescribe.TextChanged += (o, e) =>
            {
                //Проверяем каждый символ, не пробел ли это
                describeState.Text = string.Format(formatDescribe, editDescribe.Text.Length, editDescribe.Text.Split().Length, editDescribe.Lines.Length);
            };
            formatDescribe = describeState.Text;
            editDescribe.Text = String.Empty;
        }

        void setProjectName(string projectName)
        {
            string projFIlename = editPath.Text + "\\" + Explorer.normalProjectFileName(projectName) + Explorer.projectFileExtension;
            bool existsProj = System.IO.File.Exists(projFIlename);
            bool invalidProjectName = !permissionInvalid.Checked && Explorer.hasInvalidChars(projectName);
            string msg = "Нажмите \"Создать\" чтобы продолжить";


            if (existsProj)
                msg = "Данный проект уже существует в папке, введите другое имя";
            else
            if (invalidProjectName)
            {
                msg = "Не надежное имя проекта";
                editProjectName.ForeColor = Color.Red;
            }
            else
                editProjectName.ForeColor = startColorPN;


            statusMessage.Text = msg;
            but_create.Enabled = !invalidProjectName && !existsProj;
            examplePathPrev.Text = formatCast + " " + editPath.Text + "\\" + Explorer.normalProjectFileName(projectName) + Explorer.projectFileExtension;
        }

        public bool show(IWin32Window owner, out Project p)
        {
            p = null;
            if (ShowDialog(owner) != DialogResult.OK)
            {
                return false;
            }
            p = Explorer.createEmptyProject();
            p.name = editProjectName.Text;
            p.description = editDescribe.Text;

            //set a valid filename
            p.filename = System.IO.Path.Combine(editPath.Text, Explorer.normalProjectFileName(editProjectName.Text) + Explorer.projectFileExtension);
            return true;
        }
    }
}
