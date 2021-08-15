using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var PlayerOne = "";
            var PlayerTwo = "";
            var PlayerOneChoice = "";
            var PlayerTwoChoice = "";
            Boolean Test = false;

            Console.WriteLine("Introduce name for PlayerOne:");

            PlayerOne = Console.ReadLine();

            Console.WriteLine("Introduce name for PlayerTwo:");

            PlayerTwo = Console.ReadLine();

            Console.WriteLine("Introduce rock/paper/scissors choice for PlayerOne:");

            //PlayerOneChoice = Console.ReadLine();

            ConsoleKeyInfo keyOne;


            do
             {
                do
                {
                    keyOne = Console.ReadKey(true);

                    // Backspace Should Not Work; ((keyOne.Key != ConsoleKey.Backspace) && (keyOne.Key != ConsoleKey.Enter))
                     if (keyOne.Key != ConsoleKey.Backspace)
                         {
                            PlayerOneChoice += keyOne.KeyChar;
                            Console.Write("*");
                         }
                    else
                         {
                            Console.Write("\b");
                         }
                }
                    // Stops Receving Keys Once Enter is Pressed
                while (keyOne.Key != ConsoleKey.Enter);

                if ((PlayerOneChoice != "rock") & (PlayerOneChoice != "paper") & (PlayerOneChoice != "scissors"))
                {
                    Console.WriteLine("Please choose a valid option: rock, paper or scissors!");
                   Test = false;
                }
                else
                {
                    Test = true;
                }

             }
            
            while (Test == false);

            Console.WriteLine();

            //Console.WriteLine("The Choice PlayerOne entered is : " + PlayerOneChoice);
            
            Console.WriteLine();
        
            Console.WriteLine("Introduce rock/paper/scissors choice for PlayerTwo:");

            //PlayerTwoChoice = Console.ReadLine();

            //string pass = "";
            //Console.Write("Enter your password: ");
            ConsoleKeyInfo keyTwo;

            do
            {
                keyTwo = Console.ReadKey(true);

                // Backspace Should Not Work
                if ((keyTwo.Key != ConsoleKey.Backspace) && (keyTwo.Key != ConsoleKey.Enter))
                {
                    PlayerTwoChoice += keyTwo.KeyChar;
                    Console.Write("*");
                }
                else
                {
                Console.Write("\b");
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (keyTwo.Key != ConsoleKey.Enter);

            Console.WriteLine();

           // Console.WriteLine("The Choice PlayerTwo entered is : " + PlayerTwoChoice);

            if (PlayerOneChoice == "rock")
                
                 if (PlayerTwoChoice == "scissors")

                        Console.WriteLine("Congratulations " + PlayerOne + " you are a winner!");

                 else 
                    if (PlayerTwoChoice == "paper")

                        Console.WriteLine("Congratulations " + PlayerTwo + " you are a winner!");

                    else 

                        Console.WriteLine("It's a tie!");

            else 
                if (PlayerOneChoice == "scissors")

                    if (PlayerTwoChoice == "rock")

                        Console.WriteLine("Congratulations " + PlayerTwo + " you are a winner!");

                    else 
                        if (PlayerTwoChoice == "paper")

                        Console.WriteLine("Congratulations " + PlayerOne + " you are a winner!");

                        else 

                        Console.WriteLine("It's a tie!");

                else 
                    if (PlayerTwoChoice == "rock")

                        Console.WriteLine("Congratulations " + PlayerOne + " you are a winner!");

                    else 
                        if (PlayerTwoChoice == "scissors")

                            Console.WriteLine("Congratulations " + PlayerTwo + " you are a winner!");

                        else 

                            Console.WriteLine("It's a tie!");
        }
    }
}
