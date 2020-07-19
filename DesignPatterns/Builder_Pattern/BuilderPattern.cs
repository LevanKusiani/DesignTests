using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder_Pattern
{
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

            sb.Append($"{i}<{name}>");

            if (!string.IsNullOrWhiteSpace(text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(text);
            }

            foreach (var item in elements)
            {
                sb.AppendLine(item.ToStringImpl(indent + 1));
            }

            sb.AppendLine($"{i}</{name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    class BuilderPattern
    {
    }
}
