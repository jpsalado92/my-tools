using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Explicit init
            List<double> grades = new List<double>();
            // Implicit init
            var grades = new List<double>();
            grades.Add(1.3);
            grades[0];
            // Implicit init with content
            var grades = new List<double>() { 12.7, 10.3, 6.11 };

            var result = 0.0;
            foreach (double number in numbers)
            {
                result += number;
            }
            var average = 0.0;
            average = result / grades.Count;
            Console.WriteLine($"The average grade us {average:N2}");
        }
    }
}