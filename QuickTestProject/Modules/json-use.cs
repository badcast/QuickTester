using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using json = Newtonsoft.Json;

namespace QuickTestProject.Modules
{
    public class JSON : Module
    {
        public override string name => "Newtonsoft.Json";

        public override string version => "12.0.3";

        public override string description => Properties.Resources.json_module_description;

        public static string serialize<T>(T value)
        {
            return json.JsonConvert.SerializeObject(value);
        }

        public static T deserialize<T>(string value)
        {
            return json.JsonConvert.DeserializeObject<T>(value);
        }
    }
}
