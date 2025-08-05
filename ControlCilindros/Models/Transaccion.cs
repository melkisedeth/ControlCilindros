public class Transaccion
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; }
    public Vendedor Vendedor { get; set; }
    public Vendedor VendedorRecibe { get; set; }
    public Cilindro Cilindro { get; set; }
    public DateTime Fecha { get; set; }                // Fecha de préstamo
    public DateTime? FechaRecibido { get; set; }       // Fecha de devolución
    public double PesoInicial { get; set; }            // Peso al prestar
    public double PesoFinal { get; set; }              // Peso al devolver
    public double Consumo { get; set; }                // Peso consumido (calculado)
    public double PrecioPorGramo { get; set; }         // Precio vigente al momento del préstamo
    public double Total { get; set; }                  // Total a pagar (Consumo * PrecioPorGramo)
    public double MontoRecibido { get; set; }          // Cantidad que entrega el cliente
    public double Cambio { get; set; }                 // Vuelto a devolver
    public string? estado { get; set; }                // "prestado" o "devuelto"
    public string? Notas { get; set; }                 // Observaciones adicionales

    // Propiedades calculadas para mostrar información
    public string ClienteInfo => $"{Id} - {Cliente.Nombre} - {Vendedor.Nombre} - {CilindroInfo} - {PesoFinal}g";

    public string CilindroInfo => $"{Cilindro.NumeroCilindro} {Cilindro.Tipo}";

    public string EstadoDisplay => estado == "devuelto" ?
        $"Devuelto el {FechaRecibido:dd/MM/yyyy}" :
        "Prestado";

    public string MontoDisplay => estado == "devuelto" ?
        $"{Total:C2} (Recibido: {MontoRecibido:C2}, Cambio: {Cambio:C2})" :
        $"{PrecioPorGramo:C2}/gr";
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
    public double MontoRecibido { get; set; }
    public double Cambio { get; set; }
    public string Estado { get; set; }
    public string EstadoDisplay { get; set; }
    public string MontoDisplay { get; set; }
}

public class TransaccionViewModelEntrega
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public string Telefono { get; set; }
    public string Vendedor { get; set; }
    public string Cilindro { get; set; }
    public DateTime FechaEntregado { get; set; }
    public double PesoInicial { get; set; }
    public double PrecioPorGramo { get; set; }
}