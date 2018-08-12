using Autofac;
using Fundacao.Models;
using Fundacao.Startup;
using Fundacao.ViewModels.Commands;
using SapataLibrary.Model;

namespace Fundacao.ViewModels
{
    public class SapataViewModel : ViewModelBase, ISapataViewModel
    {
        #region Private fields

        private ISapataModel _sapata;
        private IDadosEntradaModel _dadosEntrada;
        private double _pilarMenorLado;
        private double _pilarMaiorLado;
        private double _tensaoAdmissivelSolo;
        private double _tensaoNormal;

        #endregion
                
        public DimensionarSapataCommand DimensionarSapataCommand { get; set; }

        #region Public Properties

        public ISapataModel Sapata
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

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public SapataViewModel()
        {
            Sapata = Bootstrapper.Resolve<ISapataModel>();

            _dadosEntrada = Bootstrapper.Resolve<IDadosEntradaModel>();

            DimensionarSapataCommand = new DimensionarSapataCommand(this);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Dimensiona as dimensões, esforços e detalhamento da sapata
        /// </summary>
        public void DimensionarSapata()
        {

            _dadosEntrada.TensaoAdmSolo = (TensaoAdmSolo / 10000);
            _dadosEntrada.TensaoNormal = TensaoNormal;
            _dadosEntrada.PilarMaiorLado = PilarMaiorLado;
            _dadosEntrada.PilarMenorLado = PilarMenorLado;

            Sapata = new SapataModel(_dadosEntrada);
            //Sapata = Bootstrapper.Resolve<ISapataModel>(new NamedParameter("dados", Sapata.DadosEntrada));
        }

        #endregion
    }
}


