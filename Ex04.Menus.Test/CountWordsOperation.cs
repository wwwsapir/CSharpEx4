namespace Ex04.Menus.Test
{
    using Ex04.Menus.Interfaces;

    internal class CountWordsOperation : IMenuOperation
    {
        public void Operate()
        {
            string sentenceToCountWords = Program.GetSentenceFromUser();

            // Split the sentence by spaces to get all words
            string[] words = sentenceToCountWords.Split();
            int wordsNumber = words.Length;

            // Get rid of "ghost" words:
            foreach (string word in words)
            {
                if (word == string.Empty)
                {
                    --wordsNumber;
                }
            }

            // Show the final words count
            string outputStr = string.Format("The number of words in the sentence is: {0}", wordsNumber);
            Program.PromptMessage(outputStr);
        }
    }
}
