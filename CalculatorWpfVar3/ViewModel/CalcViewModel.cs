using CalculatorWpfVar3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Runtime.Remoting.Messaging;

namespace CalculatorWpfVar3.ViewModel
{
    class CalcViewModel : INotifyPropertyChanged
    {
        #region Интерфейсы
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion Интерфейсы
        #region Свойства
        private CalcModel calcModel;
        private ICommand inputDisplay1Com;
        private ICommand negateDisplay1Com;
        private ICommand backspaceDisplay1Com;
        private ICommand operationPressCom;
        private ICommand calculateCom;
        private ICommand clearAll;

        public ICommand ClearAllCommand
        {
            get => clearAll;
            set
            {
                clearAll = value;
                OnPropertyChanged(nameof(ClearAllCommand));
            }
        }

        public ICommand CalculationCommand
        {
            get => calculateCom;
            set
            {
                calculateCom = value;
                OnPropertyChanged(nameof(CalculationCommand));
            }
        }

        public ICommand OperationPressedCommand
        {
            get => operationPressCom;
            set
            {
                operationPressCom = value;
                OnPropertyChanged(nameof(OperationPressedCommand));
            }
        }

        public ICommand BackspaceDisplay1Command
        {
            get => backspaceDisplay1Com;
            set
            {
                backspaceDisplay1Com = value;
                OnPropertyChanged(nameof(BackspaceDisplay1Command));
            }
        }

        public ICommand NegateDisplay1Command
        {
            get => negateDisplay1Com;
            set
            {
                negateDisplay1Com = value;
                OnPropertyChanged(nameof(NegateDisplay1Command));
            }
        }

        public ICommand InputDisplay1Command
        {
            get => inputDisplay1Com;
            set
            {
                inputDisplay1Com = value;
                OnPropertyChanged(nameof(InputDisplay1Command));
            }
        }

        public CalcModel CalcModel
        {
            get => calcModel;
            set
            {
                calcModel = value;
                OnPropertyChanged(nameof(CalcModel));
            }
        }
        #endregion Свойства 
        #region Конструкторы
        public CalcViewModel()
        {
            InitializeModelInstance();
            InitializeCommands();
        }
        #endregion
        #region Инициализаторы
        private void InitializeCommands()
        {
            CalcModel = new CalcModel()
            {
                Display1 = "0",
                CalcHistory = "",
                OperandsToCalculate = new List<double>(),
                SelectedOperation = (int)CalcModel.Operationss.None,
                LastOperUsed = null
            };
        }

        private void InitializeModelInstance()
        {
            InputDisplay1Command = new RelayCommanParam(InputDisplay1Command_Execute, InputDisplay1Command_CanExecute);
            NegateDisplay1Command = new RelayCommand(NegateDisplay1Command_Execute, NegateDisplay1Command_CanExecute);
            BackspaceDisplay1Command = new RelayCommand(BackspaceDisplay1Command_Execute, BackspaceDisplay1Command_CanExecute);
            OperationPressedCommand = new RelayCommanParam(OperationPressedCommand_Execute, OperationPressedCommand_CanExecute);
            CalculationCommand = new RelayCommand(CalculationCommand_Execute, CalculationCommand_CanExecute);
            ClearAllCommand = new RelayCommand(ClearAllCommand_Execute, ClearAllCommand_CanExecute);
        }
        #endregion
        #region Методы команд
        private void ClearAllCommand_Execute()
        {
            CalcModel = new CalcModel()
            {
                Display1 = "0",
                CalcHistory = string.Empty,
                CalcFunc = null,
                OperandsToCalculate = new List<double>(),
                SelectedOperation = (int)CalcModel.Operationss.None,
                LastOperUsed = null
            };
        }
        private bool ClearAllCommand_CanExecute()
        {
            return true;
        }

        private bool InputDisplay1Command_CanExecute()
        {
            return true;
        }
        private void InputDisplay1Command_Execute(object uiElement)
        {
            if (uiElement is Button button)
            {

                InputDisplay1(button.Content);
            }
        }


        private bool NegateDisplay1Command_CanExecute()
        {
            return !string.IsNullOrEmpty(CalcModel.Display1) && !CalcModel.Display1.Equals("0");
        }
        private void NegateDisplay1Command_Execute()
        {
            NegateDisplay1Value();
        }


