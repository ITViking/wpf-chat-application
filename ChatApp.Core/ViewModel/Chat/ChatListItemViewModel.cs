
namespace ChatApp.Core
{
    /// <summary>
    /// A view model for each chat list item in the overview chat list 
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        public string DisplayName { get; set; }

        public string Message { get; set; }

        public string Initials { get; set; }

        //The color for the profile picture if there's no picture and instead the initials
        public string InitialsCircleColor { get; set; }

        public bool HasNewMessage { get; set; }

        public bool IsActive { get; set; }
    }
}
