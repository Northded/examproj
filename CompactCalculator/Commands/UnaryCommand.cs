using System;

namespace CompactCalculator.Commands
{
    /// <summary>
    /// Конкретная команда для выполнения унарных операций (квадрат, корень и т.д.)
    /// </summary>
    public class UnaryCommand : ICommand
    {
        private readonly Calculator calculator;
        private readonly Func<double, double> operation;
        private double previousValue;

        /// <summary>
        /// Конструктор команды унарной операции
        /// </summary>
        /// <param name="calc">Калькулятор (получатель)</param>
        /// <param name="operation">Функция операции (например, x => x * x)</param>
        public UnaryCommand(Calculator calc, Func<double, double> operation)
        {
            this.calculator = calc;
            this.operation = operation;
        }

        public void Execute()
        {
            previousValue = calculator.Value;
            calculator.Value = operation(calculator.Value);
        }

        public void Undo()
        {
            calculator.Value = previousValue;
        }
    }
}
