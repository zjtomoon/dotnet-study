using System;
using static System.Console;
using Packet.Shared;


namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
/*
            var bob = new Person();
            WriteLine(bob.ToString());
*/
            /*
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            bob.FavouriteAncientWonder = WondersOfTheAcientWorld.StatueOfZeusAtOlympia;
            bob.BucketList = WondersOfTheAcientWorld.HangingGardensOfBabylon | WondersOfTheAcientWorld.MausoleumAtHalicarnassus;

            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            WriteLine(
                //format: "{0}  was born on {1:dddd, d MMMM yyyy}",
                format: "{0} 's favourite is {1}. It's integer is {2}.",
                arg0:bob.Name,
                //arg1:bob.DateOfBirth
                arg1:bob.FavouriteAncientWonder,
                arg2:(int)bob.FavouriteAncientWonder);

            var alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };


            WriteLine(
                format: "{0} was born on {1:dd MMM yy}",
                arg0: alice.Name,
                arg1: alice.DateOfBirth);

            WriteLine("==========================");

            BankAccount.InterestRate = 0.012M;

            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;

            WriteLine(format: "{0} earned {1:C}  interest.",
                arg0:jonesAccount.AccountName,
                arg1:jonesAccount.Balance * BankAccount.InterestRate);
            
            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;

            WriteLine(format: "{0} earned {1:C} interest.",
                arg0: gerrierAccount.AccountName,
                arg1: gerrierAccount.Balance * BankAccount.InterestRate);

            WriteLine($"{bob.Name} is a {Person.Species}");

            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

            var blankPerson = new Person();
            WriteLine(format:
                "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0:blankPerson.Name,
                arg1:blankPerson.HomePlanet,
                arg2:blankPerson.Instantiated);
            

            var gunny = new Person("Gunny", "Mars");
            WriteLine(format:
            "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
            arg0:gunny.Name,
            arg1:gunny.HomePlanet,
            arg2:gunny.Instantiated);

            //ReadLine();
            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());

            (string,int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1},{ fruit.Item2} there are.");

            var fruitNamed = bob.GetNamedFruit();
            WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}");

            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

            (string fruitName, int fruitNumber) = bob.GetFruit();
            WriteLine($"Deconstructed: {fruitName},{fruitNumber}");

            WriteLine(bob.SayHello());
            WriteLine(bob.SayHelloTo("Emily"));


            WriteLine(bob.OptionalParameters());

            WriteLine(bob.OptionalParameters("Jump!", 98.5));

            WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide"));

            WriteLine(bob.OptionalParameters("Poke!",active: false));
            
            
            WriteLine("========================================");

            int a = 10;
            int b = 20;
            int c = 31;
            
            WriteLine($"Before: a = {a}, b ={b}, c = {c}");
            bob.PassingParameter(a,ref b,out c);
            WriteLine($"After: a = {a},b = {b},c = {c}");

            int d = 10;
            int e = 20;
            WriteLine($"Before: d = {d},e = {e}, f doesn't exist yet!");
            bob.PassingParameter(d,ref e,out int f);
            WriteLine($"After: d = {d}, e = {e},f = {f}");

            var sam = new Person
            {
                Name = "Sam",
                DateOfBirth = new DateTime(1972, 1, 27)
            };

            WriteLine(sam.Orgin);


            WriteLine("================================");
            sam.FavouriteIceCream = "Chocolate Fudge";
            WriteLine($"Sam's favourite ice-cream flavor is {sam.FavouriteIceCream}");

            sam.FavouritePrimaryColor = "Red";
            WriteLine($"Sam's favourite primary color is {sam.FavouritePrimaryColor}");

            WriteLine("+++++++++++++++++++++++++++++++++++");

            bob.Children.Add(new Person { Name = "Alfred" });
            bob.Children.Add(new Person { Name = "Zoe1" });
            WriteLine($"{bob.Name} has {bob.Children.Count} children:");

            for (int child = 0; child < bob.Children.Count; child++)
            {
                WriteLine($"{bob.Children[child].Name}");  
            }

            sam.Children.Add(new Person { Name = "Charlie" });
            sam.Children.Add(new Person { Name = "Ella" });
            WriteLine($"Sam's first child is {sam.Children[0].Name}");
            WriteLine($"Sam's second child is {sam.Children[1].Name}");
            WriteLine($"Sam's first child is {sam[0].Name}");
            WriteLine($"Sam's second child is {sam[1].Name}");
            */

            var harry = new Person {Name = "Harry"};
            var mary = new Person {Name = "Mary"};
            var jill = new Person {Name = "Jill"};
            //调用实例方法
            var baby1 = mary.ProcreateWith(harry);
            //调用静态方法
            var baby2 = Person.Procreate(harry, jill);
            //call an operator
            var baby3 = harry * mary;

            WriteLine($"{harry.Name} has {harry.Children.Count} children");
            WriteLine($"{mary.Name} has {mary.Children.Count} children");
            WriteLine($"{jill.Name} has {jill.Children.Count} children");
            WriteLine(
                format: "{0}'s first child is named \"{1}\"",
                arg0: harry.Name,
                arg1: harry.Children[0].Name);

            string s1 = "Hello";
            string s2 = " World!";
            //string s3 = string.Concat(s1, s2);
            string s3 = s1 + s2;
            WriteLine(s3);

            WriteLine($"5! is {Person.Factorial(5)}");

            var p1 = new Person();
            int answer = p1.MethodIWantToCall("Frog");
            WriteLine($"the answer is :{answer}");

            //harry.Shout = Harry_Shout;
            harry.Shout += Harry_Shout;
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();
            
            Person[] people =
            {
                new Person {Name = "Simon"},
                new Person {Name = "Jenny"},
                new Person {Name = "Adam"},
                new Person {Name = "Richard"}
            };
            WriteLine("Initial list of people:");
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }
            
            WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }
            
            WriteLine("----------------------------------------");
            
            WriteLine("Use PersonComparer's Icomparer implemention to sort:");
            Array.Sort(people,new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer : {t1.Process(42)}");

            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with a string : {t2.Process("apple")}");

            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer: {gt1.Process(42)}");
            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string : {gt2.Process("apple")}");

            string number1 = "4";
            WriteLine("{0} squared is {1}",
                arg0:number1,
                arg1:Squarer.Square<string>(number1));

            byte number2 = 3;
            WriteLine("{0} squared is {1}",
                arg0:number2,
                arg1:Squarer.Square(number2));

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.X},{dv1.Y}) + ({dv2.X} , {dv2.Y}) = ({dv3.X}, {dv3.Y})");
            
            
            WriteLine("===============================");

            Employee john = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime(1970, 7, 28)
            };
            john.WriteToConsole();

            john.EmployeeCode = "JJ001";
            john.HireDate = new DateTime(2014, 11, 23);
            WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");
            
            WriteLine("====================");
            
            //WriteLine(john.ToString());
            Employee aliceInEmployee = new Employee
            {
                Name = "Alice",
                EmployeeCode = "AA123"
            };
            Person aliceInPerson = aliceInEmployee;
            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());
        }

        private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person) sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
        }

    }
}