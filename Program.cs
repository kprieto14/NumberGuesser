using System;


namespace NumberGuesser
{
  class Program
  {

    static void UnknownCommand()
    {
      Console.WriteLine("I'm sorry, I do not understand. Please enter a command I understand: ");
    }

    static void Main(string[] args)
    {
      //Starts the program with a greeting to let the user know its purpose and read their response
      Console.WriteLine("Hello! Welcome to my Guessing Game, where I will try to guess a number you're thinking about!");
      Console.Write("Please think of a WHOLE number between 1-1024. Enter GO when you are ready: ");

      //Creates a boolean statement that well be used throughout program (hopefully)      
      bool userCommand = false; 

      //While loop that reads user's input to start the guessing process when they are ready. Honestly might change this later to include please press ENTER to start so I can reuse this statement.
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
          UnknownCommand();
        }
      }
      
      //Creates a starting point to guess numbers
      var randomNumberGenerator = new Random();
      var randomNumber = randomNumberGenerator.Next(1024);
      bool nextUserCommand = false;
      Console.WriteLine($"Is the number you're thinking {randomNumber}?");
      Console.WriteLine("Please enter HIGHER, if the number you're thinking of is higher then {randomNumber}, LOWER if if is lower than {randomNumber}, or CORRECT if I am right: ");
      
      var otherUserInput = Console.ReadLine();
      var otherUpperCaseUserInput = otherUserInput.ToUpper();

      while (nextUserCommand == false)
      {
        var otherUserInput = Console.ReadLine();
        var otherUpperCaseUserInput = otherUserInput.ToUpper();

        if (otherUpperCaseUserInput == "HIGHER")
        {
          Console.WriteLine("Good try.");
          nextUserCommand = true;
        }
        if (otherUpperCaseUserInput == "LOWER")
        {
          Console.WriteLine("Another good try.");
          nextUserCommand = true;
        }
        if (otherUpperCaseUserInput == "CORRECT")
        {
          Console.WriteLine("HAHAHAHA IM BETTER THAN YOU");
          nextUserCommand = true;
        }
        else
        {
          Console.WriteLine("Enter another phrase.");
        }
      }

      
      /*While bool guessedNumber = False; begin below
    generateRandomNumber as a starting point, display code that reads, is your number {guessedNumber}, please enter HIGHER, LOWER, or CORRECT
    readLine();
        if (HIGHER)
        {
            WriteLine ("Golly gee, let me try again")
            guessedNumber = False;
            ComputeTooHigh();
        }
        if (LOWER)
        {
            WriteLine("Shoot, lets try again.")
            guessedNumber = False;
        }
        if (CORRECT)
        {
            VictorySpeech();
            guessedNumber = True;
        }
        else
        {
            UnknownCommand();
        }
      */

    }
  }
}
