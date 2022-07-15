using EZInput;
using System;
using System.IO;

namespace ConsoleApp3
{
    internal class Program
    {
        //[System.Runtime.Versioning.SupportedOSPlatform("windows")]


        static bool g2d = true, g3d = false;
        static int playerC = 20, playerR = 28;
        static int bulletC, bulletR, bulletState = 0;
        static int g1bulletC, g1bulletR, g1bulletState = 0;
        static int g2bulletC, g2bulletR, g2bulletState = 0;
        static int g3bulletC, g3bulletR, g3bulletState = 0;
        static int g1r = 0, g2r = 6, g3r = 11;
        static int g1c = 70, g2c = 6, g3c = 144;
        static int lives = 3, g1health = 5, g2health = 3, g3health = 3;
        static int time;

        static char[,] ghost1 =
            {
        {' ' , ' ' , ' ' , ' ' , '/' , ' ' , ' ' , '_' , ' ' , ' ' , '\\' , ' ' , ' ' , ' ' , ' '},
        {' ' , ' ' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , ' ' , ' '},
        {'|' , ' ' , '\'' , '|' , ' ' , ' ' , ' ' , '|' , ' ' , ' ' , ' ' , '|' , '\'' , ' ' , '|'},
        {'|' , ' ' , ' ' , '|' , ' ' , ' ' , ' ' , '|' , ' ' , ' ' , ' ' , '|' , ' ' , ' ' , '|'},
        {'|' , ' ' , ' ' , '\'' , '-' , '-' , '-' , '|' , '-' , '-' , '-' , '\'' , ' ' , ' ' , '|'}};
        static char[,] ghost2 =
            {
        {' ' , ' ' , ' ' , ' ' , '/' , ' ' , '_' , ' ' , '\\' , ' ' , ' ' , ' ' , ' '},
        {' ' , ' ' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , ' ' , ' '},
        {'|' , '*' , '*' , '|' , ' ' , ' ' , '|' , ' ' , ' ' , '|' , '*' , '*' , '|'},
        {'|' , '*' , '*' , '|' , ' ' , ' ' , '|' , ' ' , ' ' , '|' , '*' , '*' , '|'},
        {'|' , ' ' , ' ' , '\'' , '-' , '-' , '|' , '-' , '-' , '\'' , ' ' , ' ' , '|'}};
        static char[,] ghost3 =
            {
        {' ' , ' ' , ' ' , ' ' , '/' , ' ' , '_' , ' ' , '\\' , ' ' , ' ' , ' ' , ' ' } ,
        {' ' , ' ' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , '*' , ' ' , ' ' },
        {'|' , '*' , '*' , '|' , ' ' , ' ' , '|' , ' ' , ' ' , '|' , '*' , '*' , '|' },
        {'|' , '*' , '*' , '|' , ' ' , ' ' , '|' , ' ' , ' ' , '|' , '*' , '*' , '|' },
        {'|' , ' ' , ' ' , '\'' , '-' , '-' , '|' , '-' , '-' , '\'' , ' ' , ' ' , '|' }
    };
        static char[,] rocket =    {
                                                {' ' , ' ' , ' ' , ' ' , ' ' , ' ' , '|' , ' ' , ' ' , ' ' , ' ' , ' ' , ' '},
                                                {' ' , ' ' , ' ' , ' ' , ' ' , '/' , ' ' , '\\' , ' ' , ' ' , ' ' , ' ' , ' '},
                                                {' ' , ' ' , ' ' , ' ' , '/' , ' ' , '_' , ' ' , '\\' , ' ' , ' ' , ' ' , ' '},
                                                {' ' , ' ' , ' ' , '|' , ' ' , ' ' , ' ' , ' ' , ' ' , '|' , ' ' , ' ' , ' '},
                                                {' ' , '/' , '\'' , '|' , ' ' , ' ' , '|' , ' ' , ' ' , '|' , '\'' , '\\' , ' '},
                                                {'|' , ' ' , ' ' , '|' , ' ' , ' ' , '|' , ' ' , ' ' , '|' , ' ' , ' ' , '|'},
                                                {'|' , '.' , '-' , '\'' , '-' , '-' , '|' , '-' , '-' , '\'' , '-' , '.' , '|'}
                                    };
        static char[,] grid = new char[560, 163];

