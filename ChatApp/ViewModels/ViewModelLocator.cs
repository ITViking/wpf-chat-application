
using ChatApp.Core;

namespace ChatApp
{
    /// <summary>
    /// Gets viewmodel from the IoC for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        //A singleton instance of the locator 
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        //The actual application view model
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
