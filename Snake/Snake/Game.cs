using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    class Game
    {
        private Timer timer;
        private int startSpeed;
        private int speedUp;
        private int speedUpPoint;
        Field field;
        Snake snake;
        private Point eatPoint;
        private bool firstStart;
        public Game(Field field, Snake snake, int startSpeed, int speedUp, int speedUpPoint)
        {
            this.field = field;
            this.snake = snake;
            this.startSpeed = startSpeed;
            this.speedUp = speedUp;
            this.speedUpPoint = speedUpPoint;
            eatPoint = new Point();
            firstStart = true;
            Crashed = false;
            CanPressButton = true;
        }
        public bool Crashed { get; set; }
        public bool CanPressButton { get; set; }

        public void StartGame()
        {
            timer = new Timer(startSpeed);
            timer.Elapsed += TimerTick;
            timer.Enabled = true;
        }

        private void TimerTick(object source, ElapsedEventArgs e)
        {
            if (firstStart)
            {
                eatPoint = field.GenerateEat();
                firstStart = false;
            }
            if (snake.snakeBody.Count > speedUpPoint && (startSpeed - speedUp) > 0)
            {
                timer.Interval = startSpeed - speedUp;
                speedUp += speedUp;
                speedUpPoint += speedUpPoint;
            } 
            snake.Clear();            
            if (eatPoint.X == snake.snakeBody[0].X && eatPoint.Y == snake.snakeBody[0].Y)
            {
                snake.AddPart(eatPoint);
                eatPoint = field.GenerateEat();
            }
            snake.Move(snake.Side);

            Crash();
            CanPressButton = true;
            if (!Crashed)
            {
                snake.Print();

            }
        }

        private void Crash()
        {
            for (int i = 0; i < snake.snakeBody.Count - 2; i++)
            {
                if (snake.snakeBody[0].X == snake.snakeBody[i + 1].X && snake.snakeBody[0].Y == snake.snakeBody[i + 1].Y)
                {
                    Crashed = true;
                    timer.Stop();
                    CanPressButton = false;
                    return;
                }
            }
            if (snake.snakeBody[0].Y == 0 || snake.snakeBody[0].Y == field.Heigth - 1 || snake.snakeBody[0].X == 0 || snake.snakeBody[0].X == field.Width - 1)
            {
                Crashed = true;
                timer.Stop();
                CanPressButton = false;
                return;
            }
            CanPressButton = true;
            Crashed = false;
        }
    }
}
