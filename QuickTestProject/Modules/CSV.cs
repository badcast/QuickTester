using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DevLib.Csv;

namespace QuickTestProject.Modules
{
    public class Csv : Module
    {
        const string _EOF = "\r\n";

        public static string mimetype = "text/csv";

        public override string name => getModule<DevLib.Csv.CsvDocument>().GetName().Name;//"Comma-Separated Values (CSV)";

        public override string version => getModule<DevLib.Csv.CsvDocument>().GetName().Version.ToString();

        public override string description => Properties.Resources.csv_module_description;

        public static CsvDocument open(string filename)
        {
            CsvDocument csv = new CsvDocument();
            Forms.CSV_Form csvdlg = new Forms.CSV_Form();
            Encoding enc = csvdlg.show_and_selectEncoding(filename, csv);
            return csv;
        }

        public static void saveTemplate(string filename)
        {
            File.WriteAllText(filename, @"ВОПРОСЫ,ОТВЕТ A,ОТВЕТ B,ОТВЕТ C,ОТВЕТ D,ОТВЕТ E,Правильный ответ
Пример вопроса, Ответ 1, Ответ 2, Ответ 3, Ответ 4, Ответ 5, ""A,B,C""");
        }

        public static void save(string filename)
        {

        }
    }
}
