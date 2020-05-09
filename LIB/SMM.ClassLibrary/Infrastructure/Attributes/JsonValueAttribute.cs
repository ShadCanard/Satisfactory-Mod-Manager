using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.ClassLibrary.Infrastructure.Attributes
{
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class JsonValueAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string valueName;

        // This is a positional argument
        public JsonValueAttribute(string valueName)
        {
            this.valueName = valueName;
        }

        public string ValueName
        {
            get { return valueName; }
        }
    }
}
