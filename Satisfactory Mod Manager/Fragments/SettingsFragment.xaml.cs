using MahApps.Metro;
using Satisfactory_Mod_Manager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Satisfactory_Mod_Manager.Fragments
{
    /// <summary>
    /// Logique d'interaction pour SettingsFragment.xaml
    /// </summary>
    public partial class SettingsFragment : UserControl
    {
        private bool _init;

        public SettingsFragment()
        {
            _init = true;
            InitializeComponent();
            cbxColors.ItemsSource = ThemeManager.Themes.Select(th => th.ColorScheme).Distinct();
            LoadParameters();
            _init = false;
        }

        private void OnToggleDarkMode(object sender, RoutedEventArgs e)
        {
            if (!_init)
            {
                Instance.GetInstance().GetParameters().DarkMode = cbDarkMode.IsChecked.Value;
                Instance.GetInstance().GetParameters().Save();
                ThemeManager.ChangeTheme(App.Current, Instance.GetInstance().GetParameters().GetTheme());
            }
        }

        private void OnChangeThemeColor(object sender, SelectionChangedEventArgs e)
        {
            if (!_init)
            {
                Instance.GetInstance().GetParameters().Color = cbxColors.SelectedItem.ToString();
                Instance.GetInstance().GetParameters().Save();
                ThemeManager.ChangeTheme(App.Current, Instance.GetInstance().GetParameters().GetTheme());
            }
        }

        private void LoadParameters()
        {
            cbxColors.SelectedItem = Instance.GetInstance().GetParameters().Color;
            cbDarkMode.IsChecked = Instance.GetInstance().GetParameters().DarkMode;
        }
    }
}
