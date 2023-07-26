

using static System.Console;

public enum Color
{
    Red, Blue, White,
    Green
}

public enum Size
{
    small, medium, large
}

class Product
{
    public string Name;
    public Color color;
    public Size size;

    public Product(string name, Color color, Size size)
    {
        Name = name;
        this.color = color;
        this.size = size;
    }
}

class BadFilter
{
    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
        return products.Where(p => p.size == size);
    }
    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    {
        return products.Where(p => p.color == color);
    }

    public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
    {
        return products.Where(p => p.color == color && p.size == size);
    }
}

interface ISpecification<T>
{
    bool isSatisfied(T t);
}

interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
}

class ColorSpecification : ISpecification<Product>
{
    private Color color;

    public ColorSpecification(Color color)
    {
        this.color = color;
    }

    public bool isSatisfied(Product t)
    {
        return t.color == color;
    }
}

class SizeSpecification : ISpecification<Product>
{
    private Size size;

    public SizeSpecification(Size size)
    {
        this.size = size;
    }
    public bool isSatisfied(Product t)
    {
        return t.size == size;
    }
}

class AndSpecification<T> : ISpecification<T>
{
    private ISpecification<T> first, second;

    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    {
        this.first = first;
        this.second = second;
    }
    public bool isSatisfied(T t)
    {
        return first.isSatisfied(t) && second.isSatisfied(t);
    }
}

class GoodFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
    {
        return items.Where(i => specification.isSatisfied(i));
    }
}
class Program
{
    public static void Main()
    {
        var apple = new Product("Apple", Color.Green, Size.small);
        var tree = new Product("Tree", Color.Green, Size.medium);
        var house = new Product("House", Color.Blue, Size.large);

        Product[] products = { apple, tree, house };

        var badFilter = new BadFilter();
        WriteLine("Green products (old): ");
        foreach (var p in badFilter.FilterByColor(products, Color.Green))
        {
            WriteLine($" - {p.Name} is green");
        }
        WriteLine("Large blue items: ");
        foreach (var p in badFilter.FilterByColorAndSize(products, Color.Blue, Size.large))
        {
            WriteLine($" - {p.Name} is blue and large");
        }

        /* *********************************************************************** */

        var goodFilter = new GoodFilter();
        WriteLine($"Green products (new): ");
        foreach (var p in goodFilter.Filter(products, new ColorSpecification(Color.Green)))
        {
            WriteLine($" - {p.Name} is green");
        }

        WriteLine("Large blue items: ");
        foreach (var p in goodFilter.Filter(products,
                     new AndSpecification<Product>(new ColorSpecification(Color.Blue),
                         new SizeSpecification(Size.large))))
        {
            WriteLine($" - {p.Name} is blue and large");
        }

    }
}