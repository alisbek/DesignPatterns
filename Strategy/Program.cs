class Context
{
    private IStrategy _strategy;

    public Context()
    {
            
    }

    public Context(IStrategy strategy)
    {
        this._strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        this._strategy = strategy;
    }

    public void SomeBusinessLogic()
    {
        System.Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
        var result = this._strategy.DoAlgorythm(new List<string> { "a", "b", "c", "d", "e" });
    }
}

public interface IStrategy
{
    object DoAlgorythm(object data);
}

class Program
{
    static void Main(string args[])
    {

    }
}