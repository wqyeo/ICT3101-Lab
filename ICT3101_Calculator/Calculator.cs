using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT3101_Calculator
{
    public class Calculator
    {
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;
            switch (op)
            {
                case "a":
                    result = Add(num1, num2);
                    break;
                case "s":
                    result = Subtract(num1, num2);
                    break;
                case "m":
                    result = Multiply(num1, num2);
                    break;
                case "d":
                    result = Divide(num1, num2);
                    break;
                default:
                    break;
            }

            return result;
        }

        public int Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Attempted to factorial a negative number.");
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        public double Add(double num1, double num2)
        {
            return (num1 + num2);
        }

        public double Subtract(double num1, double num2)
        {
            return (num1 - num2);
        }

        public double Multiply(double num1, double num2)
        {
            return (num1 * num2);
        }

        public double Divide(double num1, double num2)
        {
            if (num1 == 0 || num2 == 0)
            {
                throw new ArgumentException("Attempted to divide by zero!");
            }

            return (num1 / num2);
        }

        public double TriangleArea(double baseLength, double height)
        {
            if (baseLength <= 0 || height <= 0)
            {
                throw new ArgumentException("Base length and height must be positive numbers.");
            }

            return 0.5 * baseLength * height;
        }

        public double CircleArea(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be a positive number.");
            }

            return Math.PI * radius * radius;
        }

        
        /// <summary>
        /// n! / (n - k)!
        /// </summary>
        public double Permutation(int n, int k)
        {
            if (n < 0 || k < 0 || k > n)
            {
                throw new ArgumentException("Invalid inputs: n must be >= 0, k must be >= 0, and k must be <= n.");
            }

            double nFactorial = Factorial(n);
            double differenceFactorial = Factorial(n - k);
            return nFactorial / differenceFactorial;
        }

        /// <summary>
        /// n! / (k! * (n - k)!) 
        /// </summary>
        public double BinomialCoefficient(int n, int k)
        {
            if (n < 0 || k < 0 || k > n)
            {
                throw new ArgumentException("Invalid inputs: n must be >= 0, k must be >= 0, and k must be <= n.");
            }

            double nFactorial = Factorial(n);
            double kFactorial = Factorial(k);
            double differenceFactorial = Factorial(n - k);

            return nFactorial / (kFactorial * differenceFactorial);
        }
    }
}
