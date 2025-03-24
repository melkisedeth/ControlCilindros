using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace ControlCilindros
{
    public partial class Form2 : Form
    {
        private const string RutaClientes = "clientes.txt";
        private const string RutaVendedores = "vendedores.txt";
        private const string RutaCilindros = "cilindros.txt";
        private const string RutaTransacciones = "transacciones.txt";

        private List<Cliente> clientes = new List<Cliente>();
        private List<Vendedor> vendedores = new List<Vendedor>();
        private List<Cilindro> cilindros = new List<Cilindro>();
        private List<Transaccion> transacciones = new List<Transaccion>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            clientes = CargarDatos<Cliente>(RutaClientes);
            vendedores = CargarDatos<Vendedor>(RutaVendedores);
            cilindros = CargarDatos<Cilindro>(RutaCilindros);
            transacciones = CargarDatos<Transaccion>(RutaTransacciones);

            ActualizarTransaccionesGridR22();
            ActualizarTransaccionesGridR410();
            ActualizarTransaccionesGridR134();
            ActualizarResumenes();
        }

        private void ActualizarTransaccionesGridR22()
        {
            dgvHistorialR22.AllowUserToAddRows = false;

            var transaccionesDevueltas = transacciones
                .Where(t => t.estado == "devuelto" && t.Cilindro.Tipo == "R22")
                .OrderBy(t => t.FechaRecibido)
                .ThenBy(t => t.Id)
                .Select(t => new TransaccionViewModel
                {
                    Id = t.Id,
                    Cliente = t.Cliente.Nombre,
                    Vendedor = t.Vendedor.Nombre,
                    VendedorRecibe = t.VendedorRecibe?.Nombre,
                    Cilindro = t.CilindroInfo,
                    FechaEntregado = t.Fecha,
                    FechaRecibido = t.FechaRecibido,
                    PesoInicial = t.PesoFinal + t.Consumo,
                    PesoRecibido = t.PesoFinal,
                    PrecioPorGramo = Math.Round(t.Cilindro.PrecioPorGramo, 2),
                    PrecioTotal = Math.Round(t.Total, 2),
                    Consumo = t.Consumo
                })
                .ToList();

            dgvHistorialR22.DataSource = new BindingList<TransaccionViewModel>(transaccionesDevueltas);

            dgvHistorialR22.Columns["PrecioPorGramo"].DefaultCellStyle.Format = "C0";
            dgvHistorialR22.Columns["PrecioTotal"].DefaultCellStyle.Format = "C0";
            dgvHistorialR22.Columns["PesoInicial"].DefaultCellStyle.Format = "N0";
            dgvHistorialR22.Columns["PesoRecibido"].DefaultCellStyle.Format = "N0";
            dgvHistorialR22.Columns["Consumo"].DefaultCellStyle.Format = "N0";
        }

        private void ActualizarTransaccionesGridR410()
        {
            dgvHistorialR10.AllowUserToAddRows = false;

            var transaccionesDevueltas = transacciones
                .Where(t => t.estado == "devuelto" && t.Cilindro.Tipo == "R410")
                .OrderBy(t => t.FechaRecibido)
                .ThenBy(t => t.Id)
                .Select(t => new TransaccionViewModel
                {
                    Id = t.Id,
                    Cliente = t.Cliente.Nombre,
                    Vendedor = t.Vendedor.Nombre,
                    VendedorRecibe = t.VendedorRecibe?.Nombre,
                    Cilindro = t.CilindroInfo,
                    FechaEntregado = t.Fecha,
                    FechaRecibido = t.FechaRecibido,
                    PesoInicial = t.PesoFinal + t.Consumo,
                    PesoRecibido = t.PesoFinal,
                    PrecioPorGramo = Math.Round(t.Cilindro.PrecioPorGramo, 2),
                    PrecioTotal = Math.Round(t.Total, 2),
                    Consumo = t.Consumo
                })
                .ToList();

            dgvHistorialR10.DataSource = new BindingList<TransaccionViewModel>(transaccionesDevueltas);

            dgvHistorialR10.Columns["PrecioPorGramo"].DefaultCellStyle.Format = "C0";
            dgvHistorialR10.Columns["PrecioTotal"].DefaultCellStyle.Format = "C0";
            dgvHistorialR10.Columns["PesoInicial"].DefaultCellStyle.Format = "N0";
            dgvHistorialR10.Columns["PesoRecibido"].DefaultCellStyle.Format = "N0";
            dgvHistorialR10.Columns["Consumo"].DefaultCellStyle.Format = "N0";
        }

        private void ActualizarTransaccionesGridR134()
        {
            dataGridViewR134.AllowUserToAddRows = false;

            var transaccionesDevueltas = transacciones
                .Where(t => t.estado == "devuelto" && t.Cilindro.Tipo == "R134")
                .OrderBy(t => t.FechaRecibido)
                .ThenBy(t => t.Id)
                .Select(t => new TransaccionViewModel
                {
                    Id = t.Id,
                    Cliente = t.Cliente.Nombre,
                    Vendedor = t.Vendedor.Nombre,
                    VendedorRecibe = t.VendedorRecibe?.Nombre,
                    Cilindro = t.CilindroInfo,
                    FechaEntregado = t.Fecha,
                    FechaRecibido = t.FechaRecibido,
                    PesoInicial = t.PesoFinal + t.Consumo,
                    PesoRecibido = t.PesoFinal,
                    PrecioPorGramo = Math.Round(t.Cilindro.PrecioPorGramo, 2),
                    PrecioTotal = Math.Round(t.Total, 2),
                    Consumo = t.Consumo
                })
                .ToList();

            dataGridViewR134.DataSource = new BindingList<TransaccionViewModel>(transaccionesDevueltas);

            dataGridViewR134.Columns["PrecioPorGramo"].DefaultCellStyle.Format = "C0";
            dataGridViewR134.Columns["PrecioTotal"].DefaultCellStyle.Format = "C0";
            dataGridViewR134.Columns["PesoInicial"].DefaultCellStyle.Format = "N0";
            dataGridViewR134.Columns["PesoRecibido"].DefaultCellStyle.Format = "N0";
            dataGridViewR134.Columns["Consumo"].DefaultCellStyle.Format = "N0";
        }

        private void ActualizarResumenes()
        {
            ActualizarResumenR22();
            ActualizarResumenR410();
            ActualizarResumenR134();
        }

        private void ActualizarResumenR22()
        {
            var transaccionesR22 = transacciones
                .Where(t => t.estado == "devuelto" && t.Cilindro.Tipo == "R22")
                .ToList();



            double totalConsumo = transaccionesR22.Sum(t => t.Consumo);
            double totalIngresos = transaccionesR22.Sum(t => t.Total);
            int totalTransacciones = transaccionesR22.Count;
            double promedioConsumo = totalTransacciones > 0 ? totalConsumo / totalTransacciones : 0;

            lblR22TotalConsumo.Text = $"Consumo Total: {totalConsumo:N0}g";
            lblR22TotalIngresos.Text = $"Ingresos Totales: {totalIngresos:C0}";
            lblR22Transacciones.Text = $"Transacciones: {totalTransacciones}";
            lblR22PromedioConsumo.Text = $"Consumo Promedio: {promedioConsumo:N0}g";
        }

        private void ActualizarResumenR410()
        {
            var transaccionesR410 = transacciones
                .Where(t => t.estado == "devuelto" && t.Cilindro.Tipo == "R410")
                .ToList();

            double totalConsumo = transaccionesR410.Sum(t => t.Consumo);
            double totalIngresos = transaccionesR410.Sum(t => t.Total);
            int totalTransacciones = transaccionesR410.Count;
            double promedioConsumo = totalTransacciones > 0 ? totalConsumo / totalTransacciones : 0;

            lblR410TotalConsumo.Text = $"Consumo Total: {totalConsumo:N0}g";
            lblR410TotalIngresos.Text = $"Ingresos Totales: {totalIngresos:C0}";
            lblR410Transacciones.Text = $"Transacciones: {totalTransacciones}";
            lblR410PromedioConsumo.Text = $"Consumo Promedio: {promedioConsumo:N0}g";
        }

        private void ActualizarResumenR134()
        {
            var transaccionesR134 = transacciones
                .Where(t => t.estado == "devuelto" && t.Cilindro.Tipo == "R134")
                .ToList();

            double totalConsumo = transaccionesR134.Sum(t => t.Consumo);
            double totalIngresos = transaccionesR134.Sum(t => t.Total);
            int totalTransacciones = transaccionesR134.Count;
            double promedioConsumo = totalTransacciones > 0 ? totalConsumo / totalTransacciones : 0;

            lblR134TotalConsumo.Text = $"Consumo Total: {totalConsumo:N0}g";
            lblR134TotalIngresos.Text = $"Ingresos Totales: {totalIngresos:C0}";
            lblR134Transacciones.Text = $"Transacciones: {totalTransacciones}";
            lblR134PromedioConsumo.Text = $"Consumo Promedio: {promedioConsumo:N0}g";
        }

        private void GuardarDatos<T>(string rutaArchivo, List<T> datos)
        {
            var json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, json);
        }

        private List<T> CargarDatos<T>(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                Console.WriteLine("La ruta del archivo no puede ser nula, vacía o contener solo espacios.");
                return new List<T>();
            }

            try
            {
                if (File.Exists(rutaArchivo))
                {
                    var json = File.ReadAllText(rutaArchivo);
                    var datos = JsonSerializer.Deserialize<List<T>>(json);
                    return datos ?? new List<T>();
                }
                else
                {
                    return new List<T>();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
                return new List<T>();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return new List<T>();
            }
        }

        private void dgvCilindros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que no sea el encabezado de la columna
            {
                var transaccion = (TransaccionViewModel)dgvHistorialR22.Rows[e.RowIndex].DataBoundItem;
                MessageBox.Show($"Se hizo clic en la transacción con ID: {transaccion.Id}");
            }
        }

        private void reporteCilindro_Click(object sender, EventArgs e)
        {
            Form3 form2 = new Form3();
            form2.Show();
        }
    }
}