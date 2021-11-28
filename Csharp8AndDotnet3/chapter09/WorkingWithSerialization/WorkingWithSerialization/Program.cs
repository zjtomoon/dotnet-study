﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Packt.Shared;
using static System.Environment;
using static System.IO.Path;
using static System.Console;

namespace WorkingWithSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person(30000M)
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1974,3,14)
                },
                new Person(40000M)
                {
                    FirstName = "Bob",
                    LastName = "Jones",
                    DateOfBirth = new DateTime(1969,11,23)
                },
                new Person(20000M)
                {
                    FirstName = "Charlie" ,
                    LastName = "Cox",
                    DateOfBirth = new DateTime(1984,5,4),
                    Children = new HashSet<Person>
                    {
                        new Person(0M)
                        {
                            FirstName = "Sally",
                            LastName = "Cox",
                            DateOfBirth = new DateTime(2000,7,12)
                        }
                    }
                }
            };
            var xs = new XmlSerializer(typeof(List<Person>));
            string path = Combine(CurrentDirectory, "people.xml");
            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream,people);
            }
            WriteLine("Written {0:N0} bytes of XML to {1}",
                arg0: new FileInfo(path).Length,
                arg1: path);
            
            WriteLine();
            
            WriteLine(File.ReadAllText(path));
        }
    }
}