using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{

    /// <summary>
    /// Removes navigation history from the framework
    /// </summary>
    public class NoFrameHistory : BaseAttachedPropterty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (sender as Frame);

            //Hide the navigation bar 
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //clear navigtion history 
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
