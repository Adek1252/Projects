using System;

namespace FirstNonRepetitive
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            const string text = "qweqwteghhgjtyuyiouoljmprtyuizxvzxcopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcbnm";

            char[] stringChar = text.ToCharArray();
            string[,] stringSolution = new string[2, 26];

// pre-populating stringSolution[,]
            for (int i = 0; i < stringSolution.GetLength(1); i++)
            {
                stringSolution[0, i] = "?";
                stringSolution[1, i] = "?";
                stringSolution[0, 0] = stringChar[0].ToString();
                stringSolution[1, 0] = "0";
            }

            for (int i = 0; i < stringChar.Length; i++)
            {
                for (int j = 0; j < stringSolution.GetLength(1); j++)
                {
                    try
                    {
                        if (stringChar[i] == Convert.ToChar(stringSolution[0, j]))
                        {
                            int liczba = Int32.Parse(stringSolution[1, j]);
                            liczba++;
                            stringSolution[1, j] = liczba.ToString();
                            break;
                        }

                        if (j == stringSolution.GetLength(1) - 1)
                        {
                            counter++;
                            stringSolution[0, counter] = stringChar[i].ToString();
                            stringSolution[1, counter] = "1";  
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Not all characters are letters. Please change input");
                    }                                       
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < stringSolution.GetLength(1);j++)
                {
                    Console.Write(stringSolution[i, j]);
                }
                    Console.WriteLine();
            }

            for (int i = 0; i < stringSolution.GetLength(1); i++)
            {
                if (stringSolution[1, i] == "1")
                {
                    Console.WriteLine("The first non-repetetive character is: {0}",stringSolution[0, i]);
                    break;
                }
                if (i==stringSolution.GetLength(1)-1)
                    Console.WriteLine("There are no non-repetetive characters");
            }

            Console.ReadLine();
        }
    }
}
