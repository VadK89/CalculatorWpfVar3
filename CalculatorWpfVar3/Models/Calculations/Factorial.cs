using InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpfVar3.Models.Calculations
{
    public class Factorial : ICalculable
    {
        public double Calculate(List<double> values)
        {
            int res = 1;
            for (int i = 1; i <= values[values.Count - 1]; i++)
            {
                res *= i;
            }
            return res;
        }
    }
}
