namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        public string Description { get; set; }

        internal MenuItem(string i_Description)
        {
            this.Description = i_Description;
        }

        internal abstract void Show();
    }
}
