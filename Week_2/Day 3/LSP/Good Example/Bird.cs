
namespace Week_2.Day_3.LSP.Good_Example;

public class Bird
{

    public virtual void Eat()
    {
        Console.WriteLine("Bird is eating...");
    }
}

public interface IFlyingBird
{
    void Fly();
}

public class Sparrow : Bird, IFlyingBird
{
    public void Fly()
    {
        Console.WriteLine("Sparrow is flying...");
    }
}

public class Penguin : Bird
{

}

