using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        /// <summary>
        /// Dependening on the state of the flag the command will run. false it runs, true is does not run
        /// </summary>
        /// <param name="updatingFlag"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            //Check if the function is running 
            if (updatingFlag.GetPropertyValue())
            {
                return;
            }

            updatingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                //set the property flag to false upon finishing
                updatingFlag.SetPropertyValue(false);
            }
        }
    }

}