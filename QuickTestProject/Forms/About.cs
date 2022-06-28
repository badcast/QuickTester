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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            string conj = "   - ";
            
            module_list.Items.Clear();

            foreach (var it in Explorer.modules)
                 module_list.Items.Add(conj+ it.name + " v"+it.version);

            module_list.SelectedIndexChanged += (o,e)=> {
                if (module_list.SelectedIndex != -1)
                    moduleDescribe.Text = Explorer.modules[module_list.SelectedIndex].description;
            };

            listBox1.Items.Clear();
            foreach (var it in Explorer.externalSources)
                listBox1.Items.Add(conj + it.Item1);
            listBox1.DoubleClick += (o, e) =>
            {
                System.Diagnostics.Process.Start("explorer.exe", Explorer.externalSources[listBox1.SelectedIndex].Item1);
            };
            listBox1.SelectedIndexChanged += (o, e) =>
            {
                if (listBox1.SelectedIndex != -1)
                    textBox1.Text = Explorer.externalSources[listBox1.SelectedIndex].Item2;
            };
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", "https://github.com/badcast");
            }
            catch (Exception) { };
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", "https://ru.wikipedia.org/wiki/GNU_General_Public_License#GPL_v3");
            }
            catch (Exception) { };
        }
    }
}
