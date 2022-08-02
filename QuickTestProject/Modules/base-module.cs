using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTestProject.Modules
{
    public abstract class Module
    {
        public abstract string name { get; }
        public abstract string version { get; }
        public abstract string description { get; }

        public static System.Reflection.Assembly getModule<T>()
        {
            return System.Reflection.Assembly.GetAssembly(typeof(T));
        }
        
    }
}
