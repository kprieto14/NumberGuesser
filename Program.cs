using System;
using System.Collections.Generic;

namespace NumberGuesser
{
  class Program
  {
    //Creates a greeting method and allows the user to type in when they are ready.
    static void Greeting()
    {
      Console.WriteLine("Hello! Welcome to my Guessing Game, where I will try to guess a number you're thinking about!");
      Console.Write("Please think of a WHOLE number between 1-1024. Enter GO when you are ready: ");

      //Creates a boolean statement that will be used for the while statement below    
      bool userCommand = false; 

      //While statement that reads user's input to start the guessing process when they are ready. Honestly might change this later to include please press ENTER to start so I can reuse this statement.
      while (userCommand == false)
      {
        var userInput = Console.ReadLine();
        var upperCaseUserInput = userInput.ToUpper();

        if (upperCaseUserInput == "GO")
        {
          Console.WriteLine("Lets play!");
          userCommand = true;
        }
        else
        {
          var answer = UnknownCommand("I'm sorry, I do not understand. Please enter GO when you are ready.");
        }
      }
    }
    //Creates a method that calls back when the user attempts to enter text not recognized by program and returns nothing.
    static string UnknownCommand(string prompt)
    {
      Console.WriteLine(prompt);

      return null;
    }

    static void Main(string[] args)
    {
      //Starts the program with a greeting to let the user know its purpose and read their response
      //Greeting();
      
      //Creates a starting point to guess numbers, asking user if it's their number
      var maxGuessNumber = 1024;
      var startingGuessNumber = 512;

      var guessedNumbers = new List<int>();

      Console.WriteLine($"Is the number you're thinking {startingGuessNumber}?");
      Console.WriteLine("Please enter HIGHER, if the number you're thinking of is higher then {randomNumber}, LOWER if if is lower than {randomNumber}, or CORRECT if I am right: ");

      //Start of formula to guess person's number
      bool nextUserCommand = false;
      while (nextUserCommand == false)
      {
        //Reads the user input and turns it into all caps to be matched to if statements
        var otherUserInput = Console.ReadLine();
        var otherUpperCaseUserInput = otherUserInput.ToUpper();

        if (otherUpperCaseUserInput == "HIGHER")
        {
          guessedNumbers.Add(startingGuessNumber);
          //math
        }
        else if (otherUpperCaseUserInput == "LOWER")
        {
          guessedNumbers.Add(startingGuessNumber);
          
        }
        else if (otherUpperCaseUserInput == "CORRECT")
        {
          guessedNumbers.Add(startingGuessNumber);
          //Code here later to make a variable counting the list to be added to victory speech
          Console.WriteLine("Hurrah! I am victorious and glorious!");
          nextUserCommand = true;
        }
        else
        {
          var answer = UnknownCommand("I am not sure what you are saying. Please enter if some number is HIGHER, LOWER, or CORRECT: ");
        }
      }
      

    }
  }
}
