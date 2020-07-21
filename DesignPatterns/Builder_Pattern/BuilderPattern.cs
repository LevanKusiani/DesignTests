using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder_Pattern
{

    #region Run in MAIN

    //var builder = new HtmlBuilder("ul");
    //builder.AddChild("li", "what");
    //builder.AddChild("li", "the");
    //builder.AddChild("li", "fuck");
    //builder.AddChild("li", "leVani?!");

    //Console.WriteLine(builder);

    #endregion

    public class HtmlElement
    {
        public string name, text;
        public List<HtmlElement> elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);

            sb.AppendLine($"{i}<{name}>");

            if (!string.IsNullOrWhiteSpace(text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(text);
            }

            foreach (var item in elements)
            {
                sb.Append(item.ToStringImpl(indent + 1));
            }

            sb.AppendLine($"{i}</{name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string _rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            _rootName = rootName;
            root.name = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.elements.Add(e);

            return this; //This is a fluent approach to the builder
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement
            {
                name = _rootName
            };
        }
    }
}
