using System;

namespace Ex04.Menus.Delegates
{
    public sealed class MenuItem
    {
        private readonly string r_Description;
        private readonly int r_ItemNumberInMenu;

        public event Action<MenuItem> ReportChosenDelegates;

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

        // Let all Listeners know that this item was chosen
        public void OnItemChosen()
        {
            if (ReportChosenDelegates != null)
            {
                ReportChosenDelegates.Invoke(this);
            }
        }
    }
}
