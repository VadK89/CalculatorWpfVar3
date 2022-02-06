namespace CalculatorWpfVar3.Models
{
    public static class OperatorBase
    {
        public static CalcModel.Operationss GetOperator(object operatorPressed)
        {
            var selectedOperator = default(CalcModel.Operationss);

            switch (operatorPressed.ToString())
            {
                case "+":
                    selectedOperator = CalcModel.Operationss.Addition;
                    break;
                case "-":
                    selectedOperator = CalcModel.Operationss.Subtraction;
                    break;
                case "x":
                    selectedOperator = CalcModel.Operationss.Multiplication;
                    break;
                case "÷":
                    selectedOperator = CalcModel.Operationss.Division;
                    break;
                case "Log":
                    selectedOperator = CalcModel.Operationss.LogarithmDec;
                    break;
                case "Ln":
                    selectedOperator = CalcModel.Operationss.LogarithmNat;
                    break;
                case "Sin":
                    selectedOperator = CalcModel.Operationss.Sine;
                    break;
                case "Cos":
                    selectedOperator = CalcModel.Operationss.Cosine;
                    break;
                case "Tan":
                    selectedOperator = CalcModel.Operationss.Tangent;
                    break;
                case "1/x":
                    selectedOperator = CalcModel.Operationss.Division1;
                    break;
                case "^2":
                    selectedOperator = CalcModel.Operationss.Sqr;
                    break;
                case "√":
                    selectedOperator = CalcModel.Operationss.Sqrt;
                    break;
                case "^3":
                    selectedOperator = CalcModel.Operationss.Cube;
                    break;
                case "!x":
                    selectedOperator = CalcModel.Operationss.Factorial;
                    break;

                default:
                    selectedOperator = CalcModel.Operationss.None;
                    break;
            }

            return selectedOperator;
        }
    }
}