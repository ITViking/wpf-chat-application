using System;
using System.Windows;

namespace ChatApp
{
    public abstract class BaseAttachedPropterty<Parent, Property>
        where Parent: BaseAttachedPropterty<Parent, Property>, new()
    {
        #region Public properties

        /// <summary>
        /// a singleton instance of our parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        /// <summary>
        /// The attached property of this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedPropterty<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));
        

        /// <summary>
        /// The callback event for when the value property is changed
        /// </summary>
        /// <param name="d">The UI that had it's property changed </param>
        /// <param name="e">The arguments for the event </param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            Instance.OnValueChanged(d, e);

            //Call event listernes
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the attached property
        /// </summary>
        /// <param name="d">the element to get the property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Sets the attached property's value
        /// </summary>
        /// <param name="d">The element to get the property itself from</param>
        /// <param name="value">The value to set the property with</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Public events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region Event Methods

        /// <summary>
        /// The method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">The element that this property was changed for</param>
        /// <param name="e">the arguments for the event </param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion
    }
}
