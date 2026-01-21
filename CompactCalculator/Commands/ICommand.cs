namespace CompactCalculator.Commands
{
    /// <summary>
    /// Интерфейс команды в паттерне Command
    /// Определяет методы для выполнения и отмены операции
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Выполнить команду
        /// </summary>
        void Execute();

        /// <summary>
        /// Отменить выполнение команды (Undo)
        /// </summary>
        void Undo();
    }
}
