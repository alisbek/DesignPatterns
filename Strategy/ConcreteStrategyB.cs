class ConcreteStrategyB : IStrategy
{
    public object DoAlgorythm(object data)
    {
        var list = data as List<string>;
        list.Sort();
        list.Reverse();

        return list;
    }
}