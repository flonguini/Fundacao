namespace SapataLibrary.Model
{
    public interface IGeometriaModel
    {
        double Altura { get; }
        double AlturaFace { get; }
        double AnguloSuperficieInclinada { get; }
        double AreaSuporte { get; }
        double Balanco { get; }
        double MaiorLado { get; }
        double MenorLado { get; }
    }
}