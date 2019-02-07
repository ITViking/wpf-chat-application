using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{

    public class MonitorPasswordProperty :BaseAttachedPropterty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the caller
            var passwordBox = sender as PasswordBox;

            if (passwordBox == null)
            {
                return;
            }

            //Remove previos events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            //If the caller set MonitorPassword to true...
            if ((bool)e.NewValue)
            {
                //Set the default value 
                HasTextProperty.SetValue(passwordBox);
                //start listening for password changes 
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        //fires when the password box value changes
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }


    /// <summary>
    /// Attached property for a passwordBox
    /// </summary>
    public class HasTextProperty : BaseAttachedPropterty<HasTextProperty, bool>
    {

        /// <summary>
        /// Sets the HasText property based on if the password caller has any text
        /// </summary>
        /// <param name="sender"></param>
       public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
