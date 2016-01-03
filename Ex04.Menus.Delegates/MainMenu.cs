namespace Ex04.Menus.Delegates
{
    public sealed class MainMenu : Menu
    {
        public MainMenu() : base("Main Menu")
        {
        }

        protected override void SetFirstItem()   // Sets the first item name to "Exit"
        {
            m_ExitOrBack = "Exit";
        }

        public new void ShowMenu()  // Public show menu function that exists only in the Main Menu
        {
            base.ShowMenu();
        }
    }
}
