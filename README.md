# NumberGuesser


P

This will be a program that guesses the users number between 1 and 1024. This consists of the computer guessing a number, and the user inputting whether their number is HIGHER, LOWER, or CORRECT. If it is HIGHER, the computer will try to guess a number higher than the one currently guessed. If it is LOWER, it will try to guess a number lower than the one currently guessed. If it it is CORRECT, it will display a gloating message. 

E

Int guessNumber
int highIndex (to look into generating a number thats higher)
int lowIndex  (to look into generating a number thats lower)
string userInput
randomNumberGenerator of 1024
list int guessedNumbers (keep empty for now)
method ComputeTooLow
method ComputeTooHigh
method VictorySpeech
method UnknownCommand 
bool guessednumber = False; 
Will need Ints (numbers trying to be guessed and compared), strings (to read what the user adds), perhaps a list for keeping track of guesses, methods to organize code 

D

Will use a while statement for looping (while guessedNumber = false, keep guessing until true)
Or maybe a switch statement? 
Use if statements to compare if guessed number is correct
uppercase string input from user
randomNumberGenerator to make sure max is 1024

A

Console.WriteLine(greeting);

Console.Write(prompt user to guess, tell user to enter GO when ready);
Console.ReadLine(userInput);
    If user enters Go, continue to next step to initiate while loop. else run UnknownCommand method

While bool guessedNumber = False; begin below; actually lets do a switch statement
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

C