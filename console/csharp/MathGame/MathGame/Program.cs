using System;
using System.Threading;

namespace MathGame
{
    class Program
    {
        public static string playerName;
        public static int score;
        public static string difficulty;

        static void Main()
        {
            InitializeConsole();
            StartGame();
        }

        static void InitializeConsole()
        {
            Console.Title = "The Math Game";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void StartGame()
        {
            score = 0;
            difficulty = "easy";

            PrintMenuPage(Message.welcome);
            Console.ReadKey();

            PrintMenuPage(Message.questionName);
            playerName = Console.ReadLine();
            Salutation();
        }

        static void Salutation()
        {
            PrintMenuPage(Message.salutation());
            string response = Console.ReadLine();

            if (Yes(response))
            {
                PrintMenuPage(Message.directions);
                Console.ReadKey();
                PlayGame();
            }
            else if (No(response))
            {
                PlayGame();
            }
            else
            {
                Salutation();
            }
            StartGame();
        }

        static void PlayGame()
        {
            string response = "";
            bool correct = false;
            Question question = new Question(difficulty);

            while (score < 100)
            {
                if (correct)
                {
                    question = new Question(difficulty);
                }

                PrintGamePage(question.question);
                response = Console.ReadLine();

                if (Exit(response))
                {
                    PrintGamePage(Message.exit);
                    response = Console.ReadLine();
                    if (Yes(response))
                    {
                        break;
                    }
                }
                else if (response.Equals(question.answer))
                {
                    correct = true;
                    score += 3;
                    PrintGamePage(Message.correctAnswer(response));
                    Console.ReadKey();
                }
                else
                {
                    correct = false;
                    score -= 1;
                    PrintGamePage(Message.incorrectAnswer(response));
                    Console.ReadKey();
                }
            }
            PrintMenuPage(Message.finalScore());
            Console.ReadKey();
        }

        static bool Yes(string response)
        {
            return (response.Equals("y") || response.Equals("Y") ||
                    response.Equals("yes") || response.Equals("Yes") ||
                    response.Equals("YES") || response.Equals("yeah"));
        }

        static bool No(string response)
        {
            return (response.Equals("n") || response.Equals("N") ||
                    response.Equals("no") || response.Equals("No") ||
                    response.Equals("NO"));
        }

        static bool Exit(string response)
        {
            return (response.Equals("exit") || response.Equals("Exit") ||
                    response.Equals("EXIT") || response.Equals("quit") ||
                    response.Equals("Quit") || response.Equals("QUIT"));
        }

        static void PrintHeader()
        {
            Console.WriteLine("************************************************************\n" +
                              "                        THE MATH GAME                       \n" +
                              "************************************************************");
        }

        static void PrintScore()
        {
            Console.WriteLine(FormatCenter(playerName + " has " + score + " points"));
        }

        static void PrintMenuPage(string[] content)
        {
            Console.Clear();
            PrintHeader();
            Console.WriteLine("\n\n\n\n");
            foreach (string c in content)
            {
                Console.WriteLine(FormatCenter(c));
            }
        }

        static void PrintGamePage(string[] content)
        {
            Console.Clear();
            PrintHeader();
            PrintScore();
            Console.WriteLine("\n\n\n");
            foreach (string c in content)
            {
                Console.WriteLine(FormatCenter(c));
            }
        }

        static string FormatCenter(string s)
        {
            return s; //TODO: add text centering
        }

    }

    class Message
    {
        public static string[] welcome = { "Welcome to The Math Game",
                                           "Press any key to Start" };

        public static string[] questionName = { "What is your name?" };

        public static string[] salutation()
        {
            string[] sal = { "Hello " + Program.playerName + "!", "Do you need any directions to before you play?" };
            return sal;
        }

        public static string[] directions = {"TODO: enter directions here",
                                             "Type EXIT or QUIT to return to the start page at any time",
                                             "***",
                                             "Press any key to start the game"}; //TODO: enter directions here

        public static string[] exit = { "Are you sure you want to exit the current game?", "Your current score will be lost" };

        public static string[] correctAnswer(string response)
        {
            string[] msg = { "Great Job " + Program.playerName + "!", response + " is the correct Answer", "You have just earned 3 points", "", "Press any key to continue" };
            return msg;
        }

        public static string[] incorrectAnswer(string response)
        {
            string[] msg = { "Good Try " + Program.playerName + ",", "but " + response + " is not the correct answer", "Give it another try!!", "", "Press any key to continue" };
            return msg;
        }

        public static string[] finalScore()
        {
            string[] msg = { "Awesome your final score is: " + Program.score, "", "Press any key to continue" };
            return msg;
        }
            
    }

    class Question
    {
        public string[] question;
        public string answer;

        public Question(string difficulty)
        {
            Random randomInt = new Random();
            int a = 1;
            int b = 1;

            if (difficulty.Equals("easy"))
            {
                a = randomInt.Next(1, 10);
                b = randomInt.Next(1, 10);
            }

            question = new string[1];
            question[0] = (a + " x " + b + " =");

            answer = (a * b).ToString();
        }
    }
}
