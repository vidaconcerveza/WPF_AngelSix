using PropertyChanged;
using System.ComponentModel;

namespace WpfTreeView
{
    public class BaseViewMode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged=(sender, e) => { };
    }
}