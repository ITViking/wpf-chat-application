

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value); 
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

      
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //get the frames 
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            // store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //clear the content of the new page to make place for the new one 
            newPageFrame.Content = null;

            // move the previous page into the old page frame 
            oldPageFrame.Content = oldPageContent;

            // animate out previous page when the loaded event fires right after this call due to moving frames
            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;
            }

            // set the new page content 
            newPageFrame.Content = e.NewValue;
        }

        public PageHost()
        {
            InitializeComponent();
        }
    }
}
