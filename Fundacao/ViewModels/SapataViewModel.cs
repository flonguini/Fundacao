using Fundacao.Models;

namespace Fundacao.ViewModels
{
    public class SapataViewModel
    {
        private SapataModel _sapata = new SapataModel();

        public SapataModel Sapata
        {
            get { return _sapata; }
            set
            {
                _sapata = value;
            }
        }

        public SapataViewModel()
        {
        }

  
    }
}
