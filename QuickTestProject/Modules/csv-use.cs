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
        public const string mimetype = "text/csv";
        public const string extension = ".csv";
        public const string csvFilter = "CSV|*.csv";
        public override string name => "NReco.Csv";//"Comma-Separated Values (CSV)";

        public override string version => "1.0.1";

        public override string description => Properties.Resources.csv_module_description;

        public static void saveTemplate(string filename)
        {
            int x;
            if (string.Compare(Path.GetExtension(filename), extension) != 0)
            {
                System.Windows.Forms.MessageBox.Show("Данный тип расширения не поддерживается.");
                return;
            }

            using (var sw = new StreamWriter(File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)))
            {
                csv.CsvWriter csw = new csv.CsvWriter(sw);
                csw.WriteField("Вопросы");
                csw.WriteField("Ответ A");
                csw.WriteField("Ответ B");
                csw.WriteField("Ответ C");
                csw.WriteField("Ответ D");
                csw.WriteField("Ответ E");
                csw.WriteField("Правильный ответ(ы)");

                for (x = 0; x < 5; ++x)
                {
                    csw.NextRecord();
                    csw.WriteField("Вопрос " + x);
                    for (int y = 0; y < 5; ++y)
                        csw.WriteField("Ответ " + y);

                    csw.WriteField("A,B,C");
                }
            }
        }

        public static List<string[]> importCsvData(string filename)
        {
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

        public static void exportProjectAsCsv(string filename, Project project)
        {
            int x, y, z;
            Question q;
            if (string.Compare(Path.GetExtension(filename), extension) != 0)
            {
                System.Windows.Forms.MessageBox.Show("Данный тип расширения не поддерживается.");
                return;
            }

            //get max answers
            for (x = y = 0; x < project.questionCount; ++x)
                if (y < project.getNativeQuestion(x).answers.Count)
                    y = project.getNativeQuestion(x).answers.Count;
            using (var sw = new StreamWriter(File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)))
            {
                csv.CsvWriter csw = new csv.CsvWriter(sw);
                csw.WriteField("Вопросы");
                csw.WriteField("Ответ A");
                csw.WriteField("Ответ B");
                csw.WriteField("Ответ C");
                csw.WriteField("Ответ D");
                csw.WriteField("Ответ E");
                csw.WriteField("Правильный ответ(ы)");
                for (x = 0; x < project.questionCount; ++x)
                {
                    csw.NextRecord();
                    q = project.getNativeQuestion(x);

                    csw.WriteField(q.question);
                    for (z = 0; z < q.answers.Count; ++z)
                        csw.WriteField(q.answers[z]);
                    for (; z < y; ++z)
                        csw.WriteField("");
                    string answ = string.Empty;

                    for (z = 0; z < q.correctAnswers.Count; ++z)
                    {
                        answ += Convert.ToChar('A' + q.correctAnswers[z]);
                        if (z + 1 < q.correctAnswers.Count)
                            answ += ',';
                    }
                    csw.WriteField(answ);
                }
            }
        }
    }
}
