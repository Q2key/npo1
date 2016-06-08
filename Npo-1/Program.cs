using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Npo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Matrix();
            var array = m.ReadArrayFromFile(@"D:\input.txt");
            /*
            foreach (var arr in array)
            {
                foreach (var a in arr)
                {
                    Console.Write(@" {0} ",a);
                }
                Console.WriteLine();
            }*/
            var a = new int[] { 1, 2, 3, 4 };
            var a2 = new int[] { 9, 11, 8, 10 };
            Console.ReadKey();
        }
    }

    class Matrix
    {
        public int[][] ReadArrayFromFile(string path)
        {
            var colandrow = File.ReadAllLines(path).Skip(0).First();
            var columns = int.Parse(colandrow.Split()[0]);
            var rows = int.Parse(colandrow.Split()[1]);
            var sarray = File.ReadAllLines(path).Skip(1).ToArray();
            var a = new int[columns][];
            for (var i = 0; i < a.Length; i++)
            {

                a[i] = sarray[i].Split().Select(int.Parse).ToArray();
            }
            return a;
        }
        public int GetMonosequenceLenght(int[] array)
        {
            var msl = 0;
            for (int i = 0; i < array.Length; i++)
            {

            }

            return msl;
        }


    }
}
