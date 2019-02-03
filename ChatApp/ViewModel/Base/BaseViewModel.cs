using PropertyChanged;
using System.ComponentModel;

namespace ChatApp
{
    /// <summary>
    /// The base view model which all other viewmodels can inherit from, so I don't have to implement propertyChanged to every single one of them
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

}