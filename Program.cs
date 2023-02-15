using System;


namespace NumberGuesser
{
  class Program
  {

    static string UnknownCommand(string prompt)
    {
      Console.WriteLine(prompt);
      var userInput = Console.ReadLine();

      return userInput;
    }

    static void Main(string[] args)
    {
      
      Console.WriteLine("Hello! Welcome to my Guessing Game, where I will try to guess a number you're thinking about!");
      Console.Write("Please think of number between 1-1024. Enter GO when you are ready: ");
      
      bool userCommand = false; 
      var userInput = Console.ReadLine();
      var upperCaseUserInput = userInput.ToUpper();

      var firstWrongAnswer = UnknownCommand("I'm sorry, I do not understand. Please enter GO when you are ready: ");

      while (userCommand == false)
      {
        if ( upperCaseUserInput == "GO")
        {
          Console.WriteLine("Lets play!");
          userCommand = true;
        }
        else
        {
          Console.WriteLine(firstWrongAnswer);
        }
      }
      

      /*Console.WriteLine(greeting);

      Console.Write(prompt user to guess, tell user to enter GO when ready);
      Console.ReadLine(userInput);
      If user enters Go, continue to next step to initiate while loop. else run UnknownCommand method
      */

    }
  }
}
