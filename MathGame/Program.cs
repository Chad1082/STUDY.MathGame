using System;
using System.Linq.Expressions;

namespace MathGame
{
    internal class Program
    {

        static List<string> gameList = new List<string>();

        static void Main(string[] args)
        {
            

            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            var date = DateTime.UtcNow;

            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Hello {name}, Welcome to the Math's game, it is now {date}");
            Console.WriteLine("\n");

            bool gameRunning = true;

            do
            {
                ShowMainMenu();
                Console.Clear();
            } while (gameRunning);
            
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine(@"What game would you like to play? Select an option from below:
            A - Addition
            S - Subtraction
            M - Multiplication
            D - Division
            V - View previous scores
            Q - Quit the game :(");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\n");

            string menuOption = Console.ReadLine();
            if (menuOption == null)
            {
                menuOption = "";
            }

            switch (menuOption.Trim().ToUpper())
            {
                case "A":
                    AdditionGame("Addition Game\n");
                    Console.Clear();
                    break;
                case "S":
                    SubtractionGame("Subtraction Game\n");
                    break;
                case "M":
                    MultiplicationGame("Multiplication Game\n");
                    break;
                case "D":
                    DivisionGame("Division Game\nAll answers should be whole numbers!\n");
                    
                    break;
                case "V":
                    ShowScores();

                    break;
                case "Q":
                    Console.WriteLine("Goodbye!");
                    //gameRunning = false;
                    Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("Unrecognised input, Please select an option from the menu. ");
                    break;
            }

        }

        private static void ShowScores()
        {
            Console.Clear();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            foreach (var game in gameList)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Press Enter to return to main menu");
            Console.ReadLine();
        }

        public static void AdditionGame(string v)
        {
            Console.Clear();
            Console.WriteLine(v);

            var random = new Random();

            int firstNumber;
            int secondNumber;

            int score = 0;

            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"Round {i}");

                firstNumber = random.Next(1, 11);
                secondNumber = random.Next(1, 11);

                int correctAnswer = firstNumber + secondNumber;

                string playerAnswer;
                do
                {
                    Console.WriteLine($"What is {firstNumber} + {secondNumber} ?");
                    playerAnswer = Console.ReadLine();

                    try
                    {
                        if (int.Parse(playerAnswer) == correctAnswer)
                        {
                            Console.WriteLine($"The answer {playerAnswer} is correct! Well done!\nPress the enter key to continue");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine($"You answered {playerAnswer}, the correct was {correctAnswer}! Try Again!\nPress the enter key to continue");
                        }
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter your answer in a numeric format");
                        playerAnswer = "";
                    }

                } while (playerAnswer == "");


            }

            AddGameScore(score,"Addition");

            
            Console.WriteLine($"You scored: {score} out of 4!");
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();


        }

        private static void AddGameScore(int score, string gameName)
        {
            gameList.Add($"{DateTime.Now} - {gameName}: {score} points.");
        }

        private static void SubtractionGame(string v)
        {
            Console.Clear();
            Console.WriteLine(v);

            var random = new Random();

            int firstNumber;
            int secondNumber;

            int score = 0;

            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"Round {i}");

                firstNumber = random.Next(1, 11);
                secondNumber = random.Next(1, 11);

                int correctAnswer = firstNumber - secondNumber;

                string playerAnswer;
                do
                {
                    Console.WriteLine($"What is {firstNumber} - {secondNumber} ?");
                    playerAnswer = Console.ReadLine();

                    try
                    {
                        if (int.Parse(playerAnswer) == correctAnswer)
                        {
                            Console.WriteLine($"The answer {playerAnswer} is correct! Well done!\nPress the enter key to continue");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine($"You answered {playerAnswer}, the correct was {correctAnswer}! Try Again!\nPress the enter key to continue");
                        }
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter your answer in a numeric format");
                        playerAnswer = "";
                    }

                } while (playerAnswer == "");


            }
            AddGameScore(score, "Subtraction");
            Console.WriteLine($"You scored: {score} out of 4!");
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();


        }

        private static void MultiplicationGame(string v)
        {
            Console.Clear();
            Console.WriteLine(v);

            var random = new Random();

            int firstNumber;
            int secondNumber;

            int score = 0;

            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"Round {i}");

                firstNumber = random.Next(1, 11);
                secondNumber = random.Next(1, 11);

                int correctAnswer = firstNumber * secondNumber;

                string playerAnswer;
                do
                {
                    Console.WriteLine($"What is {firstNumber} * {secondNumber} ?");
                    playerAnswer = Console.ReadLine();

                    try
                    {
                        if (int.Parse(playerAnswer) == correctAnswer)
                        {
                            Console.WriteLine($"The answer {playerAnswer} is correct! Well done!\nPress the enter key to continue");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine($"You answered {playerAnswer}, the correct was {correctAnswer}! Try Again!\nPress the enter key to continue");
                        }
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter your answer in a numeric format");
                        playerAnswer = "";
                    }

                } while (playerAnswer == "");


            }
            AddGameScore(score, "Multiplication");
            Console.WriteLine($"You scored: {score} out of 4!");
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();


        }

        private static void DivisionGame(string v)
        {
            Console.Clear();
            Console.WriteLine(v);

            //var random = new Random();

            int firstNumber;
            int secondNumber;

            int score = 0;

            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"Round {i}");

                var gameNumbers = GetDivisionNumbers();

                firstNumber = gameNumbers[0];
                secondNumber = gameNumbers[1];

                int correctAnswer = firstNumber / secondNumber;

                string playerAnswer;
                do
                {
                    Console.WriteLine($"What is {firstNumber} / {secondNumber} ?");
                    playerAnswer = Console.ReadLine();

                    try
                    {
                        if (int.Parse(playerAnswer) == correctAnswer)
                        {
                            Console.WriteLine($"The answer {playerAnswer} is correct! Well done!\nPress the enter key to continue");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine($"You answered {playerAnswer}, the correct was {correctAnswer}! Try Again!\nPress the enter key to continue");
                        }
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter your answer in a numeric format");
                        playerAnswer = "";
                    }

                } while (playerAnswer == "");


            }
            AddGameScore(score, "Division");
            Console.WriteLine($"You scored: {score} out of 4!");
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();


        }

        private static int[] GetDivisionNumbers() {
            var random = new Random();



            int firstNumber = random.Next(1, 100); ;
            int secondNumber = random.Next(1, 100); ;

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 100);
                secondNumber = random.Next(1, 100);
            }

            var result = new int[2];

            result[0] = firstNumber;
            result[1] = secondNumber;

            //foreach (var number in result)
            //{
            //    Console.WriteLine($"Array: {number}");
            //}
            
            return result;
        }
    }
}