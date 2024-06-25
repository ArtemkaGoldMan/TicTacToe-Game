using System;

namespace TicTacToe
{
    public class Bot
    {
        public static int my_row;
        public static int my_col;
        public static int op_col;
        public static int op_row;


        public static int get_corner_far(int[,] p_mas, out int m_row, out int m_col)
        {
            m_col = -1;
            m_row = -1;
            if ((op_row == 0) && (op_col == 1))
            {
                if (p_mas[2, 0] == 0)
                {
                    m_row = 2;
                    m_col = 0;
                    return 1;
                }
                else if (p_mas[2, 2] == 0)
                {
                    m_row = 2;
                    m_col = 2;
                    return 1;
                }
                else
                {
                    Console.WriteLine("error: get_not_corner");
                    return 0;
                }
            }
            else if ((op_row == 1) && (op_col == 0))
            {
                if (p_mas[0, 2] == 0)
                {
                    m_row = 0;
                    m_col = 2;
                    return 1;
                }
                else if (p_mas[2, 2] == 0)
                {
                    m_row = 2;
                    m_col = 2;
                    return 1;
                }
                else
                {
                    Console.WriteLine("error: get_not_corner");
                    return 0;
                }
            }
            else if ((op_row == 1) && (op_col == 2))
            {
                if (p_mas[0, 0] == 0)
                {
                    m_row = 0;
                    m_col = 0;
                    return 1;
                }
                else if (p_mas[2, 0] == 0)
                {
                    m_row = 2;
                    m_col = 0;
                    return 1;
                }
                else
                {
                    Console.WriteLine("error: get_not_corner");
                    return 0;
                }
            }
            else if ((op_row == 2) && (op_col == 1))
            {
                if (p_mas[0, 0] == 0)
                {
                    m_row = 0;
                    m_col = 0;
                    return 1;
                }
                else if (p_mas[0, 2] == 0)
                {
                    m_row = 0;
                    m_col = 2;
                    return 1;
                }
                else
                {
                    Console.WriteLine("error: get_not_corner");
                    return 0;
                }
            }
            return 0;
        }
        public static int get_first_empty(int[,] p_mas, out int m_row, out int m_col)
        {
            m_col = -1;
            m_row = -1;
            int rows = p_mas.GetUpperBound(0) + 1;
            int columns = p_mas.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (p_mas[i, j] == 0)
                    {
                        m_row = i;
                        m_col = j;
                        return 1;
                    }
                }
            }
            return 0;
        }
        public static int get_corner_diag(int[,] p_mas, out int m_row, out int m_col)
        {
            m_col = -1;
            m_row = -1;
            if ((op_row == 0) && (op_col == 0))
            {
                if (p_mas[2, 2] == 0)
                {
                    m_row = 2;
                    m_col = 2;
                    return 1;
                }
                else
                {
                    Console.WriteLine("error: get_not_corner");
                    return 0;
                }
            }
            else if ((op_row == 0) && (op_col == 2))
            {
                if (p_mas[2, 0] == 0)
                {
                    m_row = 2;
                    m_col = 0;
                    return 1;
                }
                else
                {
                    Console.WriteLine("error: get_not_corner");
                    return 0;
                }
            }
            else if ((op_row == 2) && (op_col == 0))
            {
                if (p_mas[0, 2] == 0)
                {
                    m_row = 0;
                    m_col = 2;
                    return 1;
                }
                else
                {
                    Console.WriteLine("error: get_not_corner");
                    return 0;
                }
            }
            else if ((op_row == 2) && (op_col == 2))
            {
                if (p_mas[0, 0] == 0)
                {
                    m_row = 0;
                    m_col = 0;
                    return 1;
                }
                else
                {
                    Console.WriteLine("error: get_not_corner");
                    return 0;
                }
            }
            return 0;
        }
        public static bool is_corner(int p_row, int p_col)
        {
            if ((p_row == 0) && (p_col == 0))
            {
                return true;
            }
            if ((p_row == 0) && (p_col == 2))
            {
                return true;
            }
            if ((p_row == 2) && (p_col == 0))
            {
                return true;
            }
            if ((p_row == 2) && (p_col == 2))
            {
                return true;
            }
            return false;
        }
        public static int check_win_defense(int[,] p_mas, int player, out int p_row, out int p_col)
        {
            p_row = -1;
            p_col = -1;
            int count_rows = 0;
            int count_coll = 0;
            int count_diag_main = 0;
            int count_diag_rev = 0;
            int rows = p_mas.GetUpperBound(0) + 1;
            int columns = p_mas.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                p_row = -1;
                count_rows = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (p_mas[i, j] == player)
                    {
                        count_rows++;
                    }
                    if (p_mas[i, j] == 0)
                    {
                        p_row = i;
                        p_col = j;
                    }
                }
                
                if ((count_rows == 2) && (p_row >= 0))
                {
                    return 1;
                }
            }
            p_row = -1;
            for (int j = 0; j < columns; j++)
            {
                count_coll = 0;
                p_col = -1;
                for (int i = 0; i < rows; i++)
                {
                    if (p_mas[i, j] == player)
                    {
                        count_coll++;
                    }
                    if (p_mas[i, j] == 0)
                    {
                        p_row = i;
                        p_col = j;
                    }
                }
                if ((count_coll == 2) && (p_col >= 0))
                {
                    return 1;
                }
            }
            p_row = -1;
            p_col = -1;
            for (int i = 0; i < rows; i++)
            {
                count_rows = 0;
                if (p_mas[i, i] == player)
                {
                    count_diag_main++;
                }
                if (p_mas[i, i] == 0)
                {
                    p_row = i;
                    p_col = i;
                }
            }

            if ((count_diag_main == 2) && (p_row >= 0))
            {
                return 1;
            }
            p_row = -1;
            p_col = -1;
            for (int i = 0; i < rows; i++)
            {
                count_rows = 0;
                if ((p_mas[i, 2 - i] == 1))
                {
                    count_diag_rev++;
                }
                if (p_mas[i, 2 - i] == 0)
                {
                    p_row = i;
                    p_col = 2 - i;
                }
            }

            if ((count_diag_rev == 2) && (p_row >= 0))
            {
                return 1;
            }
            return 0;
        }
        public static void bot(int[,] p_mas, int row, int col, int count_move)
        {
            if (p_mas[1, 1] == 0)
            {
                p_mas[1, 1] = 1;
                return;
            }
            if (check_win_defense(p_mas, 1, out my_row, out my_col) == 1)
            {
                p_mas[my_row, my_col] = 1;
                return;
            }
            else if (check_win_defense(p_mas, 2, out my_row, out my_col) == 1)
            {
                p_mas[my_row, my_col] = 1;
                return;
            }
            if (count_move == 3)
            {
                if (is_corner(op_row, op_col) == false)
                {
                    get_corner_far(p_mas, out my_row, out my_col);
                    p_mas[my_row, my_col] = 1;
                    return;
                }
                else
                {
                    get_corner_diag(p_mas, out my_row, out my_col);
                    p_mas[my_row, my_col] = 1;
                    return;
                }
            }
            if (count_move == 5)
            {
                if (is_corner(op_row, op_col) == false)
                {
                    get_corner_far(p_mas, out my_row, out my_col);
                    p_mas[my_row, my_col] = 1;
                    return;
                }
                else
                {
                    get_first_empty(p_mas, out my_row, out my_col);
                    p_mas[my_row, my_col] = 1;
                    return;
                }
            }
            if (count_move == 7)
            {
                get_first_empty(p_mas, out my_row, out my_col);
                p_mas[my_row, my_col] = 1;
                return;
            }
        }


    }
}