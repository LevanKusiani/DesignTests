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
            var hb = new HumanBuilder();
            Human human = hb
                .Works.At("test").AsA("dev").Earning(1)
                .Lives.LivesAt("test ave. 1").LivesIn("London").Postcode("123");

            Console.WriteLine(human);
        }
    }
}
