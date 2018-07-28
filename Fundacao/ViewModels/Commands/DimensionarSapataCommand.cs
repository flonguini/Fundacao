using Fundacao.Models;
using System;
using System.Windows.Input;
using System.Diagnostics;

namespace Fundacao.ViewModels.Commands
{
    public class DimensionarSapataCommand : ICommand
    {
        public SapataViewModel SapataViewModel { get; set; }

        public DimensionarSapataCommand(SapataViewModel sapataViewModel)
        {
            SapataViewModel = sapataViewModel;
        }


        //Not the best way, fix that. RelayCommand
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
                if (sapata.PilarMaiorLado != 0 && 
                    sapata.PilarMenorLado != 0 && 
                    sapata.TensaoAdmSolo !=0 && 
                    sapata.TensaoNormal != 0)
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
