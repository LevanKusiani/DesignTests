using DesignPatterns.Builder_Pattern;
using DesignPatterns.SOLID_Principles;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = Builder_Pattern.Person.New.Called("levani").WorksAs("developer").IsOfGender(true).Build();

            Console.WriteLine(person);
        }
    }
}
