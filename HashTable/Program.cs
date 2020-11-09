using System;

namespace HashTable
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to HashTable!");
            //creating an object of mapnode class
            MyMapNode<string, string> hash = new MyMapNode<string, string>(20);
            //storing the sentence in paragraph variable
            String sentence = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            //using split function , split is mainly used to split string based on the delimiters passed to the string
            string[] paragraphSentence = sentence.Split(' ');
            //gets the length of array string
            int SLength = paragraphSentence.Length;
            // Itreating along each word and adding it to hash set
            for (int i = 0; i < SLength; i++)
            {
                hash.Add(Convert.ToString(i), paragraphSentence[i]);
            }
            //iterating through each loop to get the frequency of each word in the sentence
            foreach (string word in paragraphSentence)
            {
                hash.GetFrequency(word);
            }
            Console.ReadLine();
        }
    }
}





