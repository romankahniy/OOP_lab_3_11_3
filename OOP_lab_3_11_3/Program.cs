using System;
using System.IO;

namespace OOP_lab_3_11_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fromFile = new StreamReader("input.txt");

            string sentence = fromFile.ReadLine();

            string[] words = sentence.Split(new char[] { ' ', ':', ';', '.', ',', '?', '!', '(', ')', '{', '}', '[', ']', '@', '#', '№', '$', '^', '%', '&', '*' }, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            foreach (string word in words)
            {
                if (word.Length % 2 != 0)
                {
                    ++count;
                }
            }

            int[] letters = new int[1252];

            foreach (string word in words)
            {
                foreach (char letter in word)
                {
                    ++letters[(int)letter];
                }
            }

            StreamWriter toFile = File.CreateText("output.txt");

            toFile.WriteLine("Kiлькiсть слiв, якi мають непарну довжину: {0}.\n\nЧастотa входження кожної лiтери:", count);

            for (int i = 0; i <= 1251; ++i)
            {
                if (letters[i] != 0)
                {
                    toFile.WriteLine("{0} - {1}", (char)i, letters[i]);
                }
            }

            toFile.Close();
        }
    }
}
