using System;
using System.Text;

namespace ski

{
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

            int[] snowPositionsX = { random.Next(1, 20), random.Next(1, 20), random.Next(1, 20), random.Next(1, 20), random.Next(1, 20), random.Next(1, 20) };
            int[] snowPositionsY = { random.Next(7, 19), random.Next(7, 19), random.Next(7, 19), random.Next(7, 19), random.Next(7, 19), random.Next(7, 19) };

            const string SnowIcon = "Ｏ";
            const string GoalIcon = "П";
            
            //플레이어 위치지정
            
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
                RenderObject(22, 3, $"남은거리 : {400 - Gamecount*4}M");
                //골과 눈을 그려준다
                int goalCount = goalPositionsX.Length;
                for (int i = 0; i < goalCount; ++i)
                {
                    RenderObject(goalPositionsX[i], goalPositionsY[i], GoalIcon);
                }
                int snowCount = snowPositionsX.Length;
                for (int i = 0;(i < snowCount); ++i)
                {
                    RenderObject(snowPositionsX[i], snowPositionsY[i], SnowIcon);
                }
                //-----------------------------------------------

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                //-----------------------------------------

                if (key == ConsoleKey.LeftArrow)
                {
                    Gamecount++;
                    playerX = Math.Max(Min_X, playerX-1);
                    PlayerIcon = "//";
                    for (int i = 0; i < snowCount; ++i)
                    {
                        if (snowPositionsY[i] <= 3)
                        {
                            snowPositionsY[i] = random.Next(10, 20);
                            snowPositionsX[i] = random.Next(1, 20);
                        }
                        else
                        {
                            snowPositionsY[i] -= 1;
                        }
                    }
                    for (int GOAL = 0; GOAL < goalCount; ++GOAL)
                    {
                        if (goalPositionsY[GOAL] <= 3)
                        {
                            goalPositionsY[GOAL] = random.Next(10, 20);
                            goalPositionsX[GOAL] = random.Next(1, 20);
                        }
                        else
                        {
                            goalPositionsY[GOAL] -= 1;
                        }
                    }
                }
                if (key == ConsoleKey.RightArrow)
                {
                    Gamecount++;
                    playerX = Math.Min(playerX + 1, Max_X);
                    PlayerIcon = "\\\\";
                    for (int i = 0; i < snowCount; ++i)
                    {
                        if (snowPositionsY[i] <= 3)
                        {
                            snowPositionsY[i] = random.Next(10, 20);
                            snowPositionsX[i] = random.Next(1, 20);
                        }
                        else
                        {
                            snowPositionsY[i] -= 1;
                        }
                    }
                    for (int GOAL = 0; GOAL < goalCount; ++GOAL)
                    {
                        if (goalPositionsY[GOAL] <= 3)
                        {
                            goalPositionsY[GOAL] = random.Next(10, 20);
                            goalPositionsX[GOAL] = random.Next(1, 20);
                        }
                        else
                        {
                            goalPositionsY[GOAL] -= 1;
                        }
                    }

                }
                if (key == ConsoleKey.DownArrow)
                {
                    Gamecount+=1;
                    PlayerIcon = "||";
                    for (int i = 0; i < snowCount; ++i)
                    {
                        if (snowPositionsY[i] <= 3)
                        {
                            snowPositionsY[i] = random.Next(10, 20);
                            snowPositionsX[i] = random.Next(1, 20);
                        }
                        else
                        {
                            snowPositionsY[i] -= 1;
                        }
                    }
                    for (int GOAL = 0; GOAL < goalCount; ++GOAL)
                    {
                        if (goalPositionsY[GOAL] <= 3)
                        {
                            goalPositionsY[GOAL] = random.Next(10, 20);
                            goalPositionsX[GOAL] = random.Next(1, 20);
                        }
                        else
                        {
                            goalPositionsY[GOAL] -= 1;
                        }
                    }
                }
                //점수를 주는 부분
                for (int j = 0; j < goalCount; ++j) 
                {
                    if (playerX == goalPositionsX[j] && playerY == goalPositionsY[j])
                    {
                        Point++;
                    }
                    else if (playerX == goalPositionsX[j] +1 && playerY == goalPositionsY[j])
                    {
                        Point++;
                    }
                    else if (playerX == goalPositionsX[j] - 1 && playerY == goalPositionsY[j])
                    {
                        Point++;
                    }
                }
                //감점점수가 올라가는 부분
                for (int h = 0; h< snowCount; ++h) 
                {
                    if (playerX == snowPositionsX[h] && playerY == snowPositionsY[h])
                        blackmark++;
                }
                if (Gamecount >= 100)
                {
                    Console.Clear();
                    Console.WriteLine($"점수 : {Point*100-blackmark*20}");
                    break;
                }
                void RenderObject(int x, int y, string icon)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(icon);
                }

            }
        }
    }
}


