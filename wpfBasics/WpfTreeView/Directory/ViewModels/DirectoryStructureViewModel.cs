using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTreeView
{
    public class DirectoryStructureViewModel:BaseViewModel
    {
        //public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrive();
         //   this.Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
    }
}
