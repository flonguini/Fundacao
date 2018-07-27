using System.ComponentModel;
using System.Runtime.CompilerServices;
using SteelLibrary;

namespace Fundacao.Models
{
    public class ModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Evento que é acionado quando há uma alteração de propriedade
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Método para invocar o evento de alteração da propriedade
        /// </summary>
        /// <param name="propertyName">Nome da propriedade que foi alterada</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
