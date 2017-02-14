using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Hangman
    {
        private string _word = "";
        private string _guessedword = "";

        private int _movesleft = 0;
        private List<char> _guessed;
        
        public Hangman()
        {
            // download a wordslist
            string wordstring = new System.Net.WebClient().DownloadString("https://raw.githubusercontent.com/Tom25/Hangman/master/wordlist.txt");
            string[] words = wordstring.Split('\n');

            // generate a random index
            int randomWord = new Random().Next(0, words.Length);

            // select the random word
            _word = words[randomWord]; // "gerwin".ToLower();
            _guessed = new List<char>();

            // set guessed word to underscores
            for (int i = 0; i < _word.Length; i++)
            {
                _guessedword += "_";
            }

            // by default, the player gets 11 tries.
            _movesleft = 11;
        }

        public bool MovesLeft()
        {
            // if we won, return false
            if (!_guessedword.Contains('_'))
            {
                return false;
            }

            return _movesleft >= 1;
        }

        public bool Won()
        {
            // if we won, return true
            if (!_guessedword.Contains('_'))
            {
                return true;
            }

            return false;
        }

        public string GetWord()
        {
            return _word;
        }

        public bool GuessWord(string word)
        {
            // if input is equal to word
            if (_word == word)
            {
                _guessedword = word;
                return true;
            }

            // decrement guesses left
            _movesleft -= 1;

            // return false (word incorrect)
            return false;
        }

        public bool Guess(char character)
        {
            bool result = false;

            // check if character has been guessed already
            if (_guessed.Contains(character))
            {
                Console.WriteLine("Already guessed {0}", character);
                _movesleft -= 1;
                return false;
            }

            // add character to guessed array
            _guessed.Add(character);

            // check if character is in the word
            if (_word.Contains(character))
            {
                // convert string to char array
                char[] _tmp = _guessedword.ToCharArray();

                for (int i = 0; i < _word.Length; i++)
                {
                    // set character index if equals
                    if (_word[i] == character)
                    {
                        _tmp[i] = character;
                    }
                }

                // convert temponary char array back to string
                _guessedword = new string(_tmp);

                // return true (correct guess)
                result = true;
            }

            Console.WriteLine("Guesses left: {0}", _movesleft);
            Console.WriteLine("Word: {0}", _guessedword);

            if (!result)
            {
                _movesleft -= 1;
            }

            // return false (incorrect guess)
            return result;
        }
    }
}
