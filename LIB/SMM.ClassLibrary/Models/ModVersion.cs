using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.ClassLibrary.Models
{
    public class ModVersion
    {
        public string ID { get; set; }
        public string Version { get; set; }
        public string SMLVersion { get; set; }
        public string ChangeLog { get; set; }
        public int Downloads { get; set; }
        public Stability Stability { get; set; }
        public string ModID { get; set; }
        public bool Approved { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum Stability
    {
        ALPHA,
        BETA,
        RELEASE
    }
}
