using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    class Menu
    {
        public readonly bool r_Sub;
        private readonly Dictionary<MenuItem, Action> r_Items;
        private readonly List<Menu> r_SubMenusList = new List<Menu>(); 

        public Menu(bool i_IsSubMenu)  // Used to create a main menu or a sub-manu with an unknown number of items
        {
            r_Items = new Dictionary<MenuItem, Action>();
            r_Sub = i_IsSubMenu;
        }

        public Dictionary<MenuItem, Action> Items 
        {
            get { return r_Items; }
        }

        private void printMenu()
        {
            Console.Clear();
            string firstLine = r_Sub ? "0: Back" : "0: Exit";
            Console.WriteLine(firstLine);
            string currItemToShow;
            int i = 1;
            foreach (KeyValuePair<MenuItem, Action> item in r_Items)
            {
                currItemToShow = string.Format("{0} : {1}", i++, item.Key.Description);
                Console.WriteLine(currItemToShow);
            }
        }

        private int getChoiceFromUser()
        {
            Console.WriteLine("Please enter the number of the item you'd like to choose:");
            string input = Console.ReadLine();
            int currChoice;
            bool isFormatValid = int.TryParse(input, out currChoice);
            if (!isFormatValid)
            {
                throw new FormatException("Invalid input format!");
            }

            if (currChoice < 0 || currChoice > r_Items.Count)
            {
                throw new IndexOutOfRangeException("Input number out of range!");
            }

            return currChoice;
        }

        public void ShowMenu()
        {
            printMenu();
            int userChoice = getChoiceFromUser();
            int i = 1;
            foreach (KeyValuePair<MenuItem, Action> item in r_Items)
            {
                if (i == userChoice)
                {
                    item.Key.OnItemChosen();
                }
            }
        }

        public void AddActionMenuItem(string i_Description, Action i_FunctionToInvoke)
        {
            Items.Add(new MenuItem(i_Description), i_FunctionToInvoke);
        }

        public void AddSubMenuItem(string i_Description, Menu i_SubMenuToAdd)
        {
            const bool v_SubMenu = true;

            r_SubMenusList.Add(new Menu(v_SubMenu));
            int currSubMenuIndex = r_SubMenusList.IndexOf(new Menu(v_SubMenu));
            r_Items.Add(new MenuItem(i_Description), r_SubMenusList[currSubMenuIndex].ShowMenu);
            r_Items[itemIndex].ReportChosenDelegates += OnItemChosen;
        }
        private void OnItemChosen(MenuItem i_MenuItem)
        {
            const bool v_SubMenu = true;

            int currSubMenuIndex = r_SubMenusList.IndexOf(new Menu(v_SubMenu));
            r_SubMenusList[currSubMenuIndex].
        }
    }
}
