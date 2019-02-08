
namespace ChatApp
{

    /// <summary>
    /// Dummy data for the design process
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton

        //this is getter done in C# 7
        public static ChatListItemDesignModel Instance =>  new ChatListItemDesignModel();

        #endregion

        #region Constructor

        public ChatListItemDesignModel()
        {
            Initials = "PD";
            DisplayName = "Philip";
            Message = "Hi Philip, remember to go visit your mom and once in a while";
            InitialsCircleColor = "3099c5";
        }

        #endregion
    }
}
