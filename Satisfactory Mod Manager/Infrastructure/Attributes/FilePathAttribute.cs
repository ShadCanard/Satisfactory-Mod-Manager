using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Mod_Manager.Infrastructure.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class FilePathAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string path;

        // This is a positional argument
        public FilePathAttribute(string path)
        {
            this.path = path
                .Replace("{DataDir}",@"{BaseDir}\Data")
                .Replace("{LogsDir}",@"{BaseDir}\Logs")
                .Replace("{BaseDir}",AppDomain.CurrentDomain.BaseDirectory);
        }

        public string Path
        {
            get { return path; }
        }
    }
}
