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

namespace QuickTestProject.Forms
{
    public partial class ConfirmationDialog : Form
    {
        public ConfirmationDialog()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void go(Project project)
        {
            label1.Text = String.Format(label1.Text, project.name);
            if (this.ShowDialog() == DialogResult.Yes)
            {
                Explorer.instance.unregisterProjectInRuntime(project);
                if (checkBox1.Checked && !string.IsNullOrEmpty(project.filename))
                    File.Delete(project.filename);
            }
        }
    }
}
