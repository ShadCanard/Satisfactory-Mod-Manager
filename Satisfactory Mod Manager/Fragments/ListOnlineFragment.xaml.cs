using SMLAPI.Infrastructure;
using SMM.ClassLibrary.Models;
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
    /// Logique d'interaction pour ListOnlineFragment.xaml
    /// </summary>
    public partial class ListOnlineFragment : UserControl
    {
        private bool _init;

        public ListOnlineFragment()
        {
            _init = true;
            InitializeComponent();
            cbOrderBy.ItemsSource = Enum.GetNames(typeof(ListOrderBy));
            cbOrderBy.SelectedItem = ListOrderBy.None.ToString();
            _init = false;
        }

        private void OnChangeOrder(object sender, SelectionChangedEventArgs e)
        {
            RefreshListView();
        }

        private void RefreshListView()
        {
            ApiClient client = new ApiClient();
            lvMods.ItemsSource = client.GetMods(txtSearch.Text, (ListOrderBy)Enum.Parse(typeof(ListOrderBy),cbOrderBy.SelectedItem.ToString()));
        }

        private void OnSearchKeyUp(object sender, KeyEventArgs e)
        {
            if(!_init) RefreshListView();
        }
    }
}