        static void intro()
        {
            Console.Clear();

            Console.CursorVisible = (false);
            Console.SetCursorPosition(60, 16);
            Console.Write(" _   _          _    _                _   _                      ");
            Console.SetCursorPosition(60, 17);
            Console.Write("| \\ | |        | |  | |              | | | |                     ");
            Console.SetCursorPosition(60, 18);
            Console.Write("|  \\| | ___    | |  | | __ _ _   _   | |_| | ___  _ __ ___   ___ ");
            Console.SetCursorPosition(60, 19);
            Console.Write("| . ` |/ _ \\   | |/\\| |/ _` | | | |  |  _  |/ _ \\| '_ ` _ \\ / _ \\");
            Console.SetCursorPosition(60, 20);
            Console.Write("| |\\  | (_) |  \\  /\\  / (_| | |_| |  | | | | (_) | | | | | |  __/");
            Console.SetCursorPosition(60, 21);
            Console.Write("\\_| \\_/\\___/    \\/  \\/ \\__,_|\\__, |  \\_| |_/\\___/|_| |_| |_|\\___|");
            Console.SetCursorPosition(60, 22);
            Console.Write("                              __/ |                              ");
            Console.SetCursorPosition(60, 23);
            Console.Write("                             |___/                               ");
            Console.ReadKey();
        }

        static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition((y), (x));
        }

        static void left()
        {
            if (playerC > 6)
            {
                playerC = playerC - 2;
            }
        }
        static void right()
        {
            if (playerC < 143)
            {
                playerC = playerC + 2;
            }
        }
        static void fire()
        {
            if (bulletState == 0)
            {
                bulletC = playerC + 6;
                bulletR = playerR - 1;
                bulletState = 1;
            }
        }

        static void left2()
        {

            if (playerC > 6)
            {
                playerC = playerC - 2;
            }

        }
        static void right2()
        {
            if (playerC < 143)
            {
                playerC = playerC + 2;
            }
        }
        static void fire2()
        {
            if (bulletState == 0)
            {
                bulletC = playerC + 6;
                bulletR = playerR - 2;
                bulletState = 1;
            }
        }

