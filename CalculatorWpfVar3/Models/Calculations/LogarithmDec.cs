using InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpfVar3.Models.Calculations
{
    public class LogarithmDec : ICalculable
    {
        public double Calculate(List<double> values)
        {
            return Math.Log((values[values.Count - 1]), 10);
        } 
    }
}
