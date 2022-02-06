using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWpfVar3.Models
{
    public class CalcModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public enum Operationss { None, Addition, Subtraction, Multiplication, Division, LogarithmDec, LogarithmNat, Sine, Cosine, Tangent, Division1, Sqr, Sqrt, Cube, Factorial };
        
        private string mainDisp;
        private Func<List<double>, double> calcFunc;
        private Operationss selectedOperation;
        private List<double> operandsToCalc;
        private string calcHistory;
        private double? lastOperUsed;
        
        public double? LastOperUsed
        {
            get => lastOperUsed;
            set
            {
                lastOperUsed = value;
                OnPropertyChanged(nameof(LastOperUsed));
            }
        }
        public string CalcHistory
        {
            get => calcHistory;
            set
            {
                calcHistory = value;
                OnPropertyChanged(nameof(CalcHistory));
            }
        }
        public List<double> OperandsToCalculate
        {
            get => operandsToCalc;
            set
            {
                operandsToCalc = value;
                OnPropertyChanged(nameof(OperandsToCalculate));
            }
        }

        public Operationss SelectedOperation
        {
            get => selectedOperation;
            set
            {
                selectedOperation = value;
                OnPropertyChanged(nameof(SelectedOperation));
            }
        }
        public Func<List<double>, double> CalcFunc
        {
            get => calcFunc;
            set
            {
                calcFunc = value;
                OnPropertyChanged(nameof(CalcFunc));
            }
        }

        public string Display1
        {
            get => mainDisp;
            set
            {
                mainDisp = value;
                OnPropertyChanged(nameof(Display1));
            }
        }

    }
}