        private bool BackspaceDisplay1Command_CanExecute()
        {
            return !CalcModel.Display1.Equals("0");
        }
        private void BackspaceDisplay1Command_Execute()
        {
            BackspaceDisplay1Value();
        }


        private bool OperationPressedCommand_CanExecute()
        {
            return true;
        }
        private void OperationPressedCommand_Execute(object uiElement)
        {
            if (uiElement is Button button)
            {
                var buttonContent = button.Content;
                var functionCalledFrom = "OperationButton";

                ClearLastUsedValue();

                CalcModel.SelectedOperation = OperatorBase.GetOperator(buttonContent);
                CalcModel.CalcFunc = OperationChoose.GetOperationClass(CalcModel.SelectedOperation).Calculate;

                AddValueToCalculList(double.Parse(CalcModel.Display1));
                ClearMainDisplay();

                CalcModel.CalcHistory = CalcModel.OperandsToCalculate[CalcModel.OperandsToCalculate.Count - 1] + " " + buttonContent;

                if (CalcModel.SelectedOperation == CalcModel.Operationss.Sqrt)
                    StartCalculation(functionCalledFrom);
            }
        }


        private bool CalculationCommand_CanExecute()
        {
            return CalcModel.SelectedOperation != CalcModel.Operationss.None;
        }
        private void CalculationCommand_Execute()
        {
            var currentValueDisplayed = double.Parse(CalcModel.Display1);
            var functionCalledFrom = "EqualsButton";

            AddValueToCalculList(currentValueDisplayed);
            SetLastUsedValue(currentValueDisplayed);
            StartCalculation(functionCalledFrom);
        }
        #endregion
        #region Логика
        private void NegateDisplay1Value()
        {
            var currentDisplayText = CalcModel.Display1;

            if (!CalcModel.Display1.StartsWith("-"))
                CalcModel.Display1 = "-" + currentDisplayText;
            else
                CalcModel.Display1 = currentDisplayText.Substring(1, CalcModel.Display1.Length - 1);
        }

        private void BackspaceDisplay1Value()
        {

            if (CalcModel.Display1.Length == 1 || (CalcModel.Display1.StartsWith("-") && CalcModel.Display1.Length == 2))
                CalcModel.Display1 = "0";
            else
                CalcModel.Display1 = CalcModel.Display1.Substring(0, CalcModel.Display1.Length - 1);
        }

        private void ClearLastUsedValue()
        {
            CalcModel.LastOperUsed = null;
        }

        private void ClearMainDisplay()
        {
            CalcModel.Display1 = "0";
        }

        private void StartCalculation(string functionCalledFrom)
        {
            CalcModel.CalcFunc.BeginInvoke(CalcModel.OperandsToCalculate, CalculateFuncCback, functionCalledFrom);
        }

        private void CalculateFuncCback(IAsyncResult ar)
        {
            AsyncResult result = ar as AsyncResult;
            var caller = result.AsyncDelegate as Func<List<double>, double>;
            var functionCalledFrom = result.AsyncState as string;

            if (functionCalledFrom.Equals("EqualsButton"))
                CalcModel.CalcHistory = "";

            CalcModel.Display1 = caller.EndInvoke(result).ToString();
        }
        
        private void AddValueToCalculList(double val)
        {
            CalcModel.OperandsToCalculate.Add(val);
        }
        private void SetLastUsedValue(double val)
        {
            if (CalcModel.LastOperUsed == null)
                CalcModel.LastOperUsed = val;
            else
                AddLastValueUsedToCalcList();
        }

        private void AddLastValueUsedToCalcList()
        {
            CalcModel.OperandsToCalculate.Add(CalcModel.LastOperUsed.Value);
        }

        private void InputDisplay1(object contentUser)
        {
            string buttonText = contentUser.ToString();

            if (buttonText.Equals("."))
                InputPeriodToDisplay1(buttonText);
            else
                InputNumToDisplay1(buttonText);
        }

        private void InputNumToDisplay1(string buttonText)
        {
            if (CalcModel.Display1.Equals("0"))
                CalcModel.Display1 = buttonText;
            else
                CalcModel.Display1 += buttonText;
        }

        private void InputPeriodToDisplay1(string buttonText)
        {
            if (!CalcModel.Display1.Contains("."))
                CalcModel.Display1 += buttonText;
        }
        #endregion
    }
}
