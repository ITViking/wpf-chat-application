
using System.Collections.Generic;

namespace ChatApp
{

    /// <summary>
    /// Dummy data for the design process
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton

        //this is getter done in C# 7
        public static ChatListDesignModel Instance =>  new ChatListDesignModel();

        #endregion

        #region Constructor

        public ChatListDesignModel()
        {
            //get an instance of a list
            Items = new List<ChatListItemViewModel>
            {
                //Populate the list 
                new ChatListItemViewModel
                {
                    Initials = "PD",
                    DisplayName = "Philip",
                    Message = "Hi Philip, remember to go visit your mom and once in a while",
                    InitialsCircleColor = "3099c5",
                    HasNewMessage = true
                },
                new ChatListItemViewModel
                {
                    Initials = "JS",
                    DisplayName = "Jan",
                    Message = "Hi Jan, I hope you have a nice weekend",
                    InitialsCircleColor = "fe4503",
                    HasNewMessage = false
                },
                new ChatListItemViewModel
                {
                    Initials = "SD",
                    DisplayName = "Simon",
                    Message = "Hay ma brotha from the same motha'",
                    InitialsCircleColor = "00d405",
                    HasNewMessage = false,
                    IsActive = true
                },
                 new ChatListItemViewModel
                {
                    Initials = "SH",
                    DisplayName = "Susanne",
                    Message = "Hi Sus, looking forward to seeing you this saturday",
                    InitialsCircleColor = "3099c5",
                    HasNewMessage = true
                },
                new ChatListItemViewModel
                {
                    Initials = "JS",
                    DisplayName = "Jesse",
                    Message = "Hi Philip, hope you're feeling well",
                    InitialsCircleColor = "fe4503",
                    HasNewMessage = true

                },
                new ChatListItemViewModel
                {
                    Initials = "FK",
                    DisplayName = "Frederik",
                    Message = "Hej Philip, kan du hjælpe med min Mac igen?",
                    InitialsCircleColor = "00d405",
                    HasNewMessage = false
                },
            };
        }

        #endregion
    }
}
