using System.Windows.Controls;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace ChatApp
{
    public class BasePage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRigth;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        public float SlideSeconds { get; set; } = 0.8f;

        public BasePage()
        {
            //Hide the animation until it's done
            if(this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }

            this.Loaded += BaseClass_Loaded;
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

                    var sb = new Storyboard();
                    var slideAnimation = new ThicknessAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(this.SlideSeconds)),
                        From = new Thickness(this.WindowWidth, 0, -this.WindowWidth, 0),
                        To = new Thickness(0),
                        DecelerationRatio = 0.8f
                    };

                    Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));

                    sb.Children.Add(slideAnimation);

                    sb.Begin(this);

                    this.Visibility = Visibility.Visible;

                    await Task.Delay((int)(this.SlideSeconds * 1000));

                    break;
            }
        }
    }
}
