using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.ClassLibrary.Models
{
    /// <summary>
    /// SML Mod Class
    /// </summary>
    public class Mod
    {
        public string ID { get; set; }
        public string Name { get; set; }
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }
        [JsonProperty("full_description")]
        public string FullDescription { get; set; }
        [JsonProperty("logo")]
        public string LogoURL { get; set; }
        [JsonProperty("source_url")]
        public string SourceURL { get; set; }
        [JsonProperty("creator_id")]
        public string CreatorID { get; set; }
        public bool Approved { get; set; }
        public int Views { get; set; }
        public int Downloads { get; set; }
        public int Popularity { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        public string AuthorName { get; set; }
        public string LatestVersion { get; set; }
    }
}
