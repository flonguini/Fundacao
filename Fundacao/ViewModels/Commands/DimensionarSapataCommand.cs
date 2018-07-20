using Fundacao.Models;
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


        //Not the best way, fix that.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                var sapata = (SapataViewModel)parameter; // var sapata = parameter as SapataViewModel
                if (sapata.PilarMaiorLado != 0 && sapata.PilarMenorLado != 0 && sapata.TensaoAdmissivelSolo !=0 && sapata.TensaoNormal != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void Execute(object parameter)
        {
            SapataViewModel.DimensionarSapata();
        }
    }
}
