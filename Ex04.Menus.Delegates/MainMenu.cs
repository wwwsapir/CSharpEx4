using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : Menu
    {
        public MainMenu() : base("Main Menu")
        {
        }

        protected override void SetFirstItem()   // Sets the first item to "Exit"
        {
            m_ExitOrBack = "Exit";
        }

        public new void ShowMenu()  // Public show menu function that exists only in the Main Menu
        {
            base.ShowMenu();
        }
    }
}
