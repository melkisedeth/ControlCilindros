public class Ticket
{
    public string Cliente { get; set; }
    public string Vendedor { get; set; }
    public string Cilindro { get; set; }
    public string NumeroCilindro { get; set; }
    public double Peso { get; set; }
    public DateTime Fecha { get; set; }
    public string Tipo { get; set; }
    public string Estado { get; set; } = "PRESTADO";
}