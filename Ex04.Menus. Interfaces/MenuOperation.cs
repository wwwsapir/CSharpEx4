namespace Ex04.Menus.Interfaces
{
    // Wrapper class to IMenuOperation to improve ease of use
    internal class MenuOperation : MenuItem
    {
        private IMenuOperation m_MenuOperation;

        internal MenuOperation(IMenuOperation i_Operation, string i_ActionDescription) : base(i_ActionDescription)
        {
            this.m_MenuOperation = i_Operation;
            Description = i_ActionDescription;
        }

        internal override void Show()
        {
            this.m_MenuOperation.Operate();
        }
    }
}
