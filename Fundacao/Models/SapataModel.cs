using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacao.Models
{
    public class SapataModel 
    {
        private DadosEntradaModel _dados;
        private GeometriaModel _geometria;
        private EsforcosModel _esforcos;
        private DetalhamentoModel _detalhamento;

        public SapataModel(DadosEntradaModel dados)
        {
            _dados = dados;
        }

        public DadosEntradaModel DadosEntrada 
        {
            get { return _dados; }
            set{ _dados = value; }
        }

        public GeometriaModel Geometria
        {
            get { return new GeometriaModel(_dados); }
            set { _geometria = value; }
        }

        public EsforcosModel Esforcos
        {
            get { return new EsforcosModel(this.DadosEntrada, this.Geometria); }
            set { _esforcos = value; }
        }

        public DetalhamentoModel Detalhamento
        {
            get { return new DetalhamentoModel(this.DadosEntrada); }
            set { _detalhamento = value; }
        }

    }
}
