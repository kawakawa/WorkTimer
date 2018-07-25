using System.ComponentModel;

namespace WorkTImer.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {



        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion


    }
}
