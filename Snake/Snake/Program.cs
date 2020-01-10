using System;


namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Field.CreateField();
            Snake.CreateSnake();
            Snake.Side = "left";
            Game.StartGame();
            Game.Crashed = false;
            while (true)
            {
                if (Game.Crashed)
                {
                    break;
                }
                CheckButtons();
            }
            PrintResult();
            Console.ReadKey();
        }
        public static void PrintResult()
        {
            Console.SetCursorPosition(70, 5);
            Console.WriteLine($"Your score = {Snake.snakeBody.Count}");
        }
        public static void CheckButtons()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            Game.CanPressButton = false;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (Snake.Side == "down")
                        {
                            break;
                        }
                        Snake.Side = "up";
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (Snake.Side == "up")
                        {
                            break;
                        }
                        Snake.Side = "down";
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        if (Snake.Side == "right")
                        {
                            break;
                        }
                        Snake.Side = "left";
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (Snake.Side == "left")
                        {
                            break;
                        }
                        Snake.Side = "right";
                        break;
                    }
            }
        }
    }
}
