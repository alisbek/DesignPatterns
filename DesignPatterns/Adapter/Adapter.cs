class Adapter : ITarget
{
    Adaptee adaptee = new Adaptee();
    public string GetRequest()
    {
       return adaptee.GetSpecificRequest();
    }
}