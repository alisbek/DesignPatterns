public class Person
{
    public string StreetAddress, Postcode, City;

    public string CompanyName, Position;
    public int AnualIncome;

    public override string ToString()
    {
        return
            $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnualIncome)}: {AnualIncome}";
    }
}

public class PersonBuilder //facade
{
    //reference
    protected Person person = new Person();

    public PersonJobBuilder Works => new PersonJobBuilder(person);
}

public class PersonJobBuilder : PersonBuilder
{
    public PersonJobBuilder(Person person)
    {
        this.person = person;
    }

    public PersonJobBuilder At(string companyName)
    {
        person.CompanyName = companyName;
        return this;
    }

    public PersonJobBuilder AsA(string position)
    {
        person.Position = position;
        return this;
    }

    public PersonJobBuilder Earning(int amount)
    {
        person.AnualIncome = amount;
        return this;
    }
}

class PersonAddressBuilder

public class Program
{
    public static void Main()
    {
        var pb = new PersonBuilder();
        var person = pb.Works.At("LOLOL").AsA("HR").Earning(550000);
    }
}