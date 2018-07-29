using Fundacao.Models;
using Fundacao.ViewModels.Commands;

namespace Fundacao.ViewModels
{
    public class SapataViewModel : ModelBase
    {
        private SapataModel _sapata;
        private DadosEntradaModel _dadosEntrada = new DadosEntradaModel();
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
                OnPropertyChanged();
            }
        }

        public double PilarMenorLado
        {
            get { return _pilarMenorLado; }
            set
            {
                _pilarMenorLado = value;

                if (Sapata.Geometria.AreaSuporte.ToString() != "NaN") { DimensionarSapata(); }
                OnPropertyChanged();
            }
        }

        public double PilarMaiorLado
        {
            get { return _pilarMaiorLado; }
            set
            {
                _pilarMaiorLado = value;

                if (Sapata.Geometria.AreaSuporte.ToString() != "NaN") { DimensionarSapata(); }

                OnPropertyChanged();
            }
        }

        public double TensaoAdmSolo
        {
            get { return _tensaoAdmissivelSolo; }
            set
            {
                _tensaoAdmissivelSolo = value;

                if (Sapata.Geometria.AreaSuporte.ToString() != "NaN") { DimensionarSapata(); }

                OnPropertyChanged();
            }
        }

        public double TensaoNormal
        {
            get { return _tensaoNormal; }
            set
            {
                _tensaoNormal = value;

                if (Sapata.Geometria.AreaSuporte.ToString() != "NaN") { DimensionarSapata(); }

                OnPropertyChanged();
            }
        }

        public SapataViewModel()
        {
            _dadosEntrada.TensaoAdmSolo = TensaoAdmSolo;
            _dadosEntrada.TensaoNormal = TensaoNormal;
            _dadosEntrada.PilarMaiorLado = PilarMaiorLado;
            _dadosEntrada.PilarMenorLado = PilarMenorLado;

            Sapata = new SapataModel(_dadosEntrada);
           
            DimensionarSapataCommand = new DimensionarSapataCommand(this);
        }

        public void DimensionarSapata()
        {
            Sapata.DadosEntrada.TensaoAdmSolo = (TensaoAdmSolo/10000);
            Sapata.DadosEntrada.TensaoNormal = TensaoNormal;
            Sapata.DadosEntrada.PilarMaiorLado = PilarMaiorLado;
            Sapata.DadosEntrada.PilarMenorLado = PilarMenorLado;

            Sapata = new SapataModel(Sapata.DadosEntrada);
        }
    }
}