        static void printingGhosts()
        {
            //ghost1
            if (g1health > 0)
            {
                // ghost1[2, 8]=char(g1health)+48;
                for (int r = 0; r < 5; r++)
                {
                    for (int c = 0; c < 15; c++)
                    {
                        grid[r + g1r, c + g1c] = ghost1[r, c];
                    }
                }
            }
            //ghost2
            if (g2health > 0)
            {
                // ghost2[2, 7]=char(g2health)+48;
                for (int r = 0; r < 5; r++)
                {
                    for (int c = 0; c < 13; c++)
                    {
                        grid[r + g2r, c + g2c] = ghost2[r, c];
                    }
                }
            }
            //ghost3
            if (g3health > 0)
            {
                // ghost3[2, 7]=char(g3health)+48;
                for (int r = 0; r < 5; r++)
                {
                    for (int c = 0; c < 13; c++)
                    {
                        grid[r + g3r, c + g3c] = ghost3[r, c];
                    }
                }
            }
        }
        static void deletingGhosts()
        {
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 15; c++)
                {
                    grid[r + g1r, c + g1c] = ' ';
                }
            }
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 13; c++)
                {
                    grid[r + g2r, c + g2c] = ' ';
                }
            }
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 13; c++)
                {
                    grid[r + g3r, c + g3c] = ' ';
                }
            }

        }
        static void movingGhosts()
        {
            //direction inversion g1 and g2
            if (g2c == 144)
            {
                g2d = false;
            }
            if (g2c == 6)
            {
                g2d = true;
            }
            if (g3c == 144)
            {
                g3d = false;
            }
            if (g3c == 6)
            {
                g3d = true;
            }

            //moving g1 and g2
            if (g2d == true)
            {
                g2c++;
            }
            else
            {
                g2c--;
            }
            if (g3d == true)
            {
                g3c++;
            }
            else
            {
                g3c--;
            }

            if (g1c > playerC)
            {
                if (g1c > 6)
                {
                    g1c--;
                }
            }
            if (g1c < playerC)
            {
                if (g1c < 143)
                {
                    g1c++;
                }
            }
        }

        static void bullets()
        {
            if (g1bulletState == 1 && g1health > 0)
            {
                grid[g1bulletR, g1bulletC] = ' ';
                g1bulletR = g1bulletR + 1;
                grid[g1bulletR, g1bulletC] = '*';
                if (g1bulletR > playerR + 2)
                {
                    grid[g1bulletR, g1bulletC] = ' ';
                    g1bulletState = 0;
                }
            }
            else
            {
                g1bulletState = 1;
                g1bulletC = g1c + 8;
                g1bulletR = g1r;
            }
            if (g2bulletState == 1 && g2health > 0)
            {
                grid[g2bulletR, g2bulletC] = ' ';
                g2bulletR = g2bulletR + 1;
                grid[g2bulletR, g2bulletC] = '*';
                if (g2bulletR > playerR + 2)
                {
                    grid[g2bulletR, g2bulletC] = ' ';
                    g2bulletState = 0;
                }
            }
            else
            {
                g2bulletState = 1;
                g2bulletC = g2c + 7;
                g2bulletR = g2r;
            }
            if (g3bulletState == 1 && g3health > 0)
            {
                grid[g3bulletR, g3bulletC] = ' ';
                g3bulletR = g3bulletR + 1;
                grid[g3bulletR, g3bulletC] = '*';
                if (g3bulletR > playerR + 2)
                {
                    grid[g3bulletR, g3bulletC] = ' ';
                    g3bulletState = 0;
                }
            }
            else
            {
                g3bulletState = 1;
                g3bulletC = g3c + 7;
                g3bulletR = g3r;
            }
        }
        static void youwin()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            //SetConsoleTextAttribute(variable, 2);
            gotoxy(16, 65);
            Console.Write("__   __            _    _ _     ");
            gotoxy(17, 65);
            Console.Write("\\ \\ / /            | |  | (_)    ");
            gotoxy(18, 65);
            Console.Write(" \\ V /___  _   _   | |  | |_ _ __ ");
            gotoxy(19, 65);
            Console.Write("  \\ // _ \\| | | |  | |/\\| | | '_ \\ ");
            gotoxy(20, 65);
            Console.Write("  | | (_) | |_| |  \\  /\\  / | | | |");
            gotoxy(21, 65);
            Console.Write("  \\_/\\___/ \\__,_|   \\/  \\/|_|_| |_|");
            gotoxy(22, 65);
            Environment.Exit(0);
        }
        static void youlose()
        {
            Console.Clear();
            char temp;
            Console.ForegroundColor = ConsoleColor.Red;
            gotoxy(31, 179);
            Console.Write(lives);
            gotoxy(16, 65);
            Console.Write("__   __             _                    ");
            gotoxy(17, 65);
            Console.Write("\\ \\ / /            | |                   ");
            gotoxy(18, 65);
            Console.Write(" \\ V /___  _   _   | |     ___  ___  ___ ");
            gotoxy(19, 65);
            Console.Write("  \\ // _ \\| | | |  | |    / _ \\/ __|/ _ \\");
            gotoxy(20, 65);
            Console.Write("  | | (_) | |_| |  | |___| (_) \\__ \\  __/");
            gotoxy(21, 65);
            Console.Write("  \\_/\\___/ \\__,_|  \\_____/\\___/|___/\\___|");
            gotoxy(22, 65);
            Console.ReadKey();
            Environment.Exit(0);
        }
        //static bool ser_cursor(bool visible)
        //{
        //    CONSOLE_CURSOR_INFO info;
        //    info.dwSize = 100;
        //    info.bVisible = visible;
        //    SetConsoleCursorInfo(GetStdHandle(STD_OUTPUT_HANDLE), &info);
        //}

        static void input()
        {
            string path = "maze.txt";
            string line = "";
            int i = 0;
            StreamReader file = new StreamReader(path, true);
            while ((line = file.ReadLine()) != null)
            { 
                for(int j=0; j<163; j++)
                {
                    grid[i,j] = line[j];
                }
                i++;
            }
            file.Close();
        }

        static void Main(string[] args)
        {

            Console.WindowLeft = 0;
            Console.WindowWidth = 170;


            Console.SetBufferSize(790, 19001);
            //Console.SetBufferSize(120, 9001);
            //Console.BufferHeight = 9000;
            ////9001
            //Console.BufferWidth = 119;
            ////120
            Console.CursorVisible = false;


            input();
            intro();
            int score = 0;
            int looper = 520;
            Console.Clear();
            //system("color 09");
            //gotoxy(30, 190);
            //Console.Write("Score");
            ////gotoxy(31, 170);
            //Console.Write("Lives");
            gotoxy(0, 0);

            while (true)
            {
                Console.CursorVisible = false;
                score++;
                // Sleep(10);
                //system("color 01");

                //gotoxy(30, 199);
                //Console.Write(score);
                gotoxy(0, 0);

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    left();
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    right();
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    fire();
                }

                playerR = looper + 33; // to move character upward with respect to the frame
                if (bulletState == 1)
                {
                    grid[bulletR, bulletC] = ' ';
                    bulletR = bulletR - 3;
                    grid[bulletR, bulletC] = '^';
                    if (bulletR < playerR - 35)
                    {
                        grid[bulletR, bulletC] = ' ';
                        bulletState = 0;
                    }
                }
                for (int i = looper, x = 0; x < 40; i++, x++) // looper containe the index of first line printed in each frame
                {                                             // the purpose of x in for(***) is to run loop for exact 40 iterations
                    for (int j = 0; j < 163; j++)
                    {
                        Console.Write(grid[i, j]);
                    }
                    Console.WriteLine();
                }
                // yaha par player print karana or us k grid ma coordinate bhi change karnay
                //  playerC;
                //--------------------------------------------------------------------
                for (int r = 0; r < 7; r++)
                {
                    for (int c = 0; c < 13; c++)
                    {
                        grid[playerR + r - 1, playerC + c] = rocket[r, c];
                    }
                }
                //================asteroids====================
                if (grid[playerR - 2,playerC] == '*' || grid[playerR - 2,playerC + 1] == '*' || grid[playerR - 2,playerC + 2] == '*' ||
                    grid[playerR - 2,playerC + 3] == '*' || grid[playerR - 2,playerC + 4] == '*' || grid[playerR - 2,playerC + 5] == '*' ||
                    grid[playerR - 2,playerC + 6] == '*' || grid[playerR - 2,playerC + 7] == '*' || grid[playerR - 2,playerC + 8] == '*' ||
                    grid[playerR - 2,playerC + 9] == '*' || grid[playerR - 2,playerC + 10] == '*' || grid[playerR - 2,playerC + 11] == '*' ||
                    grid[playerR - 2,playerC + 12] == '*' || grid[playerR - 2,playerC + 13] == '*')
                {
                    lives--;
                    playerC = 144;
                }
                if (lives == 0)
                {
                    youlose();
                }
                //====================================================================
                looper--;
                if (looper == 0)
                {
                    // looper=520;
                    break;
                }

            }

            gotoxy(0, 0);
            printingGhosts();
            for (int i = 0, x = 0; x < 40; i++, x++) // looper containe the index of first line printed in each frame
            {                                           // the purpose of x in for(***) is to run loop for exact 40 iterations
                for (int j = 0; j < 163; j++)
                {
                    Console.WriteLine(grid[i, j]);
                }
            }
            Console.ReadKey();
            while (true)
            {
                //System.Threading.Thread.Sleep(1);
                deletingGhosts();
                for (int r = 0; r < 7; r++) // clearing previous rocket in grid
                {
                    for (int c = 0; c < 13; c++)
                    {
                        grid[playerR + r, playerC + c] = ' ';
                    }
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    left2();
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    right2();
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    fire2();
                }

                if (bulletState == 1)
                {
                    grid[bulletR, bulletC] = ' ';
                    bulletR = bulletR - 2;
                    grid[bulletR, bulletC] = '^';
                    if (bulletR < playerR - 33)
                    {
                        grid[bulletR, bulletC] = ' ';
                        bulletState = 0;
                    }
                }
                movingGhosts();
                printingGhosts();
                for (int r = 0; r < 7; r++) // printing new rocket in grid
                {
                    for (int c = 0; c < 13; c++)
                    {
                        grid[playerR + r - 1, playerC + c] = rocket[r, c];
                    }
                }

                gotoxy(0, 0);
                for (int i = 0, x = 0; x < 40; i++, x++) // looper containe the index of first line printed in each frame
                {                                        // the purpose of x in for(***) is to run loop for exact 40 iterations
                    for(int j=0; j<163; j++)
                    {
                        Console.Write(grid[i,j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
