using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.ClassLibrary.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Username { get; set; }
        [JsonProperty("avatar")]
        public string AvatarURL { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
