using System;

namespace SapataLibrary.Model
{
    public class SapataModel : ISapataModel
    {
        #region Private fields

        private IDadosEntradaModel _dados;
        private IGeometriaModel _geometria;
        //private EsforcosModel _esforcos;
        //private DetalhamentoModel _detalhamento;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        /// <param name="dados"></param>
        public SapataModel(IDadosEntradaModel dados)
        {
            _dados = dados;
        }

        #endregion

        #region Public properties 

        /// <summary>
        /// Interface da classe Dados de entrada
        /// </summary>
        public IDadosEntradaModel DadosEntrada
        {
            get { return _dados; }
            set { _dados = value; }
        }

        /// <summary>
        /// Interface da classe Geometria
        /// </summary>
        public IGeometriaModel Geometria
        {
            get { return DimensionarGeometria(); }
            set { _geometria = value; }
        }


        /// <summary>
        /// Interface da classe dos esforços
        /// </summary>
        //public EsforcosModel Esforcos
        //{
        //    get { return new EsforcosModel(this.DadosEntrada, this.Geometria); }
        //    set { _esforcos = value; }
        //}

        /// <summary>
        /// Interface da classe de detalhamento
        /// </summary>
        //public DetalhamentoModel Detalhamento
        //{
        //    get { return new DetalhamentoModel(this.DadosEntrada); }
        //    set { _detalhamento = value; }
        //}

        #endregion

        private IGeometriaModel DimensionarGeometria()
        {
            return new GeometriaModel(_dados);
        }
    }
}