using System;
using System.Windows;

namespace ChatApp
{
    public abstract class BaseAttachedPropterty<Parent, Property>
        where Parent : new()
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
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value", 
            typeof(Property), 
            typeof(BaseAttachedPropterty<Parent, Property>), 
            new PropertyMetadata(
                default(Property), 
                new PropertyChangedCallback(OnValuePropertyChanged), 
                new CoerceValueCallback(OnValuePropertyUpdated)
            ));
        

        /// <summary>
        /// The callback event for when the value property is changed
        /// </summary>
        /// <param name="d">The UI that had it's property changed </param>
        /// <param name="e">The arguments for the event </param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            (Instance as BaseAttachedPropterty<Parent, Property>)?.OnValueChanged(d, e);

            //Call event listernes
            (Instance as BaseAttachedPropterty<Parent, Property>)?.ValueChanged(d, e);
        }

        /// <summary>
        /// the callback event when the valueProperty is changed even if it is the same value
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            // Call the parent function
            (Instance as BaseAttachedPropterty<Parent, Property>)?.OnValueUpdated(d, value);

            //Call event listernes
            (Instance as BaseAttachedPropterty<Parent, Property>)?.ValueUpdated(d, value);

            return value;
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

        //Fired when the value changes
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        // Fired when the value changes even if the value is the same 
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Event Methods

        /// <summary>
        /// The method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">The element that this property was changed for</param>
        /// <param name="e">the arguments for the event </param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }


        /// <summary>
        /// The method that is called when any attached property of this type is changed even if the value is the same
        /// </summary>
        /// <param name="sender">The element that this property was changed for</param>
        /// <param name="e">the arguments for the event </param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }

        #endregion
    }
}
