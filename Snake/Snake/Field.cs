using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Field
    {
        private const int width = 60;
        private const int height = 29;

        public int Width { get { return width; } }
        public int Heigth { get { return height; } }

        public void CreateField()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == height - 1 || i == 0 || j == 0 || j == width - 1)
                    {
                        Console.Write("%");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        public Point GenerateEat()
        {
            Random randomEat = new Random();
            Point eatPoint = new Point();
            eatPoint.X = randomEat.Next(2, width - 1);
            eatPoint.Y = randomEat.Next(2, height - 1);
            Console.SetCursorPosition(eatPoint.X, eatPoint.Y);
            Console.Write("*");
            return eatPoint;
        }

    }
}
