using System;

namespace SapataLibrary.Model
{
    public class EsforcosModel 
    {
        #region Private fields

        private DadosEntradaModel _dados;
        private GeometriaModel _geometria;

        #endregion

        #region Constructor

        public EsforcosModel(DadosEntradaModel dados, GeometriaModel geometria) 
        {
            _geometria = geometria;
            _dados = dados;
        }

        #endregion

        #region Public Properties
        public double PressaoNoSolo
        {
            get { return DimensionarPressaoNoSolo(); }
        }

        /// <summary>
        /// Gets e sets o momento paralelo a menor dimensão da sapata
        /// </summary>
        public double MomentoParaleloMenorDimensao
        {
            get { return DimensionarMomento(nameof(MomentoParaleloMenorDimensao)); }
        }

        /// <summary>
        /// Gets e sets o momento paralelo a maior dimensão da sapata
        /// </summary>
        public double MomentoParaleloMaiorDimensao
        {
            get { return DimensionarMomento(nameof(MomentoParaleloMaiorDimensao)); }
        }

        /// <summary>
        /// Gets e sets a área de aço para a maior dimensão
        /// </summary>
        public double AreaAcoMaiorDimensao
        {
            get { return DimensaionarAreaAco(nameof(AreaAcoMaiorDimensao)); }
        }

        /// <summary>
        /// Gets e sets a área de aço para a menor dimensão
        /// </summary>
        public double AreaAcoMenorDimensao
        {
            get { return DimensaionarAreaAco(nameof(AreaAcoMenorDimensao)); }
        }

        /// <summary>
        /// Gets e sets a força cisalhante resistente
        /// </summary>
        public double CisalhanteResistente
        {
            get { return DimensionarCisalhanteResistente(); }
        }

        /// <summary>
        /// Gets e sets a força cisalhante atuante
        /// </summary>
        public double CisalhanteAtuante
        {
            get { return DimensionarCisalhanteAtuante(); }
        }

        #endregion

        #region Private Methods

        //Dimensiona a pressão exercida pela sapata no solo
        private double DimensionarPressaoNoSolo()
        {
            // TODO: 1.4 ajustar para gamaF
            return (1.4 * _dados.TensaoNormal) / (ArredondarValor(_geometria.MaiorLado) * ArredondarValor(_geometria.MenorLado));
        }

        //Dimensiona o momento solicitante para as duas direções da sapata
        private double DimensionarMomento(string direcao)
        {
            switch (direcao)
            {
                case "MomentoParaleloMaiorDimensao":
                    double xa = _geometria.Balanco + 0.15 * _dados.PilarMenorLado;
                    return PressaoNoSolo * Math.Pow(xa, 2) * ArredondarValor(_geometria.MaiorLado) * 0.5;

                case "MomentoParaleloMenorDimensao":
                    double xb = _geometria.Balanco + 0.15 * _dados.PilarMaiorLado;
                    return PressaoNoSolo * Math.Pow(xb, 2) * ArredondarValor(_geometria.MenorLado) * 0.5;

                default:
                    return 0;
            }
        }

        //Dimensiona a área de aço necessária para os dois lados da sapata
        private double DimensaionarAreaAco(string lado)
        {
            //TODO: Ajustar 50 para gamaS e 1.15 para fator de redução do usuário
            if (lado == "AreaAcoMenorDimensao")
            {
                return (MomentoParaleloMaiorDimensao * 115) / (0.85 * ArredondarValor(_geometria.Altura) * 50 * ArredondarValor(_geometria.MaiorLado));
            }
            return (MomentoParaleloMenorDimensao * 115) / (0.85 * ArredondarValor(_geometria.Altura) * 50 * ArredondarValor(_geometria.MenorLado));

        }

        //Dimensiona a força cisalhante resistente do concreto
        private double DimensionarCisalhanteResistente()
        {
            //TODO: Fck 25 deve entrar como parâmetro - 1.4 deve entrar como gammaF
            return 0.27 * (1.0 - (25.0 / 250.0)) * 2.5 / 1.4;
        }

        //Dimensiona a força cisalhante atuante
        private double DimensionarCisalhanteAtuante()
        {
            return (1.4 * _dados.TensaoNormal) / ((2 * (_dados.PilarMaiorLado + _dados.PilarMenorLado)) * ArredondarValor(_geometria.Altura));
        }

        //Arredonda um valor para o próximo múltiplo de 5
        private double ArredondarValor(double valor)
        {
            return Math.Ceiling(valor / 5) * 5;
        }

        #endregion
    }
}
