using System;

namespace Sudoku
{
    class Program
    {
        // runSolution(); call method - read start position i = 0, j =0 and [,]tabLab and [,]tab Sol
        // findPath(); - main method
        // assign tabSol[0,0] = 1;
        // first check if tabSol[11,8] (last col/row) is = 1, then return 1


        public static int[,] tabLab = new int[,] {
                                                    { 0, 0, 0, 1, 0, 0, 0, 0, 1},
                                                    { 1, 1, 0, 1, 0, 1, 1, 0, 1},
                                                    { 1, 0, 0, 1, 0, 0, 1, 0, 0},
                                                    { 1, 0, 1, 0, 0, 1, 1, 1, 0},
                                                    { 1, 0, 1, 0, 1, 0, 0, 1, 0},
                                                    { 0, 0, 1, 0, 1, 0, 1, 0, 0},
                                                    { 0, 1, 1, 0, 0, 0, 1, 0, 1},
                                                    { 0, 0, 0, 0, 1, 1, 1, 0, 1},
                                                    { 1, 0, 1, 1, 1, 0, 0, 0, 1},
                                                    { 0, 0, 1, 0, 0, 0, 1, 1, 1},
                                                    { 0, 1, 1, 0, 1, 1, 1, 1, 1},
                                                    { 0, 1, 1, 0, 0, 0, 0, 0, 0}
                                               };

        public static int[,] tabSol = new int[,] {             //8
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},   //11
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0}
                                               };
        public static void runSolution(int[,] tabLab, int[,] tabSol)
        {
            // drawTab(tabLab);
            //Console.WriteLine();
            findPath(0, 0, tabLab, tabSol);
            // drawTab(tabSol);
        }

        private static void drawTab(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(" " + table[i, j] + " |");
                }
                Console.WriteLine();
            }
        }

        private static Boolean nextMove(int i, int j, int[,] tabLab, int[,] tabSol)
        {
            if (i >= 0 && i <= 11 && j >= 0 && j <= 8)
            {
                if (tabLab[i, j] == 0 && tabSol[i, j] != 1)
                    return true;
            }
            return false;
        }

        private static Boolean findPath(int i, int j, int[,] tabLab, int[,] tabSol)
        {
            Console.Clear();
            tabSol[i, j] = 1;
            drawTab(tabLab);
            Console.WriteLine();
            drawTab(tabSol);

            System.Threading.Thread.Sleep(250);

            if (tabSol[tabSol.GetLength(0) - 1, tabSol.GetLength(1) - 1] == 1) return true;

            if (nextMove(i + 1, j, tabLab, tabSol))
            {
                if (findPath(i + 1, j, tabLab, tabSol) == true)
                    return true;
                tabSol[i + 1, j] = 0;
            }
            if (nextMove(i, j + 1, tabLab, tabSol))
            {
                if (findPath(i, j + 1, tabLab, tabSol) == true)
                    return true;
                tabSol[i, j+1] = 0;
            }
            if (nextMove(i, j - 1, tabLab, tabSol))
            {
                if (findPath(i, j - 1, tabLab, tabSol) == true)
                    return true;
                tabSol[i, j-1] = 0;
            }
            if (nextMove(i - 1, j, tabLab, tabSol))
            {
                if (findPath(i - 1, j, tabLab, tabSol) == true)
                    return true;
                tabSol[i-1, j] = 0;
            }

            return false;
        }

        static void Main(string[] args)
        {
            runSolution(tabLab, tabSol);
        }
    }
}
