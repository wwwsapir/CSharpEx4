using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private readonly string r_Description;
        private readonly int r_ItemNumberInMenu;

        public event Action<MenuItem> EventHandlerWhenChosen;

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

        public void ChooseItem()
        {
            OnItemChosen();
            // In the future, this function can also contain other actions to do when chosen, apart from notifying listeners.
        }

        // Let all Listeners know that this item was chosen
        protected void OnItemChosen()
        {
            if (EventHandlerWhenChosen != null)
            {
                EventHandlerWhenChosen.Invoke(this);
            }
        }
    }
}
