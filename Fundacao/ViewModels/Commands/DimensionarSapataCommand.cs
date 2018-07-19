using System;
using System.Windows.Input;

namespace Fundacao.ViewModels.Commands
{
    public class DimensionarSapataCommand : ICommand
    {
        public SapataViewModel SapataViewModel { get; set; }

        public DimensionarSapataCommand(SapataViewModel sapataViewModel)
        {
            SapataViewModel = sapataViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (CanExecuteChanged != null)
            {
                return true;
            }
           return false;
        }

        public void Execute(object parameter)
        {
            SapataViewModel.DimensionarSapata();
        }
    }
}
