using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using json = TinyJson;

namespace QuickTestProject.Modules
{
    public class JSON : Module
    {
        public override string name => "TinyJson";

        public override string version => "1.0.0";

        public override string description => Properties.Resources.json_module_description;

        public static string serialize<T>(T value)
        {
            return json.JSONWriter.ToJson(value);
        }

        public static T deserialize<T>(string value)
        {
            return json.JSONParser.FromJson<T>(value);
        }
    }
}
