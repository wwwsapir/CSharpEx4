using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private readonly string r_Description;
        private readonly int r_ItemNumberInMenu;

        public event Action<MenuItem> ItemChosenHandler;

        public MenuItem(string i_Description, int i_ItemNumberInMenu)
        {
            r_Description = i_Description;
            r_ItemNumberInMenu = i_ItemNumberInMenu;
        }

        public string Description
        {
            get { return r_Description; }
        }

        public int ItemNumberInMenu
        {
            get { return r_ItemNumberInMenu; }
        }

        public void Choose()
        {
            OnItemChosen();
        }

        // Let all Listeners know that this item was chosen
        protected void OnItemChosen()
        {
            if (ItemChosenHandler != null)
            {
                ItemChosenHandler.Invoke(this);
            }
        }
    }
}
