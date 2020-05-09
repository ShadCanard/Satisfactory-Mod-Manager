using MahApps.Metro.Controls;
using Satisfactory_Mod_Manager.Fragments;
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
using System.Windows.Shapes;

namespace Satisfactory_Mod_Manager.Windows
{
    /// <summary>
    /// Logique d'interaction pour SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : MetroWindow
    {
        private bool _shown;

        public SettingsWindow()
        {
            InitializeComponent();
            SetMainContent<SettingsFragment>();
        }


        public void SetMainContent<T>(params object[] args) where T : UserControl
        {
            MainContent.Content = Instance.GetInstance().GetFragment<T>(args);
        }

        private void OnClosingWin(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
