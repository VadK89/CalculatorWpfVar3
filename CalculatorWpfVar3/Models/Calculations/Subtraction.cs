using InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpfVar3.Models.Calculations
{
    public class Subtraction : ICalculable
    {
        public double Calculate(List<double> values)
        {
            return values[values.Count - 2] - values[values.Count - 1];
        }
    }
}
