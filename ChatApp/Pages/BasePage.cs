using System.Windows.Controls;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace ChatApp
{
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        private VM mViewModel;

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRigth;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        public float SlideSeconds { get; set; } = 0.8f;

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


        public BasePage()
        {
            //Hide the animation until it's done
            if(this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }

            this.Loaded += BaseClass_Loaded;

            this.ViewModel = new VM();
        }

        private async void BaseClass_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if(this.PageLoadAnimation == PageAnimation.None)
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
}
