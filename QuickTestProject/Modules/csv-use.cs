using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using csv = NReco.Csv; // external csv

namespace QuickTestProject.Modules
{
    public class Csv : Module
    {
        public static string mimetype = "text/csv";

        public override string name => "NReco.Csv";//"Comma-Separated Values (CSV)";

        public override string version => "1.0.1";

        public override string description => Properties.Resources.csv_module_description;

        public static void saveTemplate(string filename)
        {
            //this is template 
            File.WriteAllText(filename,
@"Answers,Answer A,Answer B,Answer C,Answer D,Answer E,Correct answers
Question 1,Answer 1,Answer 2,Answer 3,Answer 4,Answer 5,""A,B,C""
Question 2,Answer 1,Answer 2,Answer 3,Answer 4,Answer 5,""A,B,C""
Question 3,Answer 1,Answer 2,Answer 3,Answer 4,Answer 5,""A,B,C""
Question 4,Answer 1,Answer 2,Answer 3,Answer 4,Answer 5,""A,B,C""");
        }

        public static List<string[]> getrows(string filename) {

            int x;
            List<string[]> rows = new List<string[]>();
            Forms.CSV_Form csvdlg = new Forms.CSV_Form();
            Encoding enc = csvdlg.show_and_selectEncoding(filename);

            using (StreamReader sr = new StreamReader(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), enc))
            {
                csv.CsvReader csr = new csv.CsvReader(sr);
                while (csr.Read())
                {
                    string[] row = new string[csr.FieldsCount];
                    for (x = 0; x < csr.FieldsCount; ++x)
                    {
                        row[x] = csr[x];
                    }
                    rows.Add(row);
                }
            }

            rows.TrimExcess();
            return rows;
        }
    }
}
