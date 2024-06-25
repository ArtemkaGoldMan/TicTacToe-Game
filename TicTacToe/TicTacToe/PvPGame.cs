using System;

namespace TicTacToe
{
    public class PvPGame
    {
        public int[,] Game = new int[3, 3];
        public int x = 0, y = 0, count = 0;
        bool player1 = true, player2 = true; 


        public void pvpGame()
        {
            print_map_and_X_or_Y(Game);
            Console.SetCursorPosition(0, 0);
            while (true)
            {
                if (player1)
                {
                    if (PlayerTurn(ref player1, ref player2, Game, ref x, ref y, 1))
                        break;
                }
                if (player2)
                {
                    if (PlayerTurn(ref player2, ref player1, Game, ref x, ref y, 2))
                        break;
                }
            }

        }

        bool PlayerTurn(ref bool currentPlayer, ref bool nextPlayer, int[,] game, ref int x, ref int y, int playerValue)
        {
            count++;
            currentPlayer = true;

            while (currentPlayer)
            {
                var cki = Console.ReadKey();

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y > 0) y -= 2;
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < 4) y += 2;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0) x -= 2;
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < 4) x += 2;
                        break;
                    case ConsoleKey.Enter:
                        if (game[y / 2, x / 2] == 0)
                        {
                            game[y / 2, x / 2] = playerValue;
                            currentPlayer = false;
                        }
                        break;
                }

                Console.Clear();
                print_map_and_X_or_Y(game);
                Console.SetCursorPosition(x, y);
            }

            if (check_win(game, count, playerValue) != -1)
            {
                return true;
            }

            nextPlayer = true;
            return false;
        }

        public void print_map_and_X_or_Y(int[,] map_size)
        {
            int rows = map_size.GetUpperBound(0) + 1;
            int columns = map_size.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (map_size[i, j] == 1)
                    {
                        Console.Write("x");
                    }
                    else if (map_size[i, j] == 2)
                    {
                        Console.Write("o");
                    }
                    else if (map_size[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                    if (j != 2)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                if (i != 2)
                {
                    Console.Write("-----");
                }
                Console.WriteLine();
            }
        }

        public static int check_win(int[,] p_mas, int p_count_move, int p_user)
        {
            int k = -1;
            int check_result = checkUser(p_mas, p_user);
            if (check_result == 1)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"User{p_user} wins");
                Console.ReadKey();
                k = 1;
            }
            else if ((check_result != 1) && (p_count_move == 9))
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Draw");
                Console.ReadKey();
                k = 0;
            }
            return k;
        }

        public static int checkUser(int[,] p_mas, int p_user)
        {
            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if ((p_mas[i, 0] == p_user && p_mas[i, 1] == p_user && p_mas[i, 2] == p_user) ||
                    (p_mas[0, i] == p_user && p_mas[1, i] == p_user && p_mas[2, i] == p_user))
                {
                    return 1;
                }
            }
            // Check diagonals
            if ((p_mas[0, 0] == p_user && p_mas[1, 1] == p_user && p_mas[2, 2] == p_user) ||
                (p_mas[0, 2] == p_user && p_mas[1, 1] == p_user && p_mas[2, 0] == p_user))
            {
                return 1;
            }
            return 0;
        }
    }
}
