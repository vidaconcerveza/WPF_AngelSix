using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WpfTreeView
{
    class DirectoryItemViewModel:BaseViewModel
    {




        public string FullPath { get; set; }
        public DirectoryItemType Type { get; set; }
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }


        public ICommand ExpandCommand { get; set; }

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);

            this.FullPath = fullPath;
            this.Type = type;

            this.ClearChildren();
        }
        /// <summary>
        /// A list of all children in this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; } 

        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value)
                    Expand();
                else
                    this.ClearChildren();
            }
        }

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }

        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;


            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));

        }
    }
}
