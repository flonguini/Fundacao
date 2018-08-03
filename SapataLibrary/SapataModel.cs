using System;

namespace SapataLibrary
{
    public class SapataModel
    {
        #region Private fields

        private DadosEntradaModel _dados;
        private GeometriaModel _geometria;
        private EsforcosModel _esforcos;
        private DetalhamentoModel _detalhamento;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        /// <param name="dados"></param>
        public SapataModel(DadosEntradaModel dados)
        {
            _dados = dados;
        }

        #endregion

        #region Public properties 

        /// <summary>
        /// Interface da classe Dados de entrada
        /// </summary>
        public DadosEntradaModel DadosEntrada
        {
            get { return _dados; }
            set { _dados = value; }
        }

        /// <summary>
        /// Interface da classe Geometria
        /// </summary>
        public GeometriaModel Geometria
        {
            get { return new GeometriaModel(_dados); }
            set { _geometria = value; }
        }

        /// <summary>
        /// Interface da classe dos esforços
        /// </summary>
        public EsforcosModel Esforcos
        {
            get { return new EsforcosModel(this.DadosEntrada, this.Geometria); }
            set { _esforcos = value; }
        }

        /// <summary>
        /// Interface da classe de detalhamento
        /// </summary>
        public DetalhamentoModel Detalhamento
        {
            get { return new DetalhamentoModel(this.DadosEntrada); }
            set { _detalhamento = value; }
        }

        #endregion
    }
}