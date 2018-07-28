using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacao.Models
{
    public class SapataModel : ModelBase
    {
        private DadosEntradaModel _dados;

        public SapataModel(DadosEntradaModel dados)
        {
            _dados = dados;
        }

        public DadosEntradaModel DadosEntrada 
        {
            get { return _dados; }
            set{ _dados = value; }
        }

    }
}
