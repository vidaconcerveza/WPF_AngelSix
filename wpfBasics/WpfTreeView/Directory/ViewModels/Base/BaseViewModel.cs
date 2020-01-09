using PropertyChanged;
using System.ComponentModel;

namespace WpfTreeView
{
    //[ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged=(sender, e) => { };

    }
}