using Satisfactory_Mod_Manager.Infrastructure;
using Satisfactory_Mod_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Mod_Manager.Repositories
{
    public class ProfileRepository
    {
        private static string PROFILE_FILE_PATH = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Profiles.SMMP");

        private List<Profile> _profiles;

        public List<Profile> List()
        {
            if (_profiles == null) _profiles = SerializerHelper.Load<List<Profile>>(PROFILE_FILE_PATH);
            if (_profiles == null) _profiles = new List<Profile>();
            return _profiles;
        }

        public void SaveProfiles()
        {
            SerializerHelper.Save(_profiles, PROFILE_FILE_PATH);
        }

        public void ExportProfile(Profile profile, string exportPath)
        {
            SerializerHelper.Save(profile, exportPath);
        }

        public void ImportProfile(Profile profile)
        {
            List().Add(profile);
        }

        public Profile GetProfile(string ProfileName)
        {
            return List().SingleOrDefault(profile => profile.ProfileName == ProfileName);
        }
    }
}
