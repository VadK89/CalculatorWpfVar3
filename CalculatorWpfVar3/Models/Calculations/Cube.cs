﻿using InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpfVar3.Models.Calculations
{
    public class Cube : ICalculable
    {

        public double Calculate(List<double> values)
        {
            return Math.Pow((values[values.Count - 1]), 3);
        }

    }
}
