using randomgame;
using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace MyApp
{
    internal class Program
    {
        public static RandEvent redEvent = new RandEvent(ConsoleColor.Red, "Quick maths game");
        public static RandEvent greenEvent = new RandEvent(ConsoleColor.Green, "Quick blackjack game");
        public static RandEvent blueEvent = new RandEvent(ConsoleColor.Blue, "Quick memory game");


        static void Main(string[] args)
        {
            int liner = 1;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("RANDOM GAME\n\n\n");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Black;
            string typeWriter = "Press a key to begin...";
            for (int i = 0; i < typeWriter.Length; i++)
            {
                Console.Write(typeWriter[i]);
                Thread.Sleep(50);
            }
            Console.ReadKey();
            Console.Clear();
            Menu(liner);
        }

        static void Menu(int liner)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Random Game");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n-Play Game\nLoad Game\nGame Info");
            Console.ResetColor();
            ConsoleKey key;
            bool optionSelected = false;
            while (optionSelected == false)
            {
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.S:
                        liner++;
                        if (liner == 4)
                        {
                            liner--;
                        }
                        NewOption(liner);
                        break;
                    case ConsoleKey.W:
                        liner--;
                        if (liner == 0)
                        {
                            liner++;
                        }
                        NewOption(liner);
                        break;
                    case ConsoleKey.DownArrow:
                        liner++;
                        if (liner == 4)
                        {
                            liner--;
                        }
                        NewOption(liner);
                        break;
                    case ConsoleKey.UpArrow:
                        liner--;
                        if (liner == 0)
                        {
                            liner++;
                        }
                        NewOption(liner);
                        break;
                    case ConsoleKey.Enter:
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            optionSelected = true;
                            if (liner == 1)
                            {
                                PlayGame();
                            }
                            else if (liner == 2)
                            {
                                LoadGame();
                            }
                            else if (liner == 3)
                            {
                                GameInfo(liner);
                            }
                            break;
                        }
                }
            }
        }
        static int NewOption(int liner)
        {
            Console.Clear();
            if (liner == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Welcome to Random Game");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n-Play Game\nLoad Game\nGame Info");
                Console.ResetColor();
            }
            else if (liner == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Welcome to Random Game");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPlay Game\n-Load Game\nGame Info");
                Console.ResetColor();
            }
            else if (liner == 3)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Welcome to Random Game");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPlay Game\nLoad Game\n-Game Info");
                Console.ResetColor();
            }
            return liner;
        }

        static void GameInfo(int liner)
        {
            Console.WriteLine("This is a game made by the BEST programmer of all time.");
            Console.WriteLine("Press a key to continue.");
            Console.ReadKey();
            Console.Clear();
            liner = 1;
            Menu(liner);
        }
        static void LoadGame()
        {

        }

        static void PlayGame()
        {

            RandEvent currentEvent = new RandEvent(ConsoleColor.Red, "dhinoshan");

            int currentXPos = 0;
            int currentYPos = 0;

            Console.WriteLine("You are the X on the map.");
            Console.WriteLine("Walk towards the S to save.");
            Console.WriteLine("Walk towards the O for an event.");
            string[,] grid = new string[9, 9];
            Random rnd = new Random();
            int eventXPos = rnd.Next(0, 9);
            int eventYPos = rnd.Next(0, 9);
            int saveXPos = rnd.Next(0, 9);
            int saveYPos = rnd.Next(0, 9);
            while ((eventXPos == saveXPos && eventYPos == saveYPos) || (eventXPos == 0 && eventYPos == 0) || (saveXPos == 0 && saveYPos == 0))
            {
                eventXPos = rnd.Next(0, 9);
                eventYPos = rnd.Next(0, 9);
            }
            // create grid
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    grid[x, y] = "-";
                }
                Console.WriteLine();
            }

            // set the start position of event, save and character.
            grid[eventXPos, eventYPos] = "O";
            grid[saveXPos, saveYPos] = "S";
            grid[0, 0] = "X";
            string[,] newGrid = grid;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (grid[x, y] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (grid[x, y] == "S")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (grid[x, y] == "O")
                    {
                        CreateEvent(currentEvent);
                        Console.ForegroundColor = currentEvent.colour;
                    }
                    Console.Write(grid[x, y]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            MovePlayer(grid, currentEvent);


        }
        public static RandEvent CreateEvent(RandEvent currentEvent)
        {
            Random rnd = new Random();
            int randomisedNum = rnd.Next(1, 3);
            if (randomisedNum == 1)
            {
                currentEvent.colour = redEvent.colour;
                currentEvent.desc = redEvent.desc;
            }
            else if (randomisedNum == 2)
            {
                currentEvent.colour = greenEvent.colour;
                currentEvent.desc = greenEvent.desc;
            }
            else if (randomisedNum == 3)
            {
                currentEvent.colour = blueEvent.colour;
                currentEvent.desc = blueEvent.desc;
            }
            return currentEvent;
        }
        public static void MovePlayer(string[,] grid, RandEvent currentEvent)
        {
            bool eventFound = false;
            int currentXPos = 0;
            int currentYPos = 0;
            ConsoleKey key;
            while (eventFound == false)
            {
                key = Console.ReadKey(true).Key;
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; x < 9; x++)
                    {
                        if (grid[x, y] == "X")
                        {
                            currentXPos = 0;
                            currentYPos = 0;
                        }
                    }
                }
                switch (key)
                {
                    case (ConsoleKey.W | ConsoleKey.UpArrow):
                        {
                            if (currentYPos - 1 > 0)
                            {
                                currentYPos--;
                                grid[currentYPos, currentXPos] = "-";
                                grid[currentYPos + 1, currentXPos] = "X";
                            }
                            break;
                        }
                    case ConsoleKey.A | ConsoleKey.LeftArrow:
                        {
                            if (currentXPos - 1 > 0)
                            {
                                currentXPos--;
                                grid[currentYPos, currentXPos] = "-";
                                grid[currentYPos, currentXPos - 1] = "X";
                            }
                            break;
                        }
                    case ConsoleKey.D | ConsoleKey.RightArrow:
                        {
                            if (currentXPos + 1 < 9)
                            {
                                currentXPos++;
                                grid[currentYPos, currentXPos] = "-";
                                grid[currentYPos, currentXPos + 1] = "X";
                            }
                            break;
                        }

                    case ConsoleKey.S | ConsoleKey.DownArrow:
                        {
                            if (currentYPos + 1 < 9)
                            {
                                currentYPos--;
                                grid[currentYPos, currentXPos] = "-";
                                grid[currentYPos + 1, currentXPos] = "X";
                            }
                            break;
                        }
                }
                Console.Clear();
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        if (grid[x, y] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (grid[x, y] == "S")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (grid[x, y] == "O")
                        {
                            Console.ForegroundColor = currentEvent.colour;
                        }
                        Console.Write(grid[x, y]);
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                if (grid[currentYPos, currentXPos] == "S")
                {
                    eventFound = true;
                    SaveFile();
                }
                else if (grid[currentYPos, currentXPos] == "O")
                {
                    if (currentEvent.colour == ConsoleColor.Red)
                    {
                        MathsGame();
                    }
                    else if (currentEvent.colour == ConsoleColor.Green)
                    {
                        BlackJackGame();
                    }
                    else if(currentEvent.colour == ConsoleColor.Blue)
                    {
                        MemoryGame();
                    }
                }
            if (grid[currentYPos, currentXPos] == "O" | grid[currentYPos, currentXPos] == "S")
                {
                    eventFound = true;
                }
            }
        }
        public static void SaveFile()
        {

        }
        public static void MathsGame()
        {

        }
        public static void BlackJackGame()
        {

        }
        public static void MemoryGame()
        {

        }
    }
}