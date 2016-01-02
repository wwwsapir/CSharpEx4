using System;

namespace Ex04.Menus.Delegates
{

    public class MenuItem
    {
        private readonly string r_Description;

        public event Action<MenuItem> ReportChosenDelegates;

        public MenuItem(string i_Description)
        {
            r_Description = i_Description;
        }

        public string Description
        {
            get { return r_Description; }
        }

        public void OnItemChosen()
        {
            if (ReportChosenDelegates != null)
            {
                ReportChosenDelegates.Invoke(this);
            }
        }
    }
}
