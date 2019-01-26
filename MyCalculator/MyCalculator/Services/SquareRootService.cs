using System;
using System.Collections.Generic;
using System.Text;


namespace MyCalculator.Services
{
    public class SquareRootService : ISquareRootService
    {
        public double squareRoot(double number)
        {
            return Math.Sqrt(number);
        }

        public double squareIt(double number)
        {
            return number*number;
        }
    }
}
