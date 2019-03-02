using System.Windows.Controls;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using ChatApp.Core;

namespace ChatApp
{
    /// <summary>
    /// The base page for all pages to add base functionality
    /// </summary>
    public class BasePage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRigth;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        public float SlideSeconds { get; set; } = 0.4f;
        public bool ShouldAnimateOut { get; set; }

        public BasePage()
        {
            //Hide the animation until it's done
            if (this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }

            this.Loaded += BasePage_Loaded;

        }


        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
            {
                await AnimateOut();
            }
            else
            {
                await AnimateIn();
            }
        }


        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRigth:

                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

                    break;
            }
        }


        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);

                    break;
            }
        }
    }


    /// <summary>
    /// A base page with added viewmodel support
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        private VM mViewModel;

        public VM ViewModel
        {
            get
            {
                return mViewModel;
            }

            set
            {
                if (mViewModel == value)
                {
                    return;
                }

                mViewModel = value;

                this.DataContext = mViewModel;
            }
        }

        public BasePage() : base()
        {
            this.ViewModel = new VM();
        }
    }
}
