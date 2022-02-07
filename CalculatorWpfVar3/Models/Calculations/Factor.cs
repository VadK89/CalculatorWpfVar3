using InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpfVar3.Models.Calculations
{
    public class Factor : ICalculable
    {
        public double Calculate(List<double> values)
        {
            //double res = 1;
            //for (int i = 1; i <= values[values.Count - 1]; i++)
            //{
            //    res *= i;
            //}
            //return res;
            return Factorial(values[values.Count - 1]);
            double Factorial(double x)
            {
                int res = 1;
                for (int i = 1; i <= x; i++)
                {
                    res *= i;
                }
                return res;
            }
        }
    }
}
