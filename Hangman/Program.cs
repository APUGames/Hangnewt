using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Introduction, explains rules to the player
            Console.WriteLine("Welcome to Hangman! You will be given a mystery word you have to guess!");
            Console.WriteLine("You have 5 guesses, each incorrect guess will add another limb on our hangman.");
            //List of words that will randomly be chosen for the player to guess in 5 tries
            String[] words = { "Shrek", "Banana", "Monkey", "World", "Dinner" };
            Random rnd = new Random();
            int index = rnd.Next(words.Length);
            String word = words[index];
            char[] right = new char[word.Length];
            int guesscount = 5;
            int correct = 0;
            foreach (char ch in word)
            {
                Console.Write("_");
                correct++;
            }
            for (int rightIndex = 0; rightIndex < right.Length; rightIndex++)
            {
                right[rightIndex] = '_';
            }

            void DisplayRight(char[] values) {
                foreach (char ch in values)
                {
                    Console.Write(ch);
                }
            }
            Console.WriteLine("Letter count is " + word.Length);
            Console.WriteLine("Type your guess below");
            //Loop that runs until the player guesses the correct word or runs out of guesses
            while (guesscount > 0)
            {
                String guess = Console.ReadLine();
                if (guess != null && word.Contains(guess[0]))
                {
                    Console.WriteLine("Correct!");
                    int currentIndex = word.IndexOf(guess[0]);
                    for (int wordIndex = 0; wordIndex < word.Length; wordIndex++)
                    {
                        if (word[wordIndex] == guess[0])
                        {
                            right[wordIndex] = guess[0];
                            correct--;
                        }
                        else
                        {
                            //Console.Write("_");
                        }
                    }
                }
                else
                {
                    guesscount--;
                    Console.WriteLine("Wrong! You have " + guesscount + " guesses left");
                }
                if (correct <= 0)
                {
                    Console.WriteLine(" Congrats! You guessed the word! It was " + word + "!");
                    break;
                }
                DisplayRight(right);
            }
            if (guesscount <= 0)
            {
                Console.WriteLine("You lost and now you're dead! The word was " + word);
            }
        }
    }
}
