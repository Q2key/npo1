using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            var path = @"C:\input.txt";
            var matrix = m.CreateMatrix(path);
            
            Console.WriteLine("Input matrix");
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            m.SortMatrix(m.CreateMatrix(path));
            Console.ReadKey();
        }
    }
    class Matrix
    {         
        public void SortMatrix(int [,] matrix)
        {   
            
            Console.WriteLine();
            matrix = CreateMatrix(@"C:\input.txt");
            var columnlist = new List<List<int>>();
            var rowsumnlist = new List<List<int>>();
            var t = new List<int>();
            Console.WriteLine("Columns Sorted");
            for (var i = 0; i < matrix.GetLength(0); i++)
            {   
                          
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    t.Add(matrix[i,j]);
                    Console.Write(matrix[i,j] + " ");
                }
                columnlist.Add(t);
                t = new List<int>();
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < columnlist.Count; i++)
            {
                var max = i;
                for (int j = i + 1; j < columnlist.Count; j++)
                {
                    if (GetMonosequenceLenght(columnlist[max].ToArray()) < GetMonosequenceLenght(columnlist[j].ToArray()))
                    {
                         max = j;
                    }
                    var temp = columnlist [max];
                    columnlist[max] = columnlist[i];
                    columnlist[i] = temp;
                }
            }
            Console.WriteLine("Rows Sorted");
            foreach (var column in columnlist)
            {
                foreach (var l in column)
                {
                    Console.Write(l + " ");
                }
                Console.WriteLine();
            }
            
            for (int i = 0; i < matrix.GetLength(1); i++)
            {               
                for (int j = 0; j < columnlist.Count; j++)
                {   
                    t.Add(columnlist[j][i]);                  
                }
               rowsumnlist.Add(t);
               t = new List<int>();
            }
            for (int i = 0; i < rowsumnlist.Count; i++)
            {
                var max = i;
                for (int j = i + 1; j < rowsumnlist.Count; j++)
                {
                    if (GetMonosequenceLenght(rowsumnlist[max].ToArray()) < GetMonosequenceLenght(rowsumnlist[j].ToArray()))
                    {
                        max = j;
                    }
                    var temp = rowsumnlist[max];
                    rowsumnlist[max] = rowsumnlist[i];
                    rowsumnlist[i] = temp;
                }
            }
            var outstr = string.Empty;
            
            for (int i = 0; i < rowsumnlist.Count-1; i++)
            {
                var ts = new List<string>();
                foreach (var list in rowsumnlist)
                {
                    outstr += list[i] + " ";                
                    ts.Add(list[i] + " ");
                }
                outstr += " \n";
            }
            try
            {
                File.WriteAllText(@"C:\output.txt", outstr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("File not exists");               
            }
           
        }
        public int[,] CreateMatrix(string path)
        {
            
            if (!File.Exists(path))
            {
                Console.Write("\'Input.txt\' File is not exist");
                Console.Read();
                return new int[,] {};
            }

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
        public int GetMonosequenceLenght(int[] array)
        {
            var x = 0;
            var y = 0;
            int seqlengthb;
            var seqlengtha = seqlengthb = 0;
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    x++;
                }
                else
                {
                    x = 0;
                }
                if (x >= seqlengtha)
                {
                    seqlengtha = x;
                }
                if (array[i] > array[i + 1])
                {
                    y++;
                }
                else
                {
                    y = 0;
                }
                if (y >= seqlengthb)
                {
                    seqlengthb = y;
                }
            }
            seqlengtha++;
            seqlengthb++;
            return seqlengtha > seqlengthb ? seqlengtha : seqlengthb;
        }
    }
}
