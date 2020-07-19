using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SOLID_Principles
{
    #region Run in MAIN

    //var md = new MultifuinctionalDevice(new Printer(), new Scanner());
    //md.Print(new Document());
    //md.Scan(new Document());

    #endregion

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IMultifunctionalDevice : IPrinter, IScanner
    {

    }

    public class Document
    {

    }

    public class Printer : IPrinter
    {
        public void Print(Document d)
        {
            Console.WriteLine("Printing...");
        }
    }

    public class Scanner : IScanner
    {
        public void Scan(Document d)
        {
            Console.WriteLine("Scanning...");
        }
    }

    public class MultifunctionalPrinter
    {

    }

    public class OldFashionedPrinter
    {

    }

    public class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {

        }

        public void Scan(Document d)
        {

        }
    }

    public class MultifuinctionalDevice : IMultifunctionalDevice
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultifuinctionalDevice(IPrinter printer, IScanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }
}
