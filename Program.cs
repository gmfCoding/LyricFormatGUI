using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricFormatt
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] current = Song.lines2;
            ResolveSong rs = new ResolveSong(Song.lines);

            rs.PrintDifferences();

            //Console.ResetColor();
            //foreach (var index in otherLines)
            //{
            //    Console.WriteLine(current[index]);
            //}

            Console.ReadLine();
        }

    }
}
