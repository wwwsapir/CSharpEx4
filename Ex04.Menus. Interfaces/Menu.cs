namespace Ex04.Menus.Interfaces
{
    using System;
    using System.Collections.Generic;
   
    public class Menu : MenuItem
    {
        private bool m_MenuIsRunning;

        protected string m_ExitMenuDescription;
        private List<MenuItem> m_MenuItems;

        public Menu(string i_Description) : base(i_Description)
        {
            m_MenuIsRunning = false;
            m_MenuItems = new List<MenuItem>();

            // updating the Back/Exit Option' description
            this.SetExitMenuDescription();

            // Creating first item as Back/Exit Operation
            ExitMenuOperation exitOperation = new ExitMenuOperation(this);
            AddOperation(exitOperation, this.m_ExitMenuDescription);
        }

        // Overriding Virtual method of MenuItem
        internal override void Show()
        {
            this.m_MenuIsRunning = true;

            while (this.m_MenuIsRunning)
            {
                this.showMenuItems();
                int userChoice = this.getItemChoice();
                this.m_MenuItems[userChoice].Show();
            }
        }

        protected virtual void SetExitMenuDescription()
        {
            this.m_ExitMenuDescription = "Back";
        }

        private void showMenuItems()
        {
            int index = 0;
            Console.Clear();
            Console.WriteLine("{0} :", Description);

            foreach (MenuItem item in this.m_MenuItems)
            {
                Console.WriteLine("{0} : {1}", index, item.Description);
                index++;
            }
        }

        // Get user choice and check if valid
        private int getItemChoice()
        {
            bool choiceValid;
            string userInput;
            int itemChoice;

            Console.WriteLine("Please choose one of the options");
            do
            {
                userInput = Console.ReadLine();
                bool parsingSucceeded = int.TryParse(userInput, out itemChoice);
                bool choiceNumberInRange = itemChoice >= 0 && itemChoice < this.m_MenuItems.Count;

                if (!parsingSucceeded)
                {
                    Console.WriteLine("Input must be a number");
                    choiceValid = false;
                }
                else if (!choiceNumberInRange)
                {
                    Console.WriteLine("Choice is out of Range");
                    choiceValid = false;
                }
                else
                {
                    choiceValid = true;
                }
            }
            while (!choiceValid);

            return itemChoice;
        }

        // Polymorphic Adding method
        public void AddMenuItem(MenuItem i_MenuItem)
        {
            this.m_MenuItems.Add(i_MenuItem);
        }

        // Helper method to add subMenu, for ease of use improvement
        public Menu AddSubMenu(string i_Description)
        {
            Menu newMenu = new Menu(i_Description);
            AddMenuItem(newMenu);

            return newMenu;
        }

        // Helper method to add operation, for ease of use improvement
        public void AddOperation(IMenuOperation i_Operation, string i_ActionDescription)
        {
            MenuOperation newOperation = new MenuOperation(i_Operation, i_ActionDescription);
            AddMenuItem(newOperation);
        }
       

        // Exit/Back operation. would be the first operation(index 0)
        internal class ExitMenuOperation : IMenuOperation
        {
            private Menu m_menu;

            internal ExitMenuOperation(Menu i_Menu)
            {
                this.m_menu = i_Menu;
            }

            public void Operate()
            {
                this.m_menu.m_MenuIsRunning = false;
            }
        }
    }
}
