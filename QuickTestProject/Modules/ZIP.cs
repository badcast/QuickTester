using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace QuickTestProject.Modules
{
    public class ZIP : Module
    {
        static Assembly zipModule = getModule<System.IO.Compression.ZipArchive>();
        public override string name
        {
            get { return "ZipFile, GZIP, Deflate"; }
        }

        public override string version { get { return zipModule.GetName().Version.ToString(); ; } }

        public override string description => Properties.Resources.zip_module_description;
        public static ZipArchive open(string zipfile, ZipArchiveMode mode = ZipArchiveMode.Read)
        {
            ZipArchive zip = null;
            zip = ZipFile.Open(zipfile, mode);
            return zip;
        }

        public static string[] get_file_list(string zipfile)
        {
            return null;
        }
    }
}
