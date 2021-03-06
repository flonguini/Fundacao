﻿using SteelLibrary;
using System;

namespace SapataLibrary.Model
{
    public class DadosEntradaModel : IDadosEntradaModel
    {
        #region Private fields

        //Dados de entrada do usuário
        private double _pilarMenorLado; 
        private double _pilarMaiorLado; 
        private double _tensaoAdmSolo; 
        private double _tensaoNormal;

        #endregion

        public DadosEntradaModel()
        {
            
        }

        #region Public properties
              
        /// <summary>
        /// Gets e Sets o lado menor do pilar
        /// </summary>
        public double PilarMenorLado
        {
            get { return _pilarMenorLado; }
            set
            {
                _pilarMenorLado = value;
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
            }
        }

        #endregion

    }
}
