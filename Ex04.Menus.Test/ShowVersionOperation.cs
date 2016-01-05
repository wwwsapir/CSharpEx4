namespace Ex04.Menus.Test
{
    using Ex04.Menus.Interfaces;

    internal class ShowVersionOperation : IMenuOperation
    {
        private const string k_CurrentVersion = "Version: 16.1.4.0";

        public void Operate()
        {
            Program.PromptMessage(k_CurrentVersion);
        }
    }
}
