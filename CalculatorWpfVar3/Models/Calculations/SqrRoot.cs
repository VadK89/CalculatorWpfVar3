using InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpfVar3.Models.Calculations
{
    public class SqrRoot : ICalculable
    {
        public double Calculate(List<double> values)
        {
            return Math.Sqrt(values[values.Count - 1]);
        }
    }
}
