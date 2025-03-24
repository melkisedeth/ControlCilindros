public class Cilindro
{
    public int Id { get; set; }
    public string NumeroCilindro { get; set; }
    public string Tipo { get; set; }
    public string Estado { get; set; }
    public double PesoInicial { get; set; }
    public double PrecioPorGramo { get; set; }

    public string ClienteInfo
    {
        get
        {
            return $"{NumeroCilindro} - {Tipo}";
        }
    }
}