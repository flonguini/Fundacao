using System;

namespace SapataLibrary.Model
{
    public class GeometriaModel : IGeometriaModel
    {
        #region Private Fields

        private readonly IDadosEntradaModel _dados;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor padrão da classe Geometria
        /// </summary>
        /// <param name="dados">Parâmetros de entrada da classe EntradaDadosModel</param>
        public GeometriaModel(IDadosEntradaModel dados)
        {
            _dados = dados;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Recebe o valor do menor lado da sapata
        /// </summary>
        public double MenorLado { get => DimensionarMenorLado(); }

        /// <summary>
        /// Recebe o valor do maior lado da sapata
        /// </summary>
        public double MaiorLado { get =>  DimensionarMaiorLado(); }
        
        /// <summary>
        /// Recebe a área necessária para não romper o solo
        /// </summary>
        public double AreaSuporte { get => DimensionarAreaSuporte(); }

        /// <summary>
        /// Recebe a altura total da sapata
        /// </summary>
        public double Altura { get => DimensionarAltura(); }

        /// <summary>
        /// Recebe o balanço para o cálculo do momento fletor
        /// </summary>
        public double Balanco { get => DimensionarBalanco(); }

        /// <summary>
        /// Recebe o ângulo da superfície inclinada
        /// </summary>
        public double AnguloSuperficieInclinada { get => DimensionarAnguloSuperficieInclinada(); }

        /// <summary>
        /// Recebe a altura da face da sapata
        /// </summary>
        public double AlturaFace { get => DimensionarAlturaFace(); }

        #endregion

        #region Private Methods

        //Dimensiona a área de suporte
        private double DimensionarAreaSuporte()
        {
            return 1.1 * _dados.TensaoNormal / _dados.TensaoAdmSolo;
        }

        //Dimensiona o menor lado da sapata
        private double DimensionarMenorLado()
        {
            return 0.5 * (_dados.PilarMenorLado - _dados.PilarMaiorLado) + Math.Sqrt((0.25 * Math.Pow(_dados.PilarMenorLado - _dados.PilarMaiorLado, 2)) + AreaSuporte);
        }

        //Dimensiona o maior lado da sapata
        private double DimensionarMaiorLado()
        {
            return (_dados.PilarMaiorLado - _dados.PilarMenorLado) + MenorLado;
        }

        //Dimensiona a altura total da sapata
        private double DimensionarAltura()
        {
            return (MaiorLado - _dados.PilarMaiorLado) / 3;
        }

        //Dimensiona a altura da face da sapata
        private double DimensionarAlturaFace()
        {
            return ((Altura / 3) >= 15) ? Altura / 3 : 15;
        }

        //Dimensiona o balanço para o cálculo do momento fletor
        private double DimensionarBalanco()
        {
            return 0.5 * (ArredondarValor(MaiorLado) - _dados.PilarMaiorLado);
        }

        //Dimensiona o ângulo da superfício inclinada
        private double DimensionarAnguloSuperficieInclinada()
        {
            return Math.Atan((Altura - AlturaFace) / Balanco) * 180 / Math.PI;
        }

        //Arredonda um valor para o próximo múltiplo de 5
        private double ArredondarValor(double valor)
        {
            return Math.Ceiling(valor / 5) * 5;
        }

        #endregion
    }
}
