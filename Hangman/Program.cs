﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static Hangman game = new Hangman();

        static void Main(string[] args)
        {
            while (game.MovesLeft())
            {
                string input = Console.ReadLine();

                if (input.Length >= 2)
                {
                    // Console.WriteLine("");
                }
                else if (input.Length == 1)
                {
                    if (game.Guess(input[0]))
                        Console.WriteLine("Correct!");
                    else
                        Console.WriteLine("Wrong!");
                }
            }

            if (game.Won())
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You're out of lives!");
            }

            Console.ReadLine();
        }
    }
}
