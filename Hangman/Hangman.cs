﻿using System;
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
            // take a random word
            // todo
            _word = "gerwin";
            _guessed = new List<char>();

            // set guessed word to underscores
            for (int i = 0; i < _word.Length; i++)
                _guessedword += "_";

            // by default, the player gets 11 tries.
            _movesleft = 11;
        }

        public int WordSize()
        {
            return _word.Length;
        }

        public bool MovesLeft()
        {
            if (!_guessedword.Contains('_'))
                return false;

            return _movesleft >= 1;
        }

        public bool Won()
        {
            if (!_guessedword.Contains('_'))
                return true;

            return false;
        }

        public bool GuessWord(string word)
        {
            if (_word == word)
            {
                return true;
            }

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

            Console.WriteLine("Word: {0}", _guessedword);
            _movesleft -= 1;

            // return false (incorrect guess)
            return result;
        }
    }
}
