using MahApps.Metro;
using Satisfactory_Mod_Manager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Satisfactory_Mod_Manager
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ThemeManager.ChangeTheme(this,Instance.GetInstance().GetParameters().GetTheme());
        }
    }
}
