using Satisfactory_Mod_Manager.Infrastructure.Attributes;
using SMM.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Mod_Manager.Models
{
    [Serializable]
    public class Profile
    {
        public string ProfileName { get; set; }
        public string ProfileID { get; set; }
        public List<Mod> ModList { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
