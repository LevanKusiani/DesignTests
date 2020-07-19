using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatterns.SOLID_Principles
{

    #region Run in MAIN
        //var j = new Journal();
        //j.AddEntry("NOW I ATE another KHACHAPUTI");
        //j.AddEntry("i love pepsi");

        //var p = new Persistance();
        //p.SaveToFile(j, @"D:\levani.txt", true);
        //Process.Start(@"cmd.exe ", @"/c D:\levani.txt");
    #endregion

    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; //memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistance
    {
        public void SaveToFile(Journal j, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
                File.WriteAllText(fileName, j.ToString());
            else
                File.AppendAllText(fileName, j.ToString());
        }
    }
}
