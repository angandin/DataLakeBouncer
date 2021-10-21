using DataLakeBouncer.DLSGen2_Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace DataLakeBouncer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Orchestrator orch = new Orchestrator();
        private ObservableCollection<DirItem> dataSource = new ObservableCollection<DirItem>();
        public ObservableCollection<DirItem> DataSource { get { return this.dataSource; } }

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

            List<DirItem> fileSystemsList = orch.GetNodes();

            DirItem rootNode = new DirItem(orch.GetStorageName(), true, DirItem.ExplorerItemType.Folder);
            rootNode.IsExpanded = true;

            foreach (var fileSystem in fileSystemsList)
            {
                rootNode.Children.Add(fileSystem);
            }

            this.DataContext = this;

            this.dataSource.Add(rootNode);
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
            
        }
    }
}
