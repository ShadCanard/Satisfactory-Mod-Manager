using MahApps.Metro;
using Microsoft.Win32;
using Satisfactory_Mod_Manager.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Mod_Manager.Infrastructure
{
    [Serializable]
    [FilePath(@"{DataDir}\Settings.bin")]
    public class Parameters
    {
        #region Load/Save
        internal static Parameters Load()
        {
            return SerializerHelper.Load<Parameters>();
        }

        internal void Save()
        {
            SerializerHelper.Save(this);
        }
        #endregion

        #region Theme
        public bool DarkMode { get; set; } = false;
        public string Color { get; set; } = "Red";

        public Theme GetTheme()
        {
            return ThemeManager.Themes.Single(th => th.BaseColorScheme == (DarkMode ? ThemeManager.BaseColorDark : ThemeManager.BaseColorLight) && th.ColorScheme == Color);
        }
        #endregion
    }
}
