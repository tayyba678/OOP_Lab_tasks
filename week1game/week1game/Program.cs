using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EZInput;
using System.Threading.Tasks;

namespace week1game
{
    internal class Program
    {
        static int ex1 = 90, ey1 = 33;
        static int vx = 88, vy = 2;
        static int ex = 7, ey = 3;
        static int px = 2, py = 30;
        static int bulletX = px + 1;
        static int score = 5;
        static int playerHealth = 100;
        static void Main(string[] args)
        {

            {
                interface1st();
                int choice;
                string enemyDirection = "left";
                Console.ForegroundColor = ConsoleColor.Yellow;
                do
                {
                    displayMenu();
                    Console.SetCursorPosition(57, 21);
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            printMaze();
                            score = 5;
                            Console.SetCursorPosition(px, py);
                            printPlayer();
                            printEnemy1();
                            enemy();

                            while (!IsGameOver())
                            {
                                if (Keyboard.IsKeyPressed(Key.Space))
                                {
                                    MoveBullet();
                                }
                                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                                {
                                    MovePlayerLeft();
                                }
                                if (Keyboard.IsKeyPressed(Key.RightArrow))
                                {
                                    MovePlayerRight();
                                }
                                if (Keyboard.IsKeyPressed(Key.UpArrow))
                                {
                                    MovePlayerUp();
                                }
                                if (Keyboard.IsKeyPressed(Key.DownArrow))
                                {
                                    MovePlayerDown();
                                }

                                collisionDetection();
                                displayScore();
                                MoveEnemy(enemyDirection);
                                enemyDirection = changeDirection(enemyDirection);
                                Thread.Sleep(100);
                            }

                            Console.WriteLine("Game Over");
                            Console.ReadKey();
                            eraseEnemy1();
                            eraseBullet();
                            break;

                        case 2:
                            Console.Clear();
                            score = 5;
                            printMaze();
                            printPlayer();
                            printEnemy();
                            printEnemy1();
                            MoveE();
                            MoveEnemy(enemyDirection);
                            enemyDirection = changeDirection(enemyDirection);

                            while (!IsGameOver())
                            {
                                if (Keyboard.IsKeyPressed(Key.Space))
                                {
                                    MoveBullet();
                                }
                                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                                {
                                    MovePlayerLeft();
                                }
                                if (Keyboard.IsKeyPressed(Key.RightArrow))
                                {
                                    MovePlayerRight();
                                }
                                if (Keyboard.IsKeyPressed(Key.UpArrow))
                                {
                                    MovePlayerUp();
                                }
                                if (Keyboard.IsKeyPressed(Key.DownArrow))
                                {
                                    MovePlayerDown();
                                }
                                collisionDetection();
                                displayScore();
                                MoveEnemy(enemyDirection);
                                enemyDirection = changeDirection(enemyDirection);
                                MoveE();
                                Thread.Sleep(100);
                            }

                            Console.WriteLine("Game Over");
                            Console.ReadKey();
                            eraseEnemy1();
                            eraseBullet();
                            erasePlayer();
                            break;

                        case 3:
                            Console.Clear();
                            score = 5;
                            printMaze();
                            printPlayer();
                            printEnemy();
                            printEnemy1();
                            printEnemy2();
                            MoveE();
                            MoveEnemy(enemyDirection);
                            enemyDirection = changeDirection(enemyDirection);
                            MoveE2();
                            while (!IsGameOver())
                            {
                                if (Keyboard.IsKeyPressed(Key.Space))
                                {
                                    MoveBullet();
                                }
                                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                                {
                                    MovePlayerLeft();
                                }
                                if (Keyboard.IsKeyPressed(Key.RightArrow))
                                {
                                    MovePlayerRight();
                                }
                                if (Keyboard.IsKeyPressed(Key.UpArrow))
                                {
                                    MovePlayerUp();
                                }
                                if (Keyboard.IsKeyPressed(Key.DownArrow))
                                {
                                    MovePlayerDown();
                                }

                                collisionDetection();
                                displayScore();
                                MoveEnemy(enemyDirection);
                                enemyDirection = changeDirection(enemyDirection);
                                MoveE();
                                MoveE2();
                                Thread.Sleep(100);
                            }

                            Console.WriteLine("Game Over");
                            Console.ReadKey();
                            eraseEnemy1();
                            eraseEnemy2();
                            eraseBullet();
                            erasePlayer();
                            break;

                        case 4:
                            Console.WriteLine("Goodbye!");
                            break;
                    }

                } while (choice != 4);

            }
        }
        static void ReducePlayerHealthWithTime()
        {
            playerHealth = playerHealth - 1;
            if (playerHealth < 0)
            {
                playerHealth = 0;
                displayPlayerHealth();
                Console.ReadKey();
            }
            displayPlayerHealth();
        }

