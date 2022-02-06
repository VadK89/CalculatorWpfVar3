using CalculatorWpfVar3.Models.Calculations;
using InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpfVar3.Models
{
    public static class OperationChoose
    {
        public static ICalculable GetOperationClass(CalcModel.Operationss selectedOperator)
        {
            ICalculable calculateClass = default(ICalculable);

            switch (selectedOperator)
            {
                case CalcModel.Operationss.Addition:
                    calculateClass = new Addition();
                    break;
                case CalcModel.Operationss.Division:
                    calculateClass = new Division();
                    break;
                case CalcModel.Operationss.Multiplication:
                    calculateClass = new Multiplication();
                    break;
                case CalcModel.Operationss.Subtraction:
                    calculateClass = new Subtraction();
                    break;
                case CalcModel.Operationss.LogarithmDec:
                    calculateClass = new LogarithmDec();
                    break;
                case CalcModel.Operationss.LogarithmNat:
                    calculateClass = new LogarithmNat();
                    break;
                case CalcModel.Operationss.Sine:
                    calculateClass = new Sine();
                    break;
                case CalcModel.Operationss.Cosine:
                    calculateClass = new Cosine();
                    break;
                case CalcModel.Operationss.Tangent:
                    calculateClass = new Tangent();
                    break;
                case CalcModel.Operationss.Division1:
                    calculateClass = new Division1();
                    break;
                case CalcModel.Operationss.Sqr:
                    calculateClass = new Sqr();
                    break;
                case CalcModel.Operationss.Sqrt:
                    calculateClass = new Sqrt();
                    break;
                case CalcModel.Operationss.Cube:
                    calculateClass = new Cube();
                    break;
                case CalcModel.Operationss.Factorial:
                    calculateClass = new Factorial();
                    break;
            }

            return calculateClass;
        }
    }
}
