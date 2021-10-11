using DataLakeBouncer.DLSGen2_Utilities;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace DataLakeBouncer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Orchestrator orch = new Orchestrator();

        public MainPage()
        {
            this.InitializeComponent();

            List<String> storageNames = PreferencesManager.GetSavedDataLake();
            foreach (var storage in storageNames)
            {
                Main_ComboBox_storageList.Items.Add(storage);
            }
        }

        private void Main_ComboBox_storageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orch.InitializeSession(Main_ComboBox_storageList.SelectedItem.ToString());

            List<String> fileSystemsList = orch.GetFileSystems();

            TreeViewNode rootNode = new TreeViewNode() { Content = "File Systems" };
            rootNode.IsExpanded = true;

            foreach(var s in fileSystemsList)
            {
                rootNode.Children.Add(new TreeViewNode() { Content = s, IsExpanded = false, HasUnrealizedChildren = true});
            }

            Main_TreeView_DirList.RootNodes.Add(rootNode);
        }

        private void Main_TreeView_DirList_ItemInvoked(TreeView sender, TreeViewItemInvokedEventArgs e)
        {
            Console.WriteLine(e.InvokedItem.ToString());
        }

        private void Main_TreeView_DirList_Expanding(TreeView sender, TreeViewExpandingEventArgs e)
        {
            Console.WriteLine(e);
        }
        private void Main_TreeView_DirList_Collapsing(TreeView sender, TreeViewCollapsedEventArgs e)
        {
            Console.WriteLine(e);
        }
    }
}
