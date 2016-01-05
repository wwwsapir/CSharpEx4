namespace Ex04.Menus.Test
{
    using System;
    using Ex04.Menus.Interfaces;

    internal class TimeOperation : IMenuOperation
    {
        public void Operate()
        {
            Program.PromptMessage(DateTime.Now.ToShortTimeString());
        }
    }
}
