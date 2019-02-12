namespace ChatApp.Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        public bool SideMenuVisible { get; set; } = false;
    }
}
