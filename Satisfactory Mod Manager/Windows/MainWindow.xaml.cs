using MahApps.Metro.Controls;
using Satisfactory_Mod_Manager.Fragments;
using Satisfactory_Mod_Manager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Satisfactory_Mod_Manager.Windows
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            sBarVersion.Content = string.Format(Properties.Resources.sfBottom, Properties.Resources.AppName, version.Major, version.Minor, version.Build, version.Revision);
            SetMainContent<ListOnlineFragment>();
        }
        public void SetMainContent<T>(params object[] args) where T : UserControl
        {
            MainContent.Content = Instance.GetInstance().GetFragment<T>(args);
        }

        private void OnOpenSettingsClick(object sender, RoutedEventArgs e)
        {
            Instance.GetInstance().GetWindow<SettingsWindow>().Show();
        }

        private void OnClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Instance.GetInstance().ShutdownApp();
        }
    }
}
