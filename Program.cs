using System;
using System.Collections.Generic;

namespace NumberGuesser
{
  class Program
  {
    //Creates a greeting method and allows the user to type in what they want the max number of the computer to guess and returns that value entered by user to be re-used
    static string Greeting(string prompt)
    {
      Console.WriteLine("Hello! Welcome to my Guessing Game, where I will try to guess a number you're thinking about!");
      Console.Write(prompt);

      var response = Console.ReadLine();

      return response;
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
      var maxNumberResponse = Greeting("What is the max number you would like for me to guess? ");
      Console.Write($"Please think of a WHOLE number between 1 - {maxNumberResponse}. Enter GO when you are ready: ");
      
      //Creates a boolean statement that will be used for the while statement below    
      bool userCommand = false; 
      //While statement that reads user's input to start the guessing process when they are ready.
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

      //Turns response from user about max number range into a double to be used in a list later for math
      double parsedResponse = double.Parse(maxNumberResponse);
      //Creates two new lists to keep track of. The first list will keep track of the minimum and maximum value. The 2nd list keeps track of the guessed numbers to count later.
      var minMaxValueNumbers = new List<double>() {1, parsedResponse};
      var guessedNumbers = new List<double>();

      //Start of formula to guess person's number
      bool nextUserCommand = false;
      while (nextUserCommand == false)
      {
        //Formula that calculates a new number to guess
        double newGuessNumber = Math.Round((minMaxValueNumbers[0] + minMaxValueNumbers[1]) / 2);

        Console.WriteLine($"Is the number you're thinking {newGuessNumber}?");
        Console.Write($"Please enter HIGHER, if the number you're thinking of is higher then {newGuessNumber}, LOWER if it is lower than {newGuessNumber}, or CORRECT if I am right: ");
        //Reads the user input and turns it into all caps to be matched to if statements
        var otherUserInput = Console.ReadLine();
        var otherUpperCaseUserInput = otherUserInput.ToUpper();

        if (otherUpperCaseUserInput == "HIGHER")
        {
          guessedNumbers.Add(newGuessNumber);
          minMaxValueNumbers[0] = Math.Round(((minMaxValueNumbers[0] + minMaxValueNumbers[1]) / 2) + 1);
        }
        else if (otherUpperCaseUserInput == "LOWER")
        {
          guessedNumbers.Add(newGuessNumber);
          minMaxValueNumbers[1] = Math.Round(((minMaxValueNumbers[0] + minMaxValueNumbers[1]) / 2) - 1);
        }
        else if (otherUpperCaseUserInput == "CORRECT")
        {
          guessedNumbers.Add(newGuessNumber);
          var amountOfNumbersGuessed = guessedNumbers.Count; 

          Console.WriteLine($"Hurrah! I am victorious and glorious! That only took me {amountOfNumbersGuessed} tries!");
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
