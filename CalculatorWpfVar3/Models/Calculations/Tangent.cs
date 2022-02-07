using InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpfVar3.Models.Calculations
{
    public class Tangent : ICalculable
    {
        public double Calculate(List<double> values)
        {
            return Math.Tan(DegreeToRadian(values[values.Count - 1]));
        }
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
