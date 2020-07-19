using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SOLID_Principles
{
    #region Run in MAIN

    //var r = new Rectangle(2, 3);
    //Rectangle s = new Square();
    //s.Width = 5;

    //        Console.WriteLine($"{r} has area: {Rectangle.Area(r)}");
    //        Console.WriteLine($"{s} has area: {Rectangle.Area(s)}");

    #endregion

    public class Rectangle
    {
        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }

        public static int Area(Rectangle r) => r.Width * r.Height;
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Height = base.Width = value; }
        }
    }
}
