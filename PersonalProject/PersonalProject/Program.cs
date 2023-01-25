using System;

namespace ski

{
    enum Direction
    {
        None,
        Left,
        Right
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "SKI";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            //플레이어가 움직일 좌우
            const int Max_X = 20;
            const int Min_X = 0;
            Random random = new Random();

            int[] goalPositionsX = { random.Next(1, 20), random.Next(1, 20), random.Next(1, 20) };
            int[] goalPositionsY = { 10, 15, 20 };

            int[] wallPositionX = { random.Next(1, 20), random.Next(1, 20), random.Next(1, 20), random.Next(1, 20), random.Next(1, 20), random.Next(1, 20) };
            int[] wallPositionY = { random.Next(7, 19), random.Next(7, 19), random.Next(7, 19), random.Next(7, 19), random.Next(7, 19), random.Next(7, 19) };

            const string WallIcon = "O";
            const string GoalIcon = "F";

            //플레이어 위치지정
            Direction playerMoveDirection = Direction.None;
            string PlayerIcon = "||";

            int playerX = 10;
            int playerY = 5;

            int Point = 0;
            int blackmark = 0;

            int Gamecount = 0;

            while (true)
            {
                Console.Clear();

                

                RenderObject(playerX, playerY, $"{PlayerIcon}");
                RenderObject(22, 1, $"점수 : {Point}");
                RenderObject(22, 2, $"감점 : {blackmark}");
                int goalCount = goalPositionsX.Length;
                for (int i = 0; i < goalCount; ++i)
                {
                    RenderObject(goalPositionsX[i], goalPositionsY[i], GoalIcon);
                }
                int wallCount = wallPositionX.Length;
                for (int i = 0;(i < wallCount); ++i)
                {
                    RenderObject(wallPositionX[i], wallPositionY[i], WallIcon);
                }

                void RenderObject(int x, int y, string icon)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(icon);
                }

                //-----------------------------------------------

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.LeftArrow)
                {
                    Gamecount++;
                    playerX = Math.Max(Min_X, playerX-1);
                    playerMoveDirection = Direction.Left;
                    PlayerIcon = "//";
                    for (int i = 0; i < wallCount; ++i)
                    {
                        wallPositionY[i] -= 1;
                        
                        if (wallPositionY[i] == 0)
                        {
                            wallPositionY[i] = random.Next(10, 20);
                            wallPositionX[i] = random.Next(1, 20);
                        }
                    }
                    for (int GOAL = 0; GOAL < goalCount; ++GOAL)
                    {
                        goalPositionsY[GOAL] -= 1;
                        if (goalPositionsY[GOAL] == 0)
                        {
                            goalPositionsY[GOAL] = random.Next(10, 20);
                            goalPositionsX[GOAL] = random.Next(1, 20);
                        }
                    }
                }

                if (key == ConsoleKey.RightArrow)
                {
                    Gamecount++;
                    playerX = Math.Min(playerX + 1, Max_X);
                    playerMoveDirection = Direction.Right;
                    PlayerIcon = "\\\\";
                    for (int i = 0; i < wallCount; ++i)
                    {
                        wallPositionY[i] -= 1;
                        if (wallPositionY[i] == 0)
                        {
                            wallPositionY[i] = random.Next(10, 20);
                            wallPositionX[i] = random.Next(1, 20);
                        }
                    }
                    for (int GOAL = 0; GOAL < goalCount; ++GOAL)
                    {
                        goalPositionsY[GOAL] -= 1;
                        if (goalPositionsY[GOAL] == 0)
                        {
                            goalPositionsY[GOAL] = random.Next(10, 20);
                            goalPositionsX[GOAL] = random.Next(1, 20);
                        }
                    }

                }
                for (int j = 0; j < goalCount; ++j) 
                {
                    if (playerX == goalPositionsX[j] && playerY == goalPositionsY[j])
                        Point++;
                }
                for (int h = 0; h< wallCount; ++h) 
                {
                    if (playerX == wallPositionX[h] && playerY == wallPositionY[h])
                        blackmark++;
                }
                
                if (Gamecount == 100)
                {
                    Console.Clear();
                    Console.WriteLine($"점수 : {Point*100-blackmark*20}");
                    break;
                }

            }
        }
    }
}


