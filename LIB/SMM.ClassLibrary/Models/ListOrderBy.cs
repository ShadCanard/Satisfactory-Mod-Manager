using Newtonsoft.Json;
using SMM.ClassLibrary.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.ClassLibrary.Models
{
    /// <summary>
    /// Things to Order by with Mods
    /// Available values : created_at, updated_at, name, views, downloads, hotness, popularity, last_version_date
    /// 
    /// </summary>
    public enum ListOrderBy
    {
        [JsonValue("")]
        None,
        [JsonValue("created_at")]
        CreatedAt, 
        [JsonValue("updated_at")]
        UpdatedAt, 
        [JsonValue("name")]
        Name,
        [JsonValue("views")]
        Views,
        [JsonValue("downloads")]
        Downloads,
        [JsonValue("hotness")]
        Hotness,
        [JsonValue("popularity")]
        Popularity,
        [JsonValue("last_version_date")]
        LastVersionDate
    }
}
