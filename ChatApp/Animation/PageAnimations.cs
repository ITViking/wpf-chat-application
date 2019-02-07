using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

namespace ChatApp
{
    public static class PageAnimations
    {
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {

            //Just adds a storyboard
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            sb.AddFadeIn(seconds);


            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {

            //Just adds a storyboard
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            sb.AddFadeOut(seconds);


            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }
    }
}
