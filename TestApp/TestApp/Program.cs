using System;
using System.Diagnostics;

class Program
{
    // Make the method accessible from JS
    static void Main(string[] args)
    {
        Console.WriteLine("Start Processing...");
        var time = AvgCost(100000000, 10);
        Console.WriteLine($"Cost Time: {time}ms");
    }

    static double AvgCost(int n, int times)
    {
        var timer = new Stopwatch();
        timer.Start();
        for (int i = 0; i < times; i++)
        {
            CalculatePi(n);
            Console.WriteLine($"Processing... {i + 1}/{times}");
        }
        timer.Stop();
        return timer.ElapsedMilliseconds / (float)times;
    }
    
    static double CalculatePi(int numPointsToGenerate)
    {
        int pointsInCircle = 0;
        Random rnd = new Random();

        for (var i = 0; i < numPointsToGenerate; i++)
        {
            double x = rnd.NextDouble();
            double y = rnd.NextDouble();
            if (x * x + y * y <= 1)
            {
                pointsInCircle++;
            }
        }
        return 4.0 * pointsInCircle / numPointsToGenerate;
    }
}