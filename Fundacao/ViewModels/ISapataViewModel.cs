using Fundacao.ViewModels.Commands;
using SapataLibrary.Model;

namespace Fundacao.ViewModels
{
    public interface ISapataViewModel
    {
        DimensionarSapataCommand DimensionarSapataCommand { get; set; }
        double PilarMaiorLado { get; set; }
        double PilarMenorLado { get; set; }
        ISapataModel Sapata { get; set; }
        double TensaoAdmSolo { get; set; }
        double TensaoNormal { get; set; }

        void DimensionarSapata();
    }
}