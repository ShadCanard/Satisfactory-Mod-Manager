using Newtonsoft.Json;
using RestSharp;
using SMLAPI.Models;
using SMM.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM.ClassLibrary.Infrastructure;

namespace SMLAPI.Infrastructure
{
    public class ApiClient
    {
        private static RestClient _client;

        private RestClient GetClient()
        {
            if (_client == null) _client = new RestClient("http://api.ficsit.app/v1");
            return _client;
        }

        public List<Mod> GetMods(string search = null, ListOrderBy orderBy = ListOrderBy.None)
        {
            RestRequest request = new RestRequest("/mods", Method.GET);
            if (search != null) request.AddParameter("search", search, ParameterType.QueryString);
            if (orderBy != ListOrderBy.None) request.AddParameter("order_by", orderBy.JsonValue());
            var resp = GetClient().Execute(request);
            List<Mod> modList = JsonConvert.DeserializeObject<ModsViewModel>(resp.Content).Data;
            foreach (Mod mod in modList)
            {
                RestRequest requestAuthor = new RestRequest(string.Format("/user/{0}",mod.CreatorID), Method.GET);
                var respAuthor = GetClient().Execute(requestAuthor);
                User user = JsonConvert.DeserializeObject<UserViewModel>(respAuthor.Content).Data;
                mod.AuthorName = user.Username;

                RestRequest requestLatestVersion = new RestRequest(string.Format("/mod/{0}/latest-versions", mod.ID), Method.GET);
                var respLatestVersion = GetClient().Execute(requestLatestVersion);
                LatestMods mods = JsonConvert.DeserializeObject<ModVersionViewModel>(respLatestVersion.Content).Data;
                if(mods.Release != null)
                {
                    mod.LatestVersion = string.Format("v{0} ({1})", mods.Release.Version, mods.Release.Stability);
                }
                else if(mods.Beta != null)
                {
                    mod.LatestVersion = string.Format("v{0} ({1})", mods.Beta.Version, mods.Beta.Stability);
                }
                else if(mods.Alpha != null)
                {
                    mod.LatestVersion = string.Format("v{0} ({1})", mods.Alpha.Version, mods.Alpha.Stability);
                }
            }

            return modList;
        }
    }
}
