using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelLibrary
{
    public class Steel
    {
        #region Private Fields

        private readonly TipoBarra _tipoBarra;
        private readonly Aderencia _aderencia;
        private readonly double _bitola;
        private double _fbd;
        private double _lb;
        private readonly double _fck;
        private readonly bool _gancho;

        #endregion

        #region Properties

        //Força de aderência da barra no concreto
        private double Fbd
        {
            get { return DimensionarFbd(); }
            set { _fbd = value; }
        }

        /// <summary>
        /// Retorna o comprimento de ancoragem básico
        /// </summary>
        public double Lb
        {
            get { return (_bitola * 50 / 1.15) / (40 * Fbd); }
            set { _lb = value; }
        }

        /// <summary>
        /// Retorna o comprimento de ancoragem necessário consideranco As,calc = As,ef
        /// </summary>
        public double LbNec
        {
            get { return _gancho ? 0.7 * Lb : Lb; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="bitola">Bitola da barra (mm)</param>
        /// <param name="fck">Fck do concreto (MPa)</param>
        /// <param name="barra">Tipo de barra: nervurada, entalhada e lisa</param>
        /// <param name="aderencia">Região de aderência, boa ou má</param>
        /// <param name="gancho">Barra com gancho ou não</param>
        public Steel(double bitola, double fck, TipoBarra tipoBarra, Aderencia aderencia, bool gancho)
        {
            _tipoBarra = tipoBarra;
            _aderencia = aderencia;
            _bitola = bitola;
            _fck = fck;
            _gancho = gancho;
        }

        #endregion

        #region Methods

        //Calcula o valor do Eta1 em função do tipo dee aço
        private static double Eta1(TipoBarra barra)
        {
            switch (barra)
            {
                //Caso a barra seja lisa
                case TipoBarra.Lisa:
                    return 1.0;
                //Caso a barra seja entalhada
                case TipoBarra.Entalhada:
                    return 1.4;
                //Caso a barra seja nervurada
                default:
                    return 2.25;
            }
        }

        //Calcula o valor do Eta2 em função do tipo de aderência
        private static double Eta2(Aderencia aderencia)
        {
            return aderencia ==  Aderencia.Boa ? 1 : 0.7;
        }

        //Calcula o Eta3 em função do diâmetro da bitola
        private static double Eta3(double bitola)
        {
            return bitola <= 32 ? 1 : (132 - bitola) / 100;
        }

        //Calcula a resistência de cálculo do concreto ao cisalhamento
        private double Fctd()
        {
            return 0.015 * Math.Pow(_fck, 2.0 / 3.0);
        }

        //Dimensiona a força de aderência do aço no concreto
        private double DimensionarFbd()
        {
            double eta1 = Eta1(_tipoBarra);
            double eta2 = Eta2(_aderencia);
            double eta3 = Eta3(_bitola);

            return eta1 * eta2 * eta3 * Fctd();
        }

        #endregion
    }
}
