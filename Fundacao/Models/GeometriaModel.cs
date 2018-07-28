using System;

namespace Fundacao.Models
{
    public class GeometriaModel : SapataModel
    {
        public GeometriaModel(DadosEntradaModel dados) : base(dados) { }

        public double MenorLado
        {
            get { return DimensionarMenorLado(); }
        }

        public double MaiorLado
        {
            get { return DimensionarMaiorLado(); }
        }

        public double AreaSuporte
        {
            get { return DimensionarAreaSuporte(); }
        }

        public double Altura
        {
            get { return DimensionarAltura(); }
        }

        public double Balanco
        {
            get { return DimensionarBalanco(); }
        }

        public double AnguloSuperficieInclinada
        {
            get { return DimensionarAnguloSuperficieInclinada(); }
        }

        public double AlturaFace
        {
            get { return DimensionarAlturaFace(); }
        }

        private double DimensionarAreaSuporte()
        {
            return 1.1 * DadosEntrada.TensaoNormal / DadosEntrada.TensaoAdmSolo;
        }

        private double DimensionarMenorLado()
        {
            return 0.5 * (DadosEntrada.PilarMenorLado - DadosEntrada.PilarMaiorLado) + Math.Sqrt((0.25 * Math.Pow(DadosEntrada.PilarMenorLado - DadosEntrada.PilarMaiorLado, 2)) + AreaSuporte);
        }

        private double DimensionarMaiorLado()
        {
            return (DadosEntrada.PilarMaiorLado - DadosEntrada.PilarMenorLado) + MenorLado;
        }

        private double DimensionarAltura()
        {
            return (MaiorLado - DadosEntrada.PilarMaiorLado) / 3;
        }

        private double DimensionarAlturaFace()
        {
            return ((Altura / 3) >= 15) ? Altura / 3 : 15;
        }

        private double DimensionarBalanco()
        {
            return 0.5 * (ArredondarValor(MaiorLado) - DadosEntrada.PilarMaiorLado);
        }

        private double DimensionarAnguloSuperficieInclinada()
        {
            return Math.Atan((Altura - AlturaFace) / Balanco) * 180 / Math.PI;
        }

        //Arredonda um valor para o próximo múltiplo de 5
        private double ArredondarValor(double valor)
        {
            return Math.Ceiling(valor / 5) * 5;
        }
    }
}
