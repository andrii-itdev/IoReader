﻿using System;
using System.Diagnostics;
using System.Windows.Input;

namespace IoReader.Commands
{
    public class RelayCommand : ICommand
    {
        #region Fields 

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion // Fields 

        #region Constructors 

        public RelayCommand(Action<object> execute) : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute)); 
            _canExecute = canExecute;
        }

        #endregion // Constructors 

        #region ICommand Members 

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public void Execute(object parameter) { _execute(parameter); }

        #endregion // ICommand Members 
    }

    public class RelayCommand<T> : ICommand
    {
        #region Fields

        readonly Action<T> _execute;
        readonly Predicate<T> _canExecute;

        #endregion // Fields 

        #region Constructors

        public RelayCommand(Action<T> execute) : this(execute, null) { }
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute)); _canExecute = canExecute;
        }

        #endregion // Constructors 

        #region ICommand Members
        
        [DebuggerStepThrough]
        public bool CanExecute(T parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public void Execute(T parameter)
        {
            _execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return (_canExecute == null) || (parameter is T tParameter) && CanExecute(tParameter);
        }

        public void Execute(object parameter)
        {
            if (parameter == null || parameter is T)
            {
                Execute((T)parameter);
            }
            else
            {
                throw new ArgumentException($"Incorrect type of {nameof(parameter)} argument. Expected {typeof(T).Name}");
            }
        }

        #endregion // ICommand Members 
    }
}
