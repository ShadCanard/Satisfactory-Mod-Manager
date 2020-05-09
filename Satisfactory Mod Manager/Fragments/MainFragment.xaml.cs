using Satisfactory_Mod_Manager.Infrastructure;
using SMLAPI.Infrastructure;
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
    /// Logique d'interaction pour MainFragment.xaml
    /// </summary>
    public partial class MainFragment : UserControl
    {
        public MainFragment()
        {
            InitializeComponent();
            SetMainContent<ListOnlineFragment>();
        }

        public void SetMainContent<T>(params object[] args) where T : UserControl
        {
            MainContent.Content = Instance.GetInstance().GetFragment<T>(args);
        }
    }
}
