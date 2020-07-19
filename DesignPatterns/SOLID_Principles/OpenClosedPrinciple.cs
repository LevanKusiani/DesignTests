using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SOLID_Principles
{
    #region Run in MAIN

    //var products = new List<Product>()
    //{
    //    new Product("Hoodie", Color.Green, Size.Small),
    //    new Product("Jeans", Color.Blue, Size.Large),
    //    new Product("Hat", Color.Red, Size.Medium),
    //    new Product("Socks", Color.Blue, Size.Small)
    //};

    //var filteredProducts = ProductFilter.FilterBySize(products, Size.Small);

    ////foreach (var item in filteredProducts)
    ////{
    ////    Console.WriteLine(item.name);
    ////}

    //var filter = new Filter();

    ////foreach (var item in filter.FilterList(products, new SizeSpecification(Size.Small)))
    ////{
    ////    Console.WriteLine($"{item.name} found.");
    ////}

    //foreach (var item in filter.FilterList(products, new AndSPecification<Product>(new ColorSpecification(Color.Green), new SizeSpecification(Size.Small))))
    //{
    //    Console.WriteLine($"{item.name} found.");
    //}

    #endregion

    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        Yuge
    }
    
    public class Product
    {
        public string name;
        public Color color;
        public Size size;

        public Product(string name, Color color, Size size)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }

            this.name = name;
            this.color = color;
            this.size = size;
        }
    }

    public class ProductFilter
    {
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var item in products)
            {
                if(item.size == size)
                    yield return item;
            }
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> FilterList(IEnumerable<T> items, ISpecification<T> spec);
    }

    #region Specifications

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.size == size;
        }
    }

    public class AndSPecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSPecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    #endregion

    public class Filter : IFilter<Product>
    {
        public IEnumerable<Product> FilterList(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
                if(spec.IsSatisfied(item))
                    yield return item;
        }
    }
}
