using System;

namespace CompactCalculator.Commands
{
    /// <summary>
    /// Конкретная команда для выполнения бинарных операций (сложение, вычитание и т.д.)
    /// </summary>
    public class OperationCommand : ICommand
    {
        private readonly Calculator calculator;
        private readonly double operand;
        private readonly Func<double, double, double> operation;
        private double previousValue;

        /// <summary>
        /// Конструктор команды операции
        /// </summary>
        /// <param name="calc">Калькулятор (получатель)</param>
        /// <param name="operand">Второй операнд</param>
        /// <param name="operation">Функция операции (например, (a,b) => a + b)</param>
        public OperationCommand(Calculator calc, double operand, Func<double, double, double> operation)
        {
            this.calculator = calc;
            this.operand = operand;
            this.operation = operation;
        }

        public void Execute()
        {
            previousValue = calculator.Value;
            calculator.Value = operation(calculator.Value, operand);
        }

        public void Undo()
        {
            calculator.Value = previousValue;
        }
    }
}
