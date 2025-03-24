using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlCilindros
{
    public partial class Form3 : Form
    {

        private const string RutaTransacciones = "transacciones.txt";

        private List<Transaccion> transacciones = new List<Transaccion>();

        public Form3()
        {
            InitializeComponent();
        }

        private void dgvHistorialR10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            transacciones = CargarDatos<Transaccion>(RutaTransacciones);
            MostrarReporteEnDataGridView();
        }

        private void LimpiarDataGridView()
        {
            dgvHistorialR10.DataSource = null;
            dgvHistorialR10.Rows.Clear();
        }

        private List<ResumenCilindro> GenerarResumenCilindros()
        {
            var resumenCilindros = new List<ResumenCilindro>();

            var transaccionesPorCilindro = transacciones
                .Where(t => t.estado == "devuelto")
                .GroupBy(t => t.Cilindro.Id);

            foreach (var grupo in transaccionesPorCilindro)
            {
                var cilindro = grupo.First().Cilindro;
                var totalGramosGastados = grupo.Sum(t => t.Consumo);
                var totalVendido = grupo.Sum(t => t.Total);
                var vecesPrestado = grupo.Count();
                var ganancia = totalVendido - (cilindro.PesoInicial - totalGramosGastados) * cilindro.PrecioPorGramo;

                resumenCilindros.Add(new ResumenCilindro
                {
                    Id = cilindro.Id,
                    NumeroCilindro = cilindro.NumeroCilindro,
                    TipoCilindro = cilindro.Tipo,
                    TotalGramosGastados = totalGramosGastados,
                    TotalVendido = totalVendido,
                    VecesPrestado = vecesPrestado,
                    Ganancia = ganancia
                });
            }

            return resumenCilindros;
        }

        private void MostrarReporteEnDataGridView()
        {
            LimpiarDataGridView();
            var resumenCilindros = GenerarResumenCilindros();
            dgvHistorialR10.DataSource = resumenCilindros;
            ConfigurarColumnasDataGridView();
        }

        private void ConfigurarColumnasDataGridView()
        {
            dgvHistorialR10.AutoGenerateColumns = false;
            dgvHistorialR10.Columns.Clear();

            dgvHistorialR10.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId"
            });

            dgvHistorialR10.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NumeroCilindro",
                HeaderText = "Número de Cilindro",
                Name = "colNumeroCilindro"
            });

            dgvHistorialR10.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TipoCilindro",
                HeaderText = "Tipo de Cilindro",
                Name = "colTipoCilindro"
            });

            dgvHistorialR10.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalGramosGastados",
                HeaderText = "Gramos Gastados",
                Name = "colGramosGastados"
            });

            dgvHistorialR10.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalVendido",
                HeaderText = "Total Vendido",
                Name = "colTotalVendido"
            });

            dgvHistorialR10.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VecesPrestado",
                HeaderText = "Veces Prestado",
                Name = "colVecesPrestado"
            });

            dgvHistorialR10.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Ganancia",
                HeaderText = "Ganancia",
                Name = "colGanancia"
            });
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
    }
}
