using System;
using System.Collections.Generic;

namespace NumberGuesser
{
  class Program
  {
    //Creates a greeting method and allows the user to type in what they want the max number of the computer to guess and returns that value entered by user to be re-used
    static double Greeting(string prompt)
    {
      Console.Write(prompt);

      double response;
      double backupNumber = 1024;

      var isThisResponseValid = double.TryParse(Console.ReadLine(), out response);

      if (isThisResponseValid)
      {
         return response;
      }      
      else
      {
        Console.WriteLine("I'm sorry, I do not understand. I will assume you mean 1024.");
        return backupNumber;
      }
    }

    //Creates a method that calls back when the user attempts to enter text not recognized by program and returns nothing.
    static string UnknownCommand(string prompt)
    {
      Console.WriteLine(prompt);

      return null;
    }

    //The method that houses all the code I worked on before to be repeated if the user wants to re-start the game.
    static void guessingGame()
    {
      //Starts the program with a greeting to let the user know its purpose and read their response
      var maxNumberResponse = Greeting("What is the max number you would like for me to guess? ");

      //Turns response from user about max number range into a double to be used in a list later for math, and then calculates how many tries should occur according to the Binary Search theory.
      double estimatedNumberOfTries = Math.Ceiling(Math.Log2(maxNumberResponse));

      Console.WriteLine($"That should only take me about {estimatedNumberOfTries} guesses!"); 
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

      //Creates two new lists to keep track of. The first list will keep track of the minimum and maximum value. The 2nd list keeps track of the guessed numbers to count later.
      var minMaxValueNumbers = new List<double>() {1, maxNumberResponse};
      var guessedNumbers = new List<double>();

      //Start of formula to guess person's number
      bool nextUserCommand = false;
      while (nextUserCommand == false)
      {
        //Formula that calculates a new number to guess, based off the Binary search math equation
        double newGuessNumber = Math.Ceiling((minMaxValueNumbers[0] + minMaxValueNumbers[1]) / 2);

        Console.WriteLine($"Is the number you're thinking {newGuessNumber}?");
        Console.Write($"Please enter HIGHER, if the number you're thinking of is higher then {newGuessNumber}, LOWER if it is lower than {newGuessNumber}, or CORRECT if I am right: ");
        //Reads the user input and turns it into all caps to be matched to if statements
        var otherUserInput = Console.ReadLine();
        var otherUpperCaseUserInput = otherUserInput.ToUpper();

        if (otherUpperCaseUserInput == "HIGHER")
        {
          //Adds the guess number to list to be counted later, formula underneath is to replace the minimum value if the number is higher than what is guessed
          guessedNumbers.Add(newGuessNumber);
          minMaxValueNumbers[0] = Math.Ceiling(((minMaxValueNumbers[0] + minMaxValueNumbers[1]) / 2) + 1);
        }
        else if (otherUpperCaseUserInput == "LOWER")
        {
          //Adds the guess number to list to be counted later, formula underneath is to replace the maximum value if the number is lower than what is guessed
          guessedNumbers.Add(newGuessNumber);
          minMaxValueNumbers[1] = Math.Ceiling(((minMaxValueNumbers[0] + minMaxValueNumbers[1]) / 2) - 1);
        }
        else if (otherUpperCaseUserInput == "CORRECT")
        {
          guessedNumbers.Add(newGuessNumber);
          var amountOfNumbersGuessed = guessedNumbers.Count; 

          //Nested if statement for fun, compares if program accurately guessed how long it would take to guess and curates a response accordingly.
          if (estimatedNumberOfTries == amountOfNumbersGuessed)
          {
            Console.WriteLine($"Hurrah! I am victorious and glorious! Looks like I was right! That only took me {amountOfNumbersGuessed} tries!");
            nextUserCommand = true;
          }
          else
          {
            Console.WriteLine($"Uh oh, looks like I was off by a little bit! That actually took me {amountOfNumbersGuessed} tries!");
            nextUserCommand = true;
          }
        }
        else
        {
          var answer = UnknownCommand($"I am not sure what you are saying. Please enter a valid response.");
        }
      }
    }
    static void Main(string[] args)
    {
      Console.WriteLine("Hello! Welcome to my Guessing Game, where I will try to guess a number you're thinking about!");
      guessingGame();

      bool playAgain = true;
      while (playAgain == true)
      {
        //Once game finishes, this is block of code that asks user if they would like to replay and adjusts accordingly.
        Console.WriteLine("Would you like to play again? Enter YES to restart or NO to quit.");
        var repeatAgainResponse = Console.ReadLine();
        var repeatResponseUpper = repeatAgainResponse.ToUpper();

        if (repeatResponseUpper == "YES")
        {
          //Use this line to add amountof#guessed into a list before starting program over. Also create the list too!
          guessingGame();
        }
        else if (repeatResponseUpper == "NO")
        {
          //Use this line to calculate average of list from amount of games played. Might need to use FOR loop to go through list. 
          Console.Write("It was fun to play with you! Come back anytime!");
          playAgain = false;
        }
        else 
        {
          var answer = UnknownCommand("I'm sorry, I do not understand.");
        }
      }
    }
  }
}
