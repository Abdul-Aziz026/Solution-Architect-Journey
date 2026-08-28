namespace Week_2.Day_4.ISP.Good_Example;

public interface IWorker { void Work(); }

public interface IEat { void Eat(); }

public interface ISleep { void Sleep(); }

public class HumanWorker : IWorker, IEat, ISleep
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

public class RobotWorker : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot is working.");
    }
}

