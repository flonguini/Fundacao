using System;

namespace Fundacao.Models
{
    public class SapataModel : ModelBase
    {
        #region Private fields

        //Geometria
        private double _pilarMenorLado; 
        private double _pilarMaiorLado; 
        private double _tensaoAdmSolo; 
        private double _menorLado;
        private double _maiorLado;
        private double _areaSuporte;
        private double _tensaoNormal;
        private double _altura;
        private double _balanco;
        private double _anguloSuperficieInclinada;
        private double _alturaFace;

        //Esforços
        private double _pressaoNoSolo;
        private double _momentoParaleloMenorDimensao;
        private double _momentoParaleloMaiorDimensao;
        private double _areaAcoMenorDimensao;
        private double _areaAcoMaiorDimensao;
        private double _cisalhanteResistente;
        private double _cisalhanteAtuante;

        //Detalhamento

        #endregion

        #region Public properties

        /// <summary>
        /// Gets e Sets o menor lado da sapa
        /// </summary>
        public double MenorLado
        {
            get { return DimensionarMenorLado(); }
            set{ _menorLado = value; }
        }

        /// <summary>
        /// Gets e Sets o maior lado da sapata
        /// </summary>
       public double MaiorLado
        {
            get { return DimensionarMaiorLado(); }
            set{ _maiorLado = value; }
        }

        /// <summary>
        /// Gets e Sets a área necessária para não romper o solo
        /// </summary>
        public double AreaSuporte
        {
            get { return DimensionarAreaSuporte();  }
            set{ _areaSuporte = value; }
        }

        /// <summary>
        /// Gets e Sets a altura da sapata
        /// </summary>
        public double Altura
        {
            get { return DimensionarAltura(); }
            set { _altura = value; }
        }

        /// <summary>
        /// Gets e Sets o balanço da sapata 
        /// </summary>
        public double Balanco
        {
            get { return DimensionarBalanco(); }
            set { _balanco = value; }
        }

        /// <summary>
        /// Gets e Sets o ângulo da superficie inclinada da sapata
        /// </summary>
        public double AnguloSuperficieInclinada
        {
            get => DimensionarAnguloSuperficieInclinada();
            set => _anguloSuperficieInclinada = value;
        }

        /// <summary>
        /// Gets e Sets o lado menor do pilar
        /// </summary>
        public double PilarMenorLado
        {
            get { return _pilarMenorLado; }
            set
            {
                _pilarMenorLado = value;
                OnPropertyChanged();
                PropriedadesAlteradas();
            }
        }

        /// <summary>
        /// Gets e Sets o lado maior do pilar
        /// </summary>
        public double PilarMaiorLado
        {
            get { return _pilarMaiorLado; }
            set
            {
                _pilarMaiorLado = value;
                OnPropertyChanged();
                PropriedadesAlteradas();
            }
        }

        /// <summary>
        /// Gets e Sets a tensão admissível do solo
        /// </summary>
        public double TensaoAdmSolo
        {
            get { return _tensaoAdmSolo; }
            set
            {
                _tensaoAdmSolo = value;
                OnPropertyChanged();
                PropriedadesAlteradas();
            }
        }

        /// <summary>
        /// Gets e Sets a tensão normal exercida na sapata
        /// </summary>
        public double TensaoNormal
        {
            get { return _tensaoNormal; }
            set
            {
                _tensaoNormal = value;
                OnPropertyChanged();
                PropriedadesAlteradas();
            }
        }

