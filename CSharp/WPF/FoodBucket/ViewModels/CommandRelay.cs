using System;
using System.Windows.Input;

namespace FoodBucket.ViewModels
{
    class CommandRelay : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public CommandRelay(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
