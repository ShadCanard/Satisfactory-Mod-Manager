using Markdig;
using SMM.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using XamlReader = System.Windows.Markup.XamlReader;
using System.Xaml;
using Markdig.Wpf;

namespace Satisfactory_Mod_Manager.Fragments.ModFragments
{
    /// <summary>
    /// Logique d'interaction pour DescriptionViewModFragment.xaml
    /// </summary>
    public partial class DescriptionViewModFragment : UserControl
    {
        private Mod _mod;

        public DescriptionViewModFragment()
        {
            InitializeComponent();
        }


        public DescriptionViewModFragment(Mod mod)
        {
            _mod = mod;
            InitializeComponent();
            ShowMarkdown();
        }


        private static MarkdownPipeline BuildPipeline()
        {
            return new MarkdownPipelineBuilder()
                .UseSupportedExtensions()
                .Build();
        }

        class MyXamlSchemaContext : XamlSchemaContext
        {
            public override bool TryGetCompatibleXamlNamespace(string xamlNamespace, out string compatibleNamespace)
            {
                if (xamlNamespace.Equals("clr-namespace:Markdig.Wpf", StringComparison.Ordinal))
                {
                    compatibleNamespace = $"clr-namespace:Markdig.Wpf;assembly={Assembly.GetAssembly(typeof(Markdig.Wpf.Styles)).FullName}";
                    return true;
                }
                return base.TryGetCompatibleXamlNamespace(xamlNamespace, out compatibleNamespace);
            }
        }

        private void OpenHyperlink(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Process.Start(e.Parameter.ToString());
        }
        private void ShowMarkdown()
        {

            string markdown = _mod.FullDescription;

            var xaml = Markdig.Wpf.Markdown.ToXaml(markdown, BuildPipeline());
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xaml)))
            {
                using (var reader = new XamlXmlReader(stream, new MyXamlSchemaContext()))
                {
                    if (XamlReader.Load(reader) is FlowDocument document)
                    {
                        Viewer.Document = document;
                    }
                }
            }
        }

    }
}
