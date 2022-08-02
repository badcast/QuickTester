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
using NReco.Csv;


namespace QuickTestProject.Forms
{
    public partial class CSV_Form : Form
    {
        byte[] targetBuffer;
        CsvReader csvdoc;
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

        void uptd_an_enc()
        {
            int x;
            string content = String.Empty;
            MemoryStream mx = new MemoryStream(targetBuffer);
            using (StreamReader sr = new StreamReader(mx, enc, true))
            {
                csvdoc = new CsvReader(sr);

                //Simple draw from new encoding
                while (csvdoc.Read())
                {
                    for (x = 0; x < csvdoc.FieldsCount; ++x)
                    {
                        content += csvdoc[x] + "\t\t\t";
                    }
                    content += Environment.NewLine;
                }
            }
            dataGrid.Text = content;
            mx.Dispose();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            enc = Encoding.GetEncoding(encodings[comboBox1.SelectedIndex].CodePage);
            uptd_an_enc();
        }

        private void CSV_Form_Shown(object sender, EventArgs e)
        {
        }

        private void no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Encoding show_and_selectEncoding(string filename)
        {

            using (BinaryReader sr = new BinaryReader(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                targetBuffer = sr.ReadBytes((int)sr.BaseStream.Length);
            if (this.ShowDialog() != DialogResult.OK)
                this.enc = Encoding.UTF8;
            return this.enc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectEncoding(1251); // set as default encoding
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectEncoding(Encoding.UTF8.CodePage); // set as default encoding
        }
    }
}
