using Fundacao.Models;
using Fundacao.ViewModels.Commands;

namespace Fundacao.ViewModels
{
    public class SapataViewModel : ModelBase
    {
        private SapataModel _sapata;
        private double _pilarMenorLado;
        private double _pilarMaiorLado;
        private double _tensaoAdmissivelSolo;
        private double _tensaoNormal;

        public DimensionarSapataCommand DimensionarSapataCommand { get; set; }

        public SapataModel Sapata
        {
            get { return _sapata; }
            set
            {
                _sapata = value;
            }
        }

        public double PilarMenorLado
        {
            get { return _pilarMenorLado; }
            set
            {
                _pilarMenorLado = value;
                OnPropertyChanged();
            }
        }

        public double PilarMaiorLado
        {
            get { return _pilarMaiorLado; }
            set
            {
                _pilarMaiorLado = value;
                OnPropertyChanged();
            }
        }

        public double TensaoAdmissivelSolo
        {
            get { return _tensaoAdmissivelSolo; }
            set
            {
                _tensaoAdmissivelSolo = value;
                OnPropertyChanged();
            }
        }

        public double TensaoNormal
        {
            get { return _tensaoNormal; }
            set
            {
                _tensaoNormal = value;
                if (Sapata.MenorLado.ToString() != "NaN")
                {
                    DimensionarSapata();
                }
                OnPropertyChanged();
            }
        }

        public SapataViewModel()
        {
            Sapata = new SapataModel();
            DimensionarSapataCommand = new DimensionarSapataCommand(this);
        }

        public void DimensionarSapata()
        {
            Sapata.TensaoNormal = TensaoNormal;
            Sapata.TensaoAdmissivelSolo = TensaoAdmissivelSolo;
            Sapata.PilarMaiorLado = PilarMaiorLado;
            Sapata.PilarMenorLado = PilarMenorLado;
        }
    }
}