        static void MovePlayerRight()
        {

            int px = 2, py = 30;
            if (GetCharAtPosition(px + 6, py) == ' ' && GetCharAtPosition(px + 6, py + 1) == ' ' && GetCharAtPosition(px + 6, py + 2) == ' ' && GetCharAtPosition(px + 6, py + 3) == ' ')
            {
                erasePlayer();
                px = px + 1;
                printPlayer();
            }
        }
        static bool IsGameOver()
        {
            return score == 0;
        }

        static void MoveBullet()
        {

            int px = 2, py = 30;
            int bulletY = py + 2;
            int bulletX = px + 6;
            if (bulletX <= 92)
            {
                eraseBullet();
                if (GetCharAtPosition(bulletX + 1, bulletY) == ' ')
                {
                    eraseBullet();
                    bulletX++;
                    printBullet();
                }
                else if (GetCharAtPosition(bulletX + 1, bulletY) == '@' || GetCharAtPosition(bulletX + 1, bulletY) == '+' || GetCharAtPosition(bulletX + 1, bulletY) == '<')
                {
                    eraseBullet();
                    score++; // Increase score
                    displayScore();
                }
            }
            ReducePlayerHealthWithTime();
        }
        static void displayPlayerHealth()
        {
            Console.SetCursorPosition(110, 7);
            Console.WriteLine("Health: " + playerHealth);
        }

