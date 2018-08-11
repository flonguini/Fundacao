namespace SapataLibrary.Model
{
    public interface IDadosEntradaModel
    {
        double PilarMaiorLado { get; set; }
        double PilarMenorLado { get; set; }
        double TensaoAdmSolo { get; set; }
        double TensaoNormal { get; set; }
    }
}