using System;

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
            Console.BufferWidth = 60;
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
        }

        static void PlayGame()
        {
            string response = "";
            while (!Exit(response))
            {
                string answer = AskQuestion(difficulty);
            }
        }

        static string[] AskQuestion(string difficulty)
        {
            string[] question
            if (difficulty.Equals("easy"))
            {
                answer = 
            }
            return "";
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
            Console.WriteLine("                         {0} points                         ", score);
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
                                             "Press any key to start the game" }; //TODO: enter directions here

    }
}
