using System;
using System.Windows.Input;

namespace ChatApp.Core
{

    /// <summary>
    /// A basic Command that runs an action
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action action { get; set; }

        /// <summary>
        /// Event fired when <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        /// <summary>
        /// A Relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
