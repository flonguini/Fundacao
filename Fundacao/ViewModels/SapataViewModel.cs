using Fundacao.Models;
using Fundacao.ViewModels.Commands;

namespace Fundacao.ViewModels
{
    public class SapataViewModel : ModelBase
    {
        private SapataModel _sapata;
        private DadosEntradaModel _dadosEntrada = new DadosEntradaModel();
        private GeometriaModel _geometria;
        private EsforcosModel _esforcos;
        private double _pilarMenorLado;
        private double _pilarMaiorLado;
        private double _tensaoAdmissivelSolo;
        private double _tensaoNormal;
        private DetalhamentoModel _detalhamento;

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

        public GeometriaModel Geometria
        {
            get { return _geometria; }
            set
            {
                _geometria = value;
                OnPropertyChanged();
            }
        }

        public EsforcosModel Esforcos
        {
            get { return _esforcos; }
            set
            {
                _esforcos = value;
                OnPropertyChanged();
            }
        }

        public DetalhamentoModel Detalhamento
        {
            get { return _detalhamento; }
            set
            {
                _detalhamento = value;
                OnPropertyChanged();
            }
        }

        public double PilarMenorLado
        {
            get { return _pilarMenorLado; }
            set
            {
                _pilarMenorLado = value;

                if (Geometria.AreaSuporte.ToString() != "NaN") { DimensionarSapata(); }
                OnPropertyChanged();
            }
        }

        public double PilarMaiorLado
        {
            get { return _pilarMaiorLado; }
            set
            {
                _pilarMaiorLado = value;

                if (Geometria.AreaSuporte.ToString() != "NaN") { DimensionarSapata(); }

                OnPropertyChanged();
            }
        }

        public double TensaoAdmSolo
        {
            get { return _tensaoAdmissivelSolo; }
            set
            {
                _tensaoAdmissivelSolo = value;

                if (Geometria.AreaSuporte.ToString() != "NaN") { DimensionarSapata(); }

                OnPropertyChanged();
            }
        }

        public double TensaoNormal
        {
            get { return _tensaoNormal; }
            set
            {
                _tensaoNormal = value;

                if (Geometria.AreaSuporte.ToString() != "NaN") { DimensionarSapata(); }

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

            Geometria = new GeometriaModel(_dadosEntrada);

            Detalhamento = new DetalhamentoModel(_dadosEntrada);

            DimensionarSapataCommand = new DimensionarSapataCommand(this);
        }

        public void DimensionarSapata()
        {
            Sapata.DadosEntrada.TensaoAdmSolo = (TensaoAdmSolo/10000);
            Sapata.DadosEntrada.TensaoNormal = TensaoNormal;
            Sapata.DadosEntrada.PilarMaiorLado = PilarMaiorLado;
            Sapata.DadosEntrada.PilarMenorLado = PilarMenorLado;

            Geometria = new GeometriaModel(Sapata.DadosEntrada);
            Esforcos = new EsforcosModel(Sapata.DadosEntrada);
            Detalhamento = new DetalhamentoModel(Sapata.DadosEntrada);
        }
    }
}


