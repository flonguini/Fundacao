﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        #region Public properties

        public double MenorLado
        {
            get { return DimensionarMenorLado(); }
            set
            {
                _menorLado = value;
                OnPropertyChanged();
            }
        }

       public double MaiorLado
        {
            get { return DimensionarMaiorLado(); }
            set
            {
                _maiorLado = value;
                OnPropertyChanged();
            }
        }

        public double AreaSuporte
        {
            get { return DimensionarAreaSuporte();  }
            set
            {
                _areaSuporte = value;
                OnPropertyChanged();
            }
        }

        public double PilarMenorLado
        {
            get { return _pilarMenorLado; }
            set
            {
                _pilarMenorLado = value;
                OnPropertyChanged();
                OnPropertyChanged("MenorLado");
                OnPropertyChanged("MaiorLado");
                OnPropertyChanged("AreaSuporte");
            }
        }

        public double PilarMaiorLado
        {
            get { return _pilarMaiorLado; }
            set
            {
                _pilarMaiorLado = value;
                OnPropertyChanged();
                OnPropertyChanged("MenorLado");
                OnPropertyChanged("MaiorLado");
                OnPropertyChanged("AreaSuporte");
            }
        }

        public double TensaoAdimissivelSolo
        {
            get { return _tensaoAdmissivelSolo; }
            set
            {
                _tensaoAdmissivelSolo = value;
                OnPropertyChanged();
                OnPropertyChanged("MenorLado");
                OnPropertyChanged("MaiorLado");
                OnPropertyChanged("AreaSuporte");
            }
        }

        public double TensaoNormal
        {
            get { return _tensaoNormal; }
            set
            {
                _tensaoNormal = value;
                OnPropertyChanged();
            }
        }
        
        #endregion


        #region Methods

        private double DimensionarAreaSuporte()
        {
            return 1.1 * TensaoNormal / TensaoAdimissivelSolo;
        }

        private double DimensionarMenorLado()
        {
            return 0.5 * (PilarMenorLado - PilarMaiorLado) + Math.Sqrt((0.25 * Math.Pow(PilarMenorLado - PilarMaiorLado, 2)) + AreaSuporte);
        }

        private double DimensionarMaiorLado()
        {
            return (PilarMaiorLado - PilarMenorLado) + MenorLado;
        }
        #endregion
    }
}
