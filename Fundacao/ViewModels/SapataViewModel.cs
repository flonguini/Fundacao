using Fundacao.Models;
using Fundacao.ViewModels.Commands;

namespace Fundacao.ViewModels
{
    public class SapataViewModel 
    {
        private SapataModel _sapata;

        public DimensionarSapataCommand DimensionarSapataCommand { get; set; }

        public SapataModel Sapata
        {
            get { return _sapata; }
            set { _sapata = value; }
        }

        public SapataViewModel()
        {
            //Sapata = new SapataModel();
            DimensionarSapataCommand = new DimensionarSapataCommand(this);
        }

        public void DimensionarSapata(SapataModel sapataUI)
        {
            Sapata = sapataUI;
        }
    }
}


