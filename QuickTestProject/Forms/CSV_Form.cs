using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevLib.Csv;
using System.IO;

namespace QuickTestProject.Forms
{
    public partial class CSV_Form : Form
    {
        byte[] targetBuffer;
        CsvDocument doc;
        Encoding enc = Encoding.GetEncoding(1251);
        EncodingInfo[] encodings;
        public CSV_Form()
        {
            InitializeComponent();

            this.Shown += CSV_Form_Shown;
            this.comboBox1.Items.Clear();
            encodings = Encoding.GetEncodings();
            int y = -1;
            for (int x = 0; x < encodings.Length; ++x)
            {
                comboBox1.Items.Add(encodings[x].DisplayName + " (" + encodings[x].CodePage + ")");
                if (y == -1 && encodings[x].CodePage == enc.CodePage)
                    y = x;
            }
            if (y == -1)
                y = encodings.Length - 1;

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.Shown += (o, e) => comboBox1.SelectedIndex = y;
        }

        void selectEncoding(int codepage)
        {
            int y = -1;
            for (int x = 0; x < encodings.Length; ++x)
            {
                if (encodings[x].CodePage == codepage)
                {
                    y = x;
                    break;
                }
            }
            comboBox1.SelectedIndex = y;
        }

        void update()
        {
            //TODO: update data a new codding
            //todo: end

            var mx = new MemoryStream(targetBuffer);
            using (var ms = new StreamReader(mx, enc, true))
                    doc.Load(ms);
            mx.Dispose();

            var table = doc.GetDataTable();
            if (table == null)
            {
                dataGrid.Text = "Данная кодировка не поддерживается";
                return;
            }
            dataGrid.Text = "";
            for (int i = 0; i < table.Columns.Count; ++i)
            {
                dataGrid.Text += table.Columns[i].Caption + "\t\t\t";
            }
            dataGrid.Text += Environment.NewLine;
            for (int x = 0; x < table.Rows.Count; ++x)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataGrid.Text += table.Rows[x][i].ToString() + "\t\t\t";
                }
                dataGrid.Text += Environment.NewLine;
            }

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            enc = Encoding.GetEncoding(encodings[comboBox1.SelectedIndex].CodePage);
            update();
        }

        private void CSV_Form_Shown(object sender, EventArgs e)
        {
        }

        private void no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Encoding show_and_selectEncoding(string filename, CsvDocument csvdoc)
        {
            using (BinaryReader sr = new BinaryReader(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                targetBuffer = sr.ReadBytes((int)sr.BaseStream.Length);
            this.doc = csvdoc;
            this.ShowDialog();
            return enc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectEncoding(1251);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectEncoding(Encoding.UTF8.CodePage);
        }
    }
}
