using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Field
    {
        private const int width = 60;
        private const int height = 29;

        public static int Width { get { return width; } }
        public static int Heigth { get { return height; } }

        public static void CreateField()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == height - 1 || i == 0 || j == 0 || j == width - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(width + 5, 0);
            Console.WriteLine("Rules: If snake has stopped, press any button");
        }
        public static Point GenerateEat()
        {
            Random randomEat = new Random();
            Point eatPoint = new Point();
            eatPoint.X = randomEat.Next(1, width - 1);
            eatPoint.Y = randomEat.Next(1, height - 1);
            Console.SetCursorPosition(eatPoint.X, eatPoint.Y);
            Console.Write("*");
            return eatPoint;
        }

    }
}
