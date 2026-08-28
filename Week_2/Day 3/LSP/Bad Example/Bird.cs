
namespace Week_2.Day_3.LSP.Bad_Example;

public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying...");
    }

    public virtual void Eat()
    {
        Console.WriteLine("Bird is eating...");
    }
}

public class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow is flying...");
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Penguins cannot fly.");
    }
}

