public class Transaccion
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; }
    public Vendedor Vendedor { get; set; }
    public Vendedor VendedorRecibe { get; set; }
    public Cilindro Cilindro { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime FechaRecibido { get; set; }
    public double PesoFinal { get; set; }
    public double Consumo { get; set; }
    public double Total { get; set; }
    public string? estado { get; set; }


    public string ClienteInfo
    {
        get
        {
            return $"{Id} - {Cliente.Nombre} - {Vendedor.Nombre} - {CilindroInfo}  - {PesoFinal}";
        }
    }

    public string CilindroInfo
    {
        get
        {
            return $"{Cilindro.NumeroCilindro} {Cilindro.Tipo}";
        }
    }
}
public class TransaccionViewModel
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public string Vendedor { get; set; }
    public string VendedorRecibe { get; set; }
    public string Cilindro { get; set; }
    public DateTime FechaEntregado { get; set; }
    public DateTime? FechaRecibido { get; set; }
    public double PesoInicial { get; set; }
    public double PesoRecibido { get; set; }
    public double PrecioPorGramo { get; set; }
    public double PrecioTotal { get; set; }
    public double Consumo { get; set; }
}

public class TransaccionViewModelEntrega
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public string Vendedor { get; set; }
    public string Cilindro { get; set; }
    public DateTime FechaEntregado { get; set; }
    public double PesoInicial { get; set; }
    public double PrecioPorGramo { get; set; }
}
