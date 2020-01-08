using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WpfTreeView
{

    //[ImplementPropertyChanged]
    class Class1:INotifyPropertyChanged
    {

        
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        

        public string Test { get; set; }
        private string mTest = "";
        /* ** without nuget. PropertyChanged.Foody
        public string Test
        {
            get
            {
                return mTest;
            }
            set
            {
                if (mTest==value)
                {
                    return;                    
                }

                mTest = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
            }
        }
        */
        /*
        public Class1()
        {
            Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    await Task.Delay(500);
                    Test = i++.ToString();
                }
            });

        }
        */
    }
}