        /// <summary>
        /// Gets e Sets a altura da face da sapata
        /// </summary>
        public double AlturaFace
        {
            get { return DimensionarAlturaFace(); }
            set { _alturaFace = value; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////// Esforços
        /// <summary>
        /// Gets e sets a pressão de solo
        /// </summary>
        public double PressaoNoSolo
        {
            get { return DimensionarPressaoNoSolo(); }
            set { _pressaoNoSolo = value; }
        }

        /// <summary>
        /// Gets e sets o momento paralelo a menor dimensão da sapata
        /// </summary>
        public double MomentoParaleloMenorDimensao
        {
            get { return DimensionarMomento(nameof(MomentoParaleloMenorDimensao)); }
            set { _momentoParaleloMenorDimensao = value; }
        }

        /// <summary>
        /// Gets e sets o momento paralelo a maior dimensão da sapata
        /// </summary>
        public double MomentoParaleloMaiorDimensao
        {
            get { return DimensionarMomento(nameof(MomentoParaleloMaiorDimensao)); }
            set { _momentoParaleloMaiorDimensao = value; }
        }

        /// <summary>
        /// Gets e sets a área de aço para a maior dimensão
        /// </summary>
        public double AreaAcoMaiorDimensao
        {
            get { return DimensaionarAreaAco(nameof(AreaAcoMaiorDimensao)); }
            set { _areaAcoMaiorDimensao = value; }
        }

        /// <summary>
        /// Gets e sets a área de aço para a menor dimensão
        /// </summary>
        public double AreaAcoMenorDimensao
        {
            get { return DimensaionarAreaAco(nameof(AreaAcoMenorDimensao)); }
            set { _areaAcoMenorDimensao = value; }
        }

        /// <summary>
        /// Gets e sets a força cisalhante resistente
        /// </summary>
        public double CisalhanteResistente
        {
            get { return DimensionarCisalhanteResistente(); }
            set { _cisalhanteResistente = value; }
        }

        /// <summary>
        /// Gets e sets a força cisalhante atuante
        /// </summary>
        public double CisalhanteAtuante
        {
            get { return DimensionarCisalhanteAtuante(); }
            set { _cisalhanteAtuante = value; }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////// Detalhamento

        #endregion

        #region Methods

        //Dimensiona a área necessária para não romper o solos
        private double DimensionarAreaSuporte()
        {
            //TODO: Receber a procentagem de peso da sapata
            return 1.1 * TensaoNormal / TensaoAdmSolo;
        }

        //Dimensiona o menor lado da sapata
        private double DimensionarMenorLado()
        {
            return 0.5 * (PilarMenorLado - PilarMaiorLado) + Math.Sqrt((0.25 * Math.Pow(PilarMenorLado - PilarMaiorLado, 2)) + AreaSuporte);
        }

        //Dimensiona o maior lado da sapata
        private double DimensionarMaiorLado()
        {
            return (PilarMaiorLado - PilarMenorLado) + MenorLado;
        }

        //Dimensiona a altura da sapata
        private double DimensionarAltura()
        {
            return (MaiorLado - PilarMaiorLado) / 3;
        }

        //Dimensiona a altura da face da sapata
        private double DimensionarAlturaFace()
        {
            return ((Altura / 3) >= 15) ? Altura / 3 : 15; 
        }

        //Dimensiona o balanço da sapata
        private double DimensionarBalanco()
        {
            return 0.5 * (MaiorLado - PilarMaiorLado);
        }

        //Dimensiona o ângulo da face inclinada da sapata
        private double DimensionarAnguloSuperficieInclinada()
        {
            return Math.Atan((Altura - AlturaFace) / Balanco) * 180 / Math.PI;
        }

        ////////////////////////////////////////////////////////////////////////////////////// Esforços

        //Dimensiona a pressão exercida pela sapata no solo
        private double DimensionarPressaoNoSolo()
        {
            // TODO: 1.4 ajustar para gamaF
            return (1.4 * TensaoNormal) / (MaiorLado * MenorLado);
        }

        //Dimensiona o momento solicitante para as duas direções da sapata
        private double DimensionarMomento(string direcao)
        {
            switch (direcao)
            {
                case "MomentoParaleloMaiorDimensao":
                    double xa = Balanco + 0.15 * PilarMenorLado;
                    return PressaoNoSolo * Math.Pow(xa, 2) * MaiorLado * 0.5;

                case "MomentoParaleloMenorDimensao":
                    double xb = Balanco + 0.15 * PilarMaiorLado;
                    return PressaoNoSolo * Math.Pow(xb, 2) * MenorLado * 0.5;

                default:
                    return 0;
            }
        }

        //Dimensiona a área de aço necessária para os dois lados da sapata
        private double DimensaionarAreaAco(string lado)
        {
            //TODO: Ajustar 50 para gamaS e 1.15 para fator de redução do usuário
            switch (lado)
            {
                case "AreaAcoMenorDimensao":
                    return (MomentoParaleloMaiorDimensao * 1.15) / (0.85 * Altura * 50 * (MaiorLado / 100));

                case "AreaAcoMaiorDimensao":
                    return (MomentoParaleloMenorDimensao * 1.15) / (0.85 * Altura * 50 * (MenorLado / 100));

                default:
                    return 0;
            }
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
            return (1.4 * TensaoNormal) / ((2 * (PilarMaiorLado + PilarMenorLado)) * Altura);
        }

        // Passa os nomes das propriedades para a INPC 
        private void PropriedadesAlteradas()
        {
            OnPropertyChanged(nameof(MenorLado));
            OnPropertyChanged(nameof(MaiorLado));
            OnPropertyChanged(nameof(Altura));
            OnPropertyChanged(nameof(AreaSuporte));
            OnPropertyChanged(nameof(AlturaFace));
            OnPropertyChanged(nameof(Balanco));
            OnPropertyChanged(nameof(AnguloSuperficieInclinada));
            OnPropertyChanged(nameof(PressaoNoSolo));
            OnPropertyChanged(nameof(MomentoParaleloMaiorDimensao));
            OnPropertyChanged(nameof(MomentoParaleloMenorDimensao));
            OnPropertyChanged(nameof(AreaAcoMaiorDimensao));
            OnPropertyChanged(nameof(AreaAcoMenorDimensao));
            OnPropertyChanged(nameof(CisalhanteAtuante));
            OnPropertyChanged(nameof(CisalhanteResistente));
        }

        #endregion
    }
}
