using System.Collections.Generic;
using CompactCalculator.Commands;

namespace CompactCalculator
{
    /// <summary>
    /// Класс для управления историей команд (Invoker в паттерне Command)
    /// Отвечает за выполнение команд и поддержку отмены операций
    /// </summary>
    public class CommandHistory
    {
        private readonly Stack<ICommand> history;

        public CommandHistory()
        {
            history = new Stack<ICommand>();
        }

        /// <summary>
        /// Выполнить команду и добавить её в историю
        /// </summary>
        /// <param name="command">Команда для выполнения</param>
        public void Execute(ICommand command)
        {
            command.Execute();
            history.Push(command);
        }

        /// <summary>
        /// Отменить последнюю выполненную команду
        /// </summary>
        public void Undo()
        {
            if (history.Count > 0)
            {
                ICommand command = history.Pop();
                command.Undo();
            }
        }

        /// <summary>
        /// Очистить всю историю команд
        /// </summary>
        public void Clear()
        {
            history.Clear();
        }

        /// <summary>
        /// Получить количество команд в истории
        /// </summary>
        public int Count => history.Count;
    }
}
