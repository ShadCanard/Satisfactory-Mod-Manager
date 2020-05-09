using Markdig;
using Satisfactory_Mod_Manager.Infrastructure;
using SMLAPI.Infrastructure;
using SMM.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
using Markdig.Wpf;
using System.Xaml;
using System.Reflection;

namespace Satisfactory_Mod_Manager.Fragments.ModFragments
{
    /// <summary>
    /// Logique d'interaction pour ViewModFragment.xaml
    /// </summary>
    public partial class ViewModFragment : UserControl
    {

        private Mod _mod;

        public ViewModFragment()
        {
            InitializeComponent();
        }

        public ViewModFragment(string modID)
        {
            _mod = new ApiClient().GetMod(modID);
            InitializeComponent();
            RefreshContent();
        }

        public void RefreshContent()
        {
            bool IsModInstalled = true;
            bool IsModUpdateAvailable = true;


            txtModName.Text = _mod.Name;
            txtModUndertitle.Text = string.Format("{0} : {1} | {2} : {3} | {4} : {5}", 
                Properties.Resources.Author, _mod.AuthorName,
                Properties.Resources.Views, _mod.Views.ToString(), 
                Properties.Resources.Downloads, _mod.Downloads.ToString());
            imgLogo.Source = new BitmapImage(new Uri(_mod.LogoURL));
            DescriptionContent.Content = Instance.GetInstance().GetFragment<DescriptionViewModFragment>(_mod);

            //Check if mod is installed
            btnDownload.Visibility = (IsModInstalled ? Visibility.Collapsed : Visibility.Visible);
            btnRemove.Visibility = (IsModInstalled ? Visibility.Visible : Visibility.Collapsed);
            btnUpdate.Visibility = (IsModInstalled && IsModUpdateAvailable ? Visibility.Visible : Visibility.Collapsed);
        }



        private void OnDownloadClick(object sender, RoutedEventArgs e)
        {
            // Downloads latest mod file
            var latestVersion = new ApiClient().GetLatestVersion(_mod.ID);


            string fileURL = ApiClient.BASE_ADDRESS + "/mod/" + _mod.ID + "/versions/" + latestVersion.ID + "/download";

            WebClient wc = new WebClient();
            var data = wc.DownloadData(fileURL);
            string fileName = "";

            // Try to extract the filename from the Content-Disposition header
            if (!String.IsNullOrEmpty(wc.ResponseHeaders["x-bz-file-name"]))
            {
                fileName = wc.ResponseHeaders["x-bz-file-name"].Substring(wc.ResponseHeaders["x-bz-file-name"].IndexOf("filename=") + 9).Replace("\"", "").Split('/').LastOrDefault();
            }

            string FileRepository = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FILES");
            if (!Directory.Exists(FileRepository)) Directory.CreateDirectory(FileRepository);
            wc.DownloadFile(fileURL, System.IO.Path.Combine(FileRepository, fileName));
            Process.Start(FileRepository);
            // Add to profile when downloaded

            //Save profile
        }

        private void OnRemoveClick(object sender, RoutedEventArgs e)
        {
            // Deletes Mod File

            //Remove from profile

            //Save Profile
        }

        private void OnUpdateClick(object sender, RoutedEventArgs e)
        {
            //Deletes Old Mod File

            //Add New Mod File

            //Update Mod List

            //Save Profile
        }

        private void OnReturnToListClick(object sender, RoutedEventArgs e)
        {
            Instance.GetInstance().GetFragment<MainFragment>().SetMainContent<ListOnlineFragment>();
        }
    }
}
