
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// A base class that can run any animation method when a boolean is set to
    /// true and reverse it when it is set to false 
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedPropterty<Parent, bool>
        where Parent : BaseAttachedPropterty<Parent, bool>, new()
    {

        //Flag to indicate whether or not this is the first load
        public bool FirstLoad { get; set; } = true;


        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // get the framework element
            if (!(sender is FrameworkElement element))
            {
                return;
            }

            //don't fire unless the value changes
            if(sender.GetValue(ValueProperty) == value && !FirstLoad)
            {
                return;
            }

            // ON first load 
            if (FirstLoad)
            {
                //Create sing self-unhookable event for the element Loaded event 
                RoutedEventHandler onLoaded = null;

                onLoaded = (ss, ee) =>
                {
                    //Unhook ourselves
                    element.Loaded -= onLoaded;

                    // Do desired animation
                    DoAnimation(element, (bool)value);

                    // No longer the first run
                    FirstLoad = false;
                };

                // hook into the loaded event for the element 
                element.Loaded += onLoaded;
            }
            else
            {
                // Do desired animation
                DoAnimation(element, (bool)value);
            }
        }

        //The animation that is fired when the value changes
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {

        }
    }

    //animates a framework element, sliding it in from the left when it should show. Also slides it out again
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeInFromLeft(FirstLoad ? 0 : 0.3f, keepMargin: false);
            }
            else
            {
                await element.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.3f, keepMargin: false);
            }
        }
    }
}
