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
        Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
        var result = this._strategy.DoAlgorythm(new List<string> { "a", "b", "c", "d", "e" });

        string resultStr = String.Empty;
        foreach (var element in result as List<string>)
        {
            resultStr += element + ",";
        }

        Console.WriteLine(resultStr);
    }
}