using System;

namespace Fundacao.Models
{
    public class SapataModel : ModelBase
    {
        #region Private fields

        private double _pilarMenorLado; 
        private double _pilarMaiorLado; 
        private double _tensaoAdmissivelSolo; 
        private double _menorLado;
        private double _maiorLado;
        private double _areaSuporte;
        private double _tensaoNormal;
        private double _altura;

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
        public double TensaoAdmissivelSolo
        {
            get { return _tensaoAdmissivelSolo; }
            set
            {
                _tensaoAdmissivelSolo = value;
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

        #endregion

        #region Methods

        //Dimensiona a área necessária para não romper o solos
        private double DimensionarAreaSuporte()
        {
            return 1.1 * TensaoNormal / TensaoAdmissivelSolo;
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

        // Passa os nomes das propriedades para a INPC 
        private void PropriedadesAlteradas()
        {
            OnPropertyChanged("MenorLado");
            OnPropertyChanged("MaiorLado");
            OnPropertyChanged("Altura");
            OnPropertyChanged("AreaSuporte");
        }

        #endregion
    }
}
