﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using static System.Console;

namespace WorkinghWithLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("Milan");
            WriteLine("Initial list");
            foreach (string city in cities)
            {
                WriteLine($" {city}");
            }
            WriteLine($"The first city is {cities[0]}");
            WriteLine($"The last city is {cities[cities.Count - 1]}.");
            
            cities.Insert(0,"Sydney");
            WriteLine("After inserting Sydney at index 0");
            foreach (string city in cities)
            {
                WriteLine($" {city}");
            }
            cities.RemoveAt(1);
            cities.Remove("Milan");
            WriteLine("After removing two cities");
            foreach (string city in cities)
            {
                WriteLine($" {city}");
            }
            
            //使用不可变集合
            var immutableCities = cities.ToImmutableList();
            var newList = immutableCities.Add("Rio");
            WriteLine("Immutable list of cities:");
            foreach (string city in immutableCities)
            {
                WriteLine($" {city}");
            }
            WriteLine();
            WriteLine("New list of cities:");
            foreach (string city in immutableCities)
            {
                Write($" {city}");
            }
            WriteLine();
        }
    }
}