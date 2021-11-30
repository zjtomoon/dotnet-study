using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace LinqWithSets
{
    class Program
    {
        static void Main(string[] args)
        {
            var cohort1 = new string[]
            {
                "Rache1", "Gareth", "Jonathan", "George"
            };
            var cohort2 = new string[]
            {
                "Jack", "Stephen", "Daniel", "Jack", "Jared"
            };
            var cohort3 = new string[]
            {
                "Declan", "Jack", "Jack", "Jasmine", "Conor"
            };
            OutPut(cohort1,"Cohort 1");
            OutPut(cohort2,"Cohort 2");
            OutPut(cohort3,"Cohort 3");
            WriteLine();
            OutPut(cohort2.Distinct(),"cohort2.Distinct()");
            WriteLine();
            OutPut(cohort2.Union(cohort3),"cohort2.Union(cohort3)");
            WriteLine();
            OutPut(cohort2.Concat(cohort3),"cohort2.Concat(cohort3)");
            WriteLine();
            OutPut(cohort2.Intersect(cohort3),"cohort2.Intersect(cohort3)");
            WriteLine();
            OutPut(cohort2.Except(cohort3),"cohort2.Except(cohort3)");
            WriteLine();
            OutPut(cohort1.Zip(cohort2,(c1,c2)=> $"{c1} matched with {c2}"),"cohort1.Zip(cohort2):");
        }

        static void OutPut(IEnumerable<string> cohort, string description = "")
        {
            if (!string.IsNullOrEmpty(description))
            {
                WriteLine(description);
            }
            Write(" ");
            WriteLine(string.Join(", ", cohort.ToArray()));
        }
    }
}