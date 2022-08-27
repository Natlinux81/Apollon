using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.WPF.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _isExecuring;
        public bool IsExecuting
        {
            get
            {
                return _isExecuring;
            }
            set
            {
                _isExecuring = value; 
                OnCanExecutedChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }
        public override async void Execute(object parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
            finally 
            {
                IsExecuting = false;
            }
        }
        public abstract Task ExecuteAsync(object parameter);
    }    
}
