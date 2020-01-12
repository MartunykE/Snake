using System;
using System.Threading;


namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();
            Snake snake = new Snake("left");
            Game game = new Game(field, snake, 200, 30, 4);
            field.CreateField();
            snake.CreateSnake();
            game.StartGame();
            game.Crashed = false;
            Thread checkCrashThread = new Thread(() => PrintResult(snake, game));
            checkCrashThread.Start();

            while (true)
            {

                if (game.Crashed)
                {
                    break;
                }
                CheckButtons(game, snake);
            }
            Console.ReadKey();
        }

        public static void PrintResult(Snake snake, Game game)
        {
            object block = new object();
            while (true)
            {
                if (game.Crashed)
                {
                    Console.SetCursorPosition(70, 5);
                    Console.WriteLine($"Your score = {snake.snakeBody.Count}");
                    break;
                }
            }

        }
        public static void CheckButtons(Game game, Snake snake)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            game.CanPressButton = false;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (snake.Side == "down")
                        {
                            break;
                        }
                        snake.Side = "up";
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (snake.Side == "up")
                        {
                            break;
                        }
                        snake.Side = "down";
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        if (snake.Side == "right")
                        {
                            break;
                        }
                        snake.Side = "left";
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (snake.Side == "left")
                        {
                            break;
                        }
                        snake.Side = "right";
                        break;
                    }
            }
        }
    }
}
