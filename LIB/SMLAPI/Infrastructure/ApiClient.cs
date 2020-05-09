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
        public static string BASE_ADDRESS = "http://api.ficsit.app/v1";


        private RestClient GetClient()
        {
            if (_client == null) _client = new RestClient(BASE_ADDRESS);
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
                RestRequest requestAuthor = new RestRequest(string.Format("/user/{0}", mod.CreatorID), Method.GET);
                var respAuthor = GetClient().Execute(requestAuthor);
                User user = JsonConvert.DeserializeObject<UserViewModel>(respAuthor.Content).Data;
                mod.AuthorName = user.Username;
                ModVersion version = GetLatestVersion(mod.ID);
                mod.LatestVersion = string.Format("v{0} ({1})", version?.Version, version?.Stability);
            }

            return modList;
        }


        public Mod GetMod(string ModID)
        {
            RestRequest request = new RestRequest("/mod/" + ModID, Method.GET);

            var respMod = GetClient().Execute(request);
            ModViewModel mod = JsonConvert.DeserializeObject<ModViewModel>(respMod.Content);
            GetModInfo(mod.Data);
            return mod.Data;
        }

        public void GetModInfo(Mod mod)
        {
            RestRequest requestAuthor = new RestRequest(string.Format("/user/{0}", mod.CreatorID), Method.GET);
            var respAuthor = GetClient().Execute(requestAuthor);
            User user = JsonConvert.DeserializeObject<UserViewModel>(respAuthor.Content).Data;
            mod.AuthorName = user.Username;
            ModVersion version = GetLatestVersion(mod.ID);
            mod.LatestVersion = string.Format("v{0} ({1})", version?.Version, version?.Stability);
        }

        public ModVersion GetLatestVersion(string ModID)
        {
            RestRequest requestLatestVersion = new RestRequest(string.Format("/mod/{0}/latest-versions", ModID), Method.GET);
            var respLatestVersion = GetClient().Execute(requestLatestVersion);
            LatestMods mods = JsonConvert.DeserializeObject<ModVersionViewModel>(respLatestVersion.Content).Data;
            if (mods.Release != null)
            {
                return mods.Release;
            }
            else if (mods.Beta != null)
            {
                return mods.Beta;
            }
            else if (mods.Alpha != null)
            {
                return mods.Alpha;
            }
            return null;
        }
    }
}
