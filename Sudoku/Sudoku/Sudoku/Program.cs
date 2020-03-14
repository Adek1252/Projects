using System;

namespace Sudoku
{
    class Program
    {
        // pozycja startowa tab[0,0]
        // sprawdzamy czy j = szerokosc tablicy .GetLength(0) - jezeli tak to i++, j = 0;
        // sprawdzamy czy tab[i,j] != od 0. Jezeli jest juz pozycja w tablicy, to przechodzimy j++
        // wpisujemy numer do tablicy - start 1, end .GetLength(0);
        // sprawdzamy czy dany numer moze zostac wpisany - jezeli true, to wykonujemy metode ponownie dla kolejnego row (j+1) i sprawdzamy czy wartosc jest true
        // jezeli zwrocimy wartosc false to do obecnego tab[i,j] przypisujem wartosc 0 i zwracamy false calej metody

        public static int[,] tab = new int[,]      {
                                                        { 0, 0, 0, 1, 0, 7, 0, 0, 8},
                                                        { 0, 1, 2, 0, 9, 6, 0, 0, 7},
                                                        { 0, 5, 7, 2, 0, 4, 0, 9, 1},
                                                        { 1, 3, 0, 6, 0, 0, 4, 8, 0},
                                                        { 9, 0, 6, 0, 3, 0, 0, 5, 0},
                                                        { 7, 2, 0, 5, 0, 0, 3, 0, 6},
                                                        { 0, 0, 1, 7, 6, 0, 0, 0, 4},
                                                        { 0, 7, 0, 0, 0, 0, 0, 0, 5},
                                                        { 2, 0, 0, 4, 1, 0, 0, 7, 0}
                                                   };

        public static void sudokuSolver(int[,] tab)
        {
            Console.WriteLine();
            Console.WriteLine("The input table is: ");
            drawSudoku(tab);
            findSolution(0, 0, tab);
            Console.WriteLine();
            Console.WriteLine("The solution is: ");
            drawSudoku(tab);
        }

        private static Boolean findSolution(int i, int j, int[,] tab)
        {
            if (j == tab.GetLength(0))
            {
                j = 0;
                i++;
            }

            if (i == tab.GetLength(1))
                return true;

            if (tab[i, j] != 0)
            {
                return findSolution(i, j + 1, tab);
            }

            for (int testNumber = 1; testNumber <= tab.GetLength(0); testNumber++)
            {
                if (canUseNumber(tab, i, j, testNumber) == true)
                {
                    tab[i, j] = testNumber;
                    if (findSolution(i, j + 1, tab) == true)
                    {
                        return true;
                    }
                    tab[i, j] = 0;
                }
            }
            return false;
        }

        private static Boolean canUseNumber(int[,] tab, int i, int j, int testNumber)
        {
            // checking ROW
            for (int a = 0; a < tab.GetLength(0); a++)
            {
                if (tab[i, a] == testNumber)
                {
                    return false;
                }
            }

            // checking COLUMN
            for (int a = 0; a < tab.GetLength(1); a++)
            {
                if (tab[a, j] == testNumber)
                {
                    return false;
                }
            }

            //finding subBOX square
            int k = 0;
            int l = 0;
            if (i >= 0 && i <= 2 && j >= 0 && j <= 2)
            {
                k = 0;
                l = 0;
            }
            else if (i >= 0 && i <= 2 && j >= 3 && j <= 5)
            {
                k = 0;
                l = 3;
            }
            else if (i >= 0 && i <= 2 && j >= 6 && j <= 8)
            {
                k = 0;
                l = 6;
            }
            else if (i >= 3 && i <= 5 && j >= 0 && j <= 2)
            {
                k = 3;
                l = 0;
            }
            else if (i >= 3 && i <= 5 && j >= 3 && j <= 5)
            {
                k = 3;
                l = 3;
            }
            else if (i >= 3 && i <= 5 && j >= 6 && j <= 8)
            {
                k = 3;
                l = 6;
            }
            else if (i >= 6 && i <= 8 && j >= 0 && j <= 2)
            {
                k = 6;
                l = 0;
            }
            else if (i >= 6 && i <= 8 && j >= 3 && j <= 5)
            {
                k = 6;
                l = 3;
            }
            else if (i >= 6 && i <= 8 && j >= 6 && j <= 8)
            {
                k = 6;
                l = 6;
            }

            // checking subBOX square
            if (checkingSquare(i, j, k, l, tab, testNumber) == false) return false;
            return true;
        }

        private static Boolean checkingSquare(int i, int j, int k, int l, int[,] tab, int testNumber)
        {
            for (int a = k; a < k + 3; a++)
            {
                for (int b = l; b < l + 3; b++)
                {
                    if (testNumber == tab[a, b])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void drawSudoku(int[,] tab)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(" " + tab[i, j] + " |");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            sudokuSolver(tab);
        }
    }
}