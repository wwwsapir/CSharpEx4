namespace Ex04.Menus.Test
{
    using Ex04.Menus.Interfaces;

    internal class CountSpacesOperation : IMenuOperation
    {
        public void Operate()
        {
            int spacesCounter = 0;
            string sentenceToCountSpaces = Program.GetSentenceFromUser();
            foreach (char character in sentenceToCountSpaces)
            {
                if (character == ' ')
                {
                    ++spacesCounter;
                }
            }

            string outputStr = string.Format(
                "The number of spaces in the sentence is: {0}",
                spacesCounter);
            Program.PromptMessage(outputStr);
        }
    }
}