        static void printBullet()
        {

            int px = 2, py = 30;
            Console.SetCursorPosition(px + 5, py + 2);
            Console.WriteLine("o");
        }
        static void eraseBullet()
        {

            int px = 2, py = 30;
            Console.SetCursorPosition(px + 5, py + 2);
            Console.WriteLine(" ");
        }
        static void displayMenu()
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("*************************************");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("****                             ****");
            Console.SetCursorPosition(30, 17);
            Console.WriteLine("**       1. Level 1                **");
            Console.SetCursorPosition(30, 18);
            Console.WriteLine("*        2. Level 2                 *");
            Console.SetCursorPosition(30, 19);
            Console.WriteLine("*        3. Level 3                 *");
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("*        4. Quit                    *");
            Console.SetCursorPosition(30, 21);
            Console.WriteLine("**      Enter your choice:         **");
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("****                             ****");
            Console.SetCursorPosition(30, 23);
            Console.WriteLine("*************************************");
        }
        static void collisionDetection()
        {

            int px = 2, py = 30;
            if (GetCharAtPosition(px + 1, py) == '@' || GetCharAtPosition(px + 1, py) == '+' || GetCharAtPosition(px + 1, py) == '<')
            {
                decrementScore();
                displayScore();
            }
            if (GetCharAtPosition(px + 5, py) == '@' || GetCharAtPosition(px + 5, py + 1) == '@' || GetCharAtPosition(px + 5, py + 2) == '@' || GetCharAtPosition(px + 5, py + 3) == '@' || GetCharAtPosition(px + 5, py + 4) == '@')
            {
                decrementScore();
                ReducePlayerHealthWithTime();
            }
            if (GetCharAtPosition(px, py - 1) == '+' || GetCharAtPosition(px + 2, py - 1) == '+' || GetCharAtPosition(px + 3, py - 1) == '+' || GetCharAtPosition(px + 4, py - 1) == '+')
            {
                decrementScore();
                ReducePlayerHealthWithTime();
            }
            if (GetCharAtPosition(px, py) == '<' || GetCharAtPosition(px + 2, py - 1) == '<' || GetCharAtPosition(px + 4, py - 1) == '<')
            {
                decrementScore();
                ReducePlayerHealthWithTime();
            }
            if (score < 0)
            {
                Console.WriteLine("Game Over");
                Console.ReadKey();
            }
            if (playerHealth < 0)
            {
                Console.WriteLine("Game Over");
                Console.ReadKey();
            }
        }
        static void decrementScore()
        {
            score--;
            displayScore();
        }

        static void displayScore()
        {
            Console.SetCursorPosition(110, 6);
            Console.WriteLine("Score: " + score);
        }
        static void enemy()
        {
            if (GetCharAtPosition(ex, ey) == '#')
            {
                Console.WriteLine("Game over");
                Console.ReadKey();
            }
        }
        static char GetCharAtPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            return keyInfo.KeyChar;
        }
        static void MovePlayerLeft()
        {
            if (GetCharAtPosition(px - 1, py) == ' ' && GetCharAtPosition(px - 1, py + 1) == ' ' && GetCharAtPosition(px - 1, py + 2) == ' ' && GetCharAtPosition(px - 1, py + 3) == ' ' || GetCharAtPosition(px - 1, py) + 4 == ' ')
            {
                erasePlayer();
                px = px - 1;
                printPlayer();
            }
        }
        static void MovePlayerUp()
        {
            if (GetCharAtPosition(px, py - 1) == ' ' && GetCharAtPosition(px + 1, py - 1) == ' ' && GetCharAtPosition(px + 2, py - 1) == ' ' && GetCharAtPosition(px + 3, py - 1) == ' ' && GetCharAtPosition(px + 4, py - 1) == ' ')
            {
                erasePlayer();
                py = py - 1;
                printPlayer();
            }
        }
        static void MovePlayerDown()
        {
            if (GetCharAtPosition(px, py + 5) == ' ')
            {
                erasePlayer();
                py = py + 1;
                printPlayer();
            }
        }
        static string changeDirection(string direction)
        {

            if (direction == "right" && ex1 <= 2)
            {
                direction = "left";
            }
            if (direction == "left" && ex1 >= 72)
            {
                direction = "right";
            }
            return direction;
        }
        static void interface1st()
        {
            Console.Clear();
            header();
            Console.SetCursorPosition(35, 15);
            Console.WriteLine("         ___------__     ");
            Console.SetCursorPosition(35, 16);
            Console.WriteLine("|\\__-- /\\       _-     ");
            Console.SetCursorPosition(35, 17);
            Console.WriteLine("|/    __      -          ");
            Console.SetCursorPosition(35, 18);
            Console.WriteLine("//\\  /  \\    /__       ");
            Console.SetCursorPosition(35, 19);
            Console.WriteLine("|  o|  0|__     --_      ");
            Console.SetCursorPosition(35, 20);
            Console.WriteLine("\\____-- __ \\   ___-    ");
            Console.SetCursorPosition(35, 21);
            Console.WriteLine("(@@    __/  / /_         ");
            Console.SetCursorPosition(35, 22);
            Console.WriteLine("-_____---   --_          ");
            Console.SetCursorPosition(35, 23);
            Console.WriteLine("     //  \\ \\   ___-    ");
            Console.SetCursorPosition(35, 24);
            Console.WriteLine("   //|\\__/  \\  \\      ");
            Console.SetCursorPosition(35, 25);
            Console.WriteLine("   \\_-\\_____/  \\-\\       ");
            Console.SetCursorPosition(35, 26);
            Console.WriteLine("        // \\--\\|        ");
            Console.SetCursorPosition(35, 27);
            Console.WriteLine("   ____//  ||_           ");
            Console.SetCursorPosition(35, 28);
            Console.WriteLine("  /_____\\ /___\\         ");
            Console.SetCursorPosition(35, 29);
            Console.WriteLine("______________________   ");
            Console.ReadLine();
        }
        static void MoveEnemy(string direction)
        {
            eraseEnemy1();
            if (GetCharAtPosition(ex1 - 1, ey1) == ' ')
            {
                if (direction == "right")
                {
                    ex1 = ex1 - 1;
                }
            }
            if (GetCharAtPosition(ex1 + 1, ey1) == ' ')
            {
                if (direction == "left")
                {
                    ex1 = ex1 + 1;
                }
            }
            printEnemy1();
        }
        static void MoveE()
        {
            if (GetCharAtPosition(ex, ey + 1) == ' ')
            {
                Thread.Sleep(100);
                eraseEnemy();
                ey = ey + 1;
                if (ey == 26)
                {
                    ey = 2;
                    ex = 17;
                }
                printEnemy();
            }
        }
        static void MoveE2()
        {
            if (GetCharAtPosition(vx - 5, vy + 1) == ' ')
            {
                Thread.Sleep(100);
                eraseEnemy2();
                vy = vy + 1;
                vx = vx - 5;
                if (vy == 18 || vx == 7)
                {
                    vy = 5;
                    vx = 72;
                }
                printEnemy2();
            }
        }
        static void printPlayer()
        {
            Console.SetCursorPosition(px, py);
            Console.WriteLine("#####");
            Console.SetCursorPosition(px, py + 1);
            Console.WriteLine("#. .#");
            Console.SetCursorPosition(px, py + 2);
            Console.WriteLine("#####");
            Console.SetCursorPosition(px, py + 3);
            Console.WriteLine("/###\\");
            Console.SetCursorPosition(px, py + 4);
            Console.WriteLine(" # # ");
        }

        static void printbonus()
        {
            int e = 14, r = 14;
            Console.SetCursorPosition(e, r);
            Console.WriteLine("o");
        }
        static void erasePlayer()
        {
            Console.SetCursorPosition(px, py);
            Console.WriteLine("     ");
            Console.SetCursorPosition(px, py + 1);
            Console.WriteLine("     ");
            Console.SetCursorPosition(px, py + 2);
            Console.WriteLine("     ");
            Console.SetCursorPosition(px, py + 3);
            Console.WriteLine("     ");
            Console.SetCursorPosition(px, py + 4);
            Console.WriteLine("     ");
        }
        static void printEnemy1()
        {
            Console.SetCursorPosition(ex1, ey1);
            Console.WriteLine("@@");
        }
        static void printEnemy()
        {
            Console.SetCursorPosition(ex, ey);
            Console.WriteLine("+-+");
        }
        static void printEnemy2()
        {
            Console.SetCursorPosition(vx, vy);
            Console.WriteLine("<^-^>");
        }
        static void eraseEnemy()
        {
            Console.SetCursorPosition(ex, ey);
            Console.WriteLine("  ");
            Console.SetCursorPosition(ex, ey + 1);
            Console.WriteLine("  ");
        }
        static void eraseEnemy1()
        {
            Console.SetCursorPosition(ex1, ey1);
            Console.WriteLine("  ");
            Console.SetCursorPosition(ex1, ey1 + 1);
            Console.WriteLine("  ");
        }
        static void eraseEnemy2()
        {
            Console.SetCursorPosition(vx, vy);
            Console.WriteLine("  ");
            Console.SetCursorPosition(vx, vy + 1);
            Console.WriteLine("  ");
        }
        static void header()
        {

            Console.WriteLine(" 7MM***Yb.  7MM***Mq.   7MM***YMM        db       7MMM.     ,MMF       .g8''8q.  7MMF    7MF   7MM***YMM   .M***bgd MMP**MM**YMM ");
            Console.WriteLine("  MM     Yb. MM    MM.   MM     7       .MM.       MMMb    dPMM      .dP      YM. MM       M    MM     7  ,MI     Y P    MM   `7 ");
            Console.WriteLine("  MM      Mb MM   ,M9    MM   d        ,V^MM.      M YM   ,M MM      dM        MM MM       M    MM   d    `MMb.          MM      ");
            Console.WriteLine("  MM      MM MMmmdM9     MMmmMM       ,M   MM      M  Mb  M  MM      MM        MM MM       M    MMmmMM      `YMMNq.      MM      ");
            Console.WriteLine("  MM     ,MP MM  YM.     MM   Y  ,    AbmmmqMA     M  YM.P   MM      MM.      ,MP MM       M    MM   Y  , .      MM      MM      ");
            Console.WriteLine("  MM    ,dP  MM    Mb.   MM     ,M   A      VML    M   YM    MM       Mb.    ,dP  YM.     ,M    MM     ,M Mb     dM      MM      ");
            Console.WriteLine(".JMMmmmdP  .JMML. .JMM..JMMmmmmMMM .AMA.   .AMMA..JML.  |   .JMML.      **bmmd       bmmmmd    .JMMmmmmMMM P*Ybmmd*     .JMML.    ");
            Console.WriteLine("                                                                            MMb                                                  ");
            Console.WriteLine("                                                                             bood                                                ");
        }
        static void printMaze()
        {
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine("%                                                     %%%                                       %");
            Console.WriteLine("%                                                     %%%                                       %");
            Console.WriteLine("%                                                     %%%                                       %");
            Console.WriteLine("%                                                     %%%                                       %");
            Console.WriteLine("%                                                     %%%                                       %");
            Console.WriteLine("%                                                     %%%                                       %");
            Console.WriteLine("%                                                     %%%                                       %");
            Console.WriteLine("%                                                     %%%                                       %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                           %%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                     %%%%%%%%%%%%%%%%%%                        %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                           %%%%%%%%%%%%%%%%%%%%                                                %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%                                                                                               %");
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        }

    }

}
    
