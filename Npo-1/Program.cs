using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Npo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Matrix();
            var matrix = m.CreateMatrix(@"D:\input.txt");
            var a = new int[] {1,2,3,3,2};
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(m.GetMonosequenceLenght(a, 0));
            Console.ReadKey();
        }
    }

    class Matrix
    {
        public int[,] CreateMatrix(string path)
        {

            var colandrows = File.ReadAllLines(path).Skip(0).First().Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();
            var columns = colandrows[0];
            var rows = colandrows[1];

            var sarray = File.ReadAllLines(path).Skip(1).ToArray();
            var a = new int[columns][];

            for (var i = 0; i < a.Length; i++)
            {
                a[i] = sarray[i].Split(' ').
                Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(int.Parse).ToArray();
            }

            var matrix = new int[columns, rows];
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    matrix[i, j] = a[i][j];
                }
            }

            return matrix;
        }
        public int GetMonosequenceLenght(int[] array, int point)
        {

            var prev = array[0];
            var t = 0;

            if (prev<array[1])
            {
                Console.WriteLine("inc " + prev);
            }
            else
            {
                Console.WriteLine("desc " + prev);
            }
           
            for (var i = 1; i < array.Length; i++)
            {
                var j = i;
                while (j < array.Length && prev < array[j] )
                {
                    prev = array[j];
                    j++;
                    Console.WriteLine("inc " + prev + " i - " + i + " j - " + j);
                }
            }     
            return 666;
        }
    }
}
