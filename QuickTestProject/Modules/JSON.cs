using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json;

namespace QuickTestProject.Modules
{
    public class JSON : Module
    {
        public override string name => "simple-json";

        public override string version => "1.0.0";

        public override string description => Properties.Resources.json_module_description;

        public static string serialize<T>(T serialize)
        {
            return SimpleJson.SerializeObject(serialize);   
        }

        public static T deserialize<T>(string json)
        {
            return SimpleJson.DeserializeObject<T>(json);
        }
    }
}
