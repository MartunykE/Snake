﻿using System;
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
        private int startSpeed = 200;
        private int speedUp = 30;
        private int speedUpPoint = 4;
        private Point eatPoint = new Point();
        private bool firstStart = true;
        public bool Crashed { get; set; } = false;
        public bool CanPressButton { get; set; } = true;



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
                eatPoint = Field.GenerateEat();
                firstStart = false;
            }
            if (Snake.snakeBody.Count > speedUpPoint && (startSpeed - speedUp) > 0)
            {

                timer.Interval = startSpeed - speedUp;
                speedUp += speedUp;
                speedUpPoint += speedUpPoint;
            }

            Snake.Clear();
            if (eatPoint.X == Snake.snakeBody[0].X && eatPoint.Y == Snake.snakeBody[0].Y)
            {
                Snake.AddPart(eatPoint);
                eatPoint = Field.GenerateEat();
            }
            Snake.Move(Snake.Side);

            Crash();
            CanPressButton = true;
            Snake.Print();
        }

        private void Crash()
        {
            for (int i = 0; i < Snake.snakeBody.Count - 2; i++)
            {
                if (Snake.snakeBody[0].X == Snake.snakeBody[i + 1].X && Snake.snakeBody[0].Y == Snake.snakeBody[i + 1].Y)
                {
                    Crashed = true;
                    timer.Stop();
                    CanPressButton = false;
                    return;
                }
            }
            if (Snake.snakeBody[0].Y == 0 || Snake.snakeBody[0].Y == Field.Heigth - 1 || Snake.snakeBody[0].X == 0 || Snake.snakeBody[0].X == Field.Width - 1)
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
