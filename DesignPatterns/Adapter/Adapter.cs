class Adapter : Adaptee, ITarget
{
    public string GetRequest()
    {
       return this.GetSpecificRequest();
    }
}