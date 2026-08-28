namespace Week_2.Day_4.ISP.Bad_Example;

public interface Worker
{
    void Work();
    void Eat();
    void Sleep();
}

public class HumanWorker : Worker
{
    public void Work()
    {
        Console.WriteLine("Human is working.");
    }

    public void Eat()
    {
        Console.WriteLine("Human is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine("Human is sleeping.");
    }
}

public class RobotWorker : Worker
{
    public void Work()
    {
        Console.WriteLine("Robot is working.");
    }

    public void Eat()
    {
        throw new NotImplementedException();
    }

    public void Sleep()
    {
        throw new NotImplementedException();
    }
}

