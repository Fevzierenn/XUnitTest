using System;
namespace UnitTest
{
    public class QuadraticEquation
    {
        public SolverClass Solve(double a, double b, double c)
        {
            if (a == 0) { throw new ArgumentException("a must not be 0 in a quadratic equation."); }
            double discriminant = (b * b) - 4 * a * c;
            if (discriminant < 0)
            {
                return new SolverClass
                {
                    Roots = new double[0],
                    Message = "No real roots."
                };
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return new SolverClass
                {
                    Roots = new double[] { root },
                    Message = "One real root."
                }; }
            else
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return new SolverClass
                {
                    Roots = new double[] { root1, root2 },
                    Message = "Two real roots."
                }; }
        }
    }
}