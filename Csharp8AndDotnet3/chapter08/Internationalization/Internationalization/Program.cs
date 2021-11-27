using System;
using System.Globalization;
using static System.Console;

namespace Internationalization
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo globalization = CultureInfo.CurrentCulture;
            CultureInfo localization = CultureInfo.CurrentCulture;
            
            WriteLine("The current globalization culture is {0} : {1}",
                globalization.Name,globalization.DisplayName);
            WriteLine("The current localization culture is {0}: {1}",
                localization.Name,localization.DisplayName);
            
            WriteLine();
            
            WriteLine("en-Us : English (United states)");
            WriteLine("da-DK : Danish (Demark)");
            WriteLine("fr-CA : French (Canda)");
            Write("Enter an ISO culture code:");
            string newCulture = ReadLine();
            if (!string.IsNullOrEmpty(newCulture))
            {
                var ci = new CultureInfo(newCulture);
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;
            }
            WriteLine();
            Write("Enter your name: ");
            string name = ReadLine();
            Write("Enter your date of birth: ");
            string dob = ReadLine();
            Write("Enter your salary:");
            string salary = ReadLine();
            
            DateTime date = DateTime.Parse(dob);
            int minutes = (int) DateTime.Today.Subtract(date).TotalMinutes;
            decimal earns = decimal.Parse(salary);
            
            WriteLine("{0} was born on a {1:dddd}, is {2:N0} minutes old, and earns {3:C}",name,date,minutes,earns);

        }
    }
}