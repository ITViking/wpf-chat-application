using System.Collections.Generic;

namespace ChatApp.Core
{
    /// <summary>
    /// A view model for each chat list item in the overview chat list 
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
