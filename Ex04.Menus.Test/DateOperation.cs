namespace Ex04.Menus.Test
{
    using System;

    using Ex04.Menus.Interfaces;

    internal class DateOperation : IMenuOperation
    {
        public void Operate()
        {
            Program.PromptMessage(DateTime.Today.ToShortDateString());
        }
    }
}
