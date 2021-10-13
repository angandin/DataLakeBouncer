using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DataLakeBouncer.DLSGen2_Utilities
{
    public class DirItem : INotifyPropertyChanged
    {
        public string Name {  get; set; }
        public bool CanExpand { get; set; }
        public enum ExplorerItemType { Folder, File };
        public ExplorerItemType Type { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private ObservableCollection<DirItem> m_children;
        public ObservableCollection<DirItem> Children
        {
            get
            {
                if (m_children == null)
                {
                    m_children = new ObservableCollection<DirItem>();
                }
                return m_children;
            }
            set
            {
                m_children = value;
            }
        }

        private bool m_isExpanded;
        public bool IsExpanded
        {
            get { return m_isExpanded; }
            set
            {
                if (m_isExpanded != value)
                {
                    m_isExpanded = value;
                    NotifyPropertyChanged("IsExpanded");
                }
            }
        }

        private bool m_isSelected;
        public bool IsSelected
        {
            get { return m_isSelected; }

            set
            {
                if (m_isSelected != value)
                {
                    m_isSelected = value;
                    NotifyPropertyChanged("IsSelected");
}
            }

        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class ExplorerItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FolderTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var explorerItem = (DirItem)item;
            return explorerItem.Type == DirItem.ExplorerItemType.Folder ? FolderTemplate : FileTemplate;
        }
    }
}
