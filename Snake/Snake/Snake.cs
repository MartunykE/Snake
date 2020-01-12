using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    class Snake
    {
        public string Side { get; set; }
        private object Block = new object();
        public Snake(string side)
        {
            Side = side;
        }

        public List<Point> snakeBody = new List<Point>();
        public void AddPart(Point eatPoint)
        {
            Point part = new Point();
            switch (Side)
            {
                case "left":
                    {
                        part.Y = snakeBody[snakeBody.Count - 1].Y;
                        part.X = snakeBody[snakeBody.Count - 1].X - 1;
                        break;
                    }
                case "right":
                    {
                        part.Y = snakeBody[snakeBody.Count - 1].Y;
                        part.X = snakeBody[snakeBody.Count - 1].X + 1;
                        break;
                    }
                case "up":
                    {
                        part.X = snakeBody[snakeBody.Count - 1].X;
                        part.Y = snakeBody[snakeBody.Count - 1].Y - 1;
                        break;
                    }
                case "down":
                    {
                        part.X = snakeBody[snakeBody.Count - 1].X;
                        part.Y = snakeBody[snakeBody.Count - 1].Y - 1;
                        break;
                    }
            }
            snakeBody.Add(part);
        }
        public void CreateSnake()
        {
            Point startPoint = new Point();
            startPoint.X = 30;
            startPoint.Y = 15;
            snakeBody.Add(startPoint);
            Print();
        }

        public void Move(object side)
        {
            // move body
            for (int i = snakeBody.Count - 1; i > 0; i--)
            {
                if (snakeBody[i].X != snakeBody[i - 1].X || snakeBody[i].Y != snakeBody[i - 1].Y)
                {
                    snakeBody[i].X = snakeBody[i - 1].X;
                    snakeBody[i].Y = snakeBody[i - 1].Y;
                }
            }
            // end move body

            // move head
            switch (side as string)
            {
                case "left":
                    {
                        snakeBody[0].X--;
                        break;
                    }
                case "right":
                    {

                        snakeBody[0].X++;
                        break;
                    }
                case "down":
                    {

                        snakeBody[0].Y++;
                        break;
                    }
                case "up":
                    {
                        snakeBody[0].Y--;
                        break;
                    }
            }
            // end move head
        }
        public void Clear()
        {
            for (int i = 0; i < snakeBody.Count; i++)
            {
                Console.SetCursorPosition(snakeBody[i].X, snakeBody[i].Y);
                Console.Write(" ");
            }
        }
        public void Print()
        {

            for (int i = 0; i < snakeBody.Count; i++)
            {

                if (i == 0)
                {
                    Console.SetCursorPosition(snakeBody[i].X, snakeBody[i].Y);
                    Console.Write("@");
                }
                else
                {
                    Console.SetCursorPosition(snakeBody[i].X, snakeBody[i].Y);
                    Console.Write("#");
                }

            }
        }

    }
}
