namespace Ex04.Menus.Interfaces
{
    public sealed class MainMenu : Menu
    {
        public MainMenu(string i_Description)
            : base(i_Description)
        {
        }

        // Externing the Show abstract method only to MainMenu obj.
        public new void Show()
        {
            base.Show();
        }

        // Setting the first MenuItemOperation to "Exit" instead of the default "Back"
        protected override void SetExitMenuDescription()
        {
            this.m_ExitMenuDescription = "Exit";
        }
    }
}
