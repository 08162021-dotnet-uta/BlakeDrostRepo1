using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      do
      {
        //Create random number between 0-100, including 0 and 100
        int randomNumber = GetRandomNumber();
        //Create a list of guesses
        List<int> guesses = new List<int>();
        //Create a variable to store user's guess
        int curGuess;
        //Explain the rules to the user
        Console.WriteLine("*****************************************************");
        Console.WriteLine("Welcome to the Guessing Game!");
        Console.WriteLine("Your objective is to guess a number from 0 to 100.");
        Console.WriteLine("You only have 10 tries to guess the right number.");
        Console.WriteLine("Note: 0 and 100 are potentially the mystery number!");
        for (int round = 1; round <= 10; round++)
        {
          curGuess = GetUsersGuess();
          //The guess is too high
          if (CompareNums(randomNumber, curGuess) == -1)
          {
            Console.WriteLine("Your guess was too high.");
            guesses.Add(curGuess);
          }
          //The guess is too low
          else if (CompareNums(randomNumber, curGuess) == 1)
          {
            Console.WriteLine("Your guess was too low.");
            guesses.Add(curGuess);
          }
          //The guess is CORRECT!
          else
          {
            Console.WriteLine("You guessed the correct number!");
            Console.WriteLine($"Your guess: {curGuess}. Mystery number: {randomNumber}. Total tries: {guesses.Count + 1}.");
            break;
          }
          Console.WriteLine("Previous guesses: " + GetPreviousGuesses(guesses));
        }
        if (guesses.Count == 10 && guesses[9] != randomNumber)
        {
          Console.WriteLine("You have failed to guess the mystery number.");
          Console.WriteLine($"The mystery number is {randomNumber}.");
        }
      }
      while (PlayGameAgain());

    }

    /// <summary>
    /// This method returns a randomly chosen number between 1 and 100, inclusive.
    /// </summary>
    /// <returns></returns>
    public static int GetRandomNumber()
    {
      var num = new Random();
      return (int)num.Next(101);
    }

    /// <summary>
    /// This method gets input from the user, 
    /// verifies that the input is valid and 
    /// returns an int.
    /// </summary>
    /// <returns></returns>
    public static int GetUsersGuess()
    {
      int guess = 0;
      string userInput;
      bool flag = true;
      while (flag)
      {
        Console.Write("Enter a guess: ");
        userInput = Console.ReadLine();
        if (int.TryParse(userInput, out guess))
        {
          if (guess >= 0 && guess <= 100)
          {
            flag = false;
          }
          else
          {
            Console.WriteLine($"Input must be a number from 0 to 100\n Your input: {userInput}");
          }
        }
        else
        {
          Console.WriteLine($"Input must be an integer\n Your input: {userInput}");
        }
      }
      return guess;
    }

    /// <summary>
    /// This method will has two int parameters.
    /// It will:
    /// 1) compare the first number to the second number
    /// 2) return -1 if the first number is less than the second number
    /// 3) return 0 if the numbers are equal
    /// 4) return 1 if the first number is greater than the second number
    /// </summary>
    /// <param name="randomNum"></param>
    /// <param name="guess"></param>
    /// <returns></returns>
    public static int CompareNums(int randomNum, int guess)
    {
      if (randomNum < guess)
      {
        return -1;
      }
      else if (randomNum == guess)
      {
        return 0;
      }
      else
      {
        return 1;
      }
    }

    public static bool PlayGameAgain()
    {
      string userInput;
      Console.Write("Enter Y or y to play again. Enter any key to quit: ");
      userInput = Console.ReadLine();
      return (userInput == "Y" || userInput == "y") ? true : false;
    }

    public static string GetPreviousGuesses(List<int> guesses)
    {
      string stuff = "";
      for (int index = 0; index < guesses.Count; index++)
      {
        if (index == guesses.Count - 1)
        {
          stuff += guesses[index];
        }
        else
        {
          stuff += guesses[index] + ", ";
        }
      }
      return stuff;
    }
  }
}
