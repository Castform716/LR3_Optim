using System;

namespace LR3_Optim
{
    class Program
    {
        static void Main(string[] args)
        {
            var opt = new double[2];
            opt = HookeJeevesTop.HookeJeevesMethod(Function, new double[] { -5, -5 }, 0.0001, 1, 10000);
            Console.WriteLine("X: " + opt[0] + " Y: " + opt[1]);

        }

        static private double Function(double[] u)
        {
            var I = u[0] + u[1] - Math.Pow((u[0] + u[1]), 2) - 4 * Math.Pow(u[0], 2);
            //var I = -Math.Pow(u[0], 2) - Math.Pow(u[1], 2);
            return I;
        }
    }
}
