namespace SapataLibrary.Model
{
    public interface ISapataModel
    {
        IDadosEntradaModel DadosEntrada { get; set; }
        IGeometriaModel Geometria { get; set; }
        //DetalhamentoModel Detalhamento { get; set; }
        //EsforcosModel Esforcos { get; set; }
    }
}