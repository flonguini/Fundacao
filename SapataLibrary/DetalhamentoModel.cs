using SteelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapataLibrary
{
    public class DetalhamentoModel : GeometriaModel
    {
        #region Constructor

        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        /// <param name="dados"></param>
        public DetalhamentoModel(DadosEntradaModel dados) : base(dados) { }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets e Sets o comprimento de ancoragem necessário
        /// </summary>
        public double ComprimentoAncoragem
        {
            get { return DimensionarComprimentoAncoragem(); }
        }

        /// <summary>
        /// Gets e Sets o comprimento do aço para o menor lado da sapata
        /// </summary>
        public double ComprimentoAcoMenorLado
        {
            get { return DimensionarComprimentoAco(nameof(ComprimentoAcoMenorLado)); }
        }

        /// <summary>
        /// Gets e Sets o comprimento do aço para o maior lado da sapata
        /// </summary>
        public double ComprimentoAcoMaiorLado
        {
            get { return DimensionarComprimentoAco(nameof(ComprimentoAcoMaiorLado)); }
        }

        /// <summary>
        /// Gets o tamanho da dobra do aço
        /// </summary>
        public double Dobra
        {
            get { return DimensionarDobra(); }
        }

        /// <summary>
        /// Gets o tamanho da dobra inclinada
        /// </summary>
        public double DobraInclinada
        {
            get { return DimensionarDobraInclinada(); }
        }

        /// <summary>
        /// Gets o comprimento total do aço para a maior dimensão da sapata
        /// </summary>
        public double ComprimentoTotalMaiorDimensao
        {
            get { return DimensionarComprimentoToal(nameof(ComprimentoTotalMaiorDimensao)); }
        }

        /// <summary>
        /// Gets o comprimento total do aço para a menor dimensão da sapata
        /// </summary>
        public double ComprimentoTotalMenorDimensao
        {
            get { return DimensionarComprimentoToal(nameof(ComprimentoTotalMenorDimensao)); }
        }

        #endregion

        #region Private Methods

        //Dimensiona o comprimento total da barra de aço para os dois lados da sapata
        private double DimensionarComprimentoToal(string lado)
        {
            //Caso o parâmetro seja a maior dimensão
            if (lado == "ComprimentoTotalMaiorDimensao")
            {
                return 2 * (Dobra + DobraInclinada) + ComprimentoAcoMaiorLado;
            }
            //Caso seja a menor dimensão
            return 2 * (Dobra + DobraInclinada) + ComprimentoAcoMenorLado;

        }

        //Dimensiona a dobra inclinada da sapata
        private double DimensionarDobraInclinada()
        {
            return ArredondarValor(ComprimentoAncoragem - Dobra);
        }

        //Dimensiona o tamanho da dobra dos dois lados
        private double DimensionarDobra()
        {
            //TODO: 4 deve ser trocado pelo cobrimento
            return ArredondarValor(AlturaFace - (2 * 4));
        }

        // Dimensiona o comprimento do aço para um determinado lado da sapata
        private double DimensionarComprimentoAco(string lado)
        {
            if (lado == nameof(ComprimentoAcoMaiorLado))
            {
                double ladoA = Math.Ceiling(MaiorLado / 5) * 5;
                //TODO: Passar 4 como parâmetro cobrimento
                return ladoA - (2 * 4);
            }
            return (Math.Ceiling(MenorLado / 5) * 5) - (2 * 4);
        }

        //Calcula o comprimento de ancoragem para uma determinada característica
        private double DimensionarComprimentoAncoragem()
        {
            Steel steel = new Steel(10, 25, TipoBarra.Nervurada, Aderencia.Boa, true);

            return Math.Round(steel.LbNec, 0);
        }

        //Arredonda para o próximo valor superior múltiplo de 5
        private double ArredondarValor(double valor)
        {
            return Math.Ceiling(valor / 5) * 5;
        }

        #endregion
    }
}
