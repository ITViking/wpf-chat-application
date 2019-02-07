using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatApp
{
    public class LoginViewModel : BaseViewModel
    {
        #region Public properties

        public string Email { get; set; }

        /// <summary>
        /// Used to keep track of wether or not the login command is running, and prevent the user from repeadetly clicking the login button
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructors

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }

        #endregion

        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () => 
            {
                await Task.Delay(5000);

                var email = this.Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });

            
        }

    }
}
