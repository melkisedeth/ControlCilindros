using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ControlCilindros
{
    public partial class Admin : MaterialForm
    {
        private const string RutaClientes = "clientes.txt";
        private const string RutaVendedores = "vendedores.txt";
        private const string RutaCilindros = "cilindros.txt";
        private const string ContraseñaAdmin = "123";
        private int intentosLogin = 0;
        private const int MaxIntentosLogin = 3;
        private bool sesionActiva = false;
        private List<Cliente> clientes = new List<Cliente>();
        private List<Vendedor> vendedores = new List<Vendedor>();
        private List<Cilindro> cilindros = new List<Cilindro>();
        private readonly Form1 _form1;

        public Admin(Form1 form1)
        {
            InitializeComponent();
            ConfigurarMaterialSkin();
            CargarDatosIniciales();
            ConfigurarControles();
            _form1 = form1;

            // SOLUCIÓN DE SEGURIDAD: Deshabilitar todas las pestañas excepto login
            foreach (TabPage page in tabControl1.TabPages)
            {
                if (page != tabLogin)
                {
                    page.Enabled = false;
                }
            }
        }

        private void ConfigurarMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE);
        }

        private void CargarDatosIniciales()
        {
            clientes = CargarDatos<Cliente>(RutaClientes);
            vendedores = CargarDatos<Vendedor>(RutaVendedores);
            cilindros = CargarDatos<Cilindro>(RutaCilindros);
        }

        private void ConfigurarControles()
        {
            comboBoxTipo.Items.AddRange(new[] { "R22", "R410", "R134" });
            comboBoxTipo.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxTipo.DrawItem += ComboBoxTipo_DrawItem;
            comboBoxTipo.SelectedIndexChanged += comboBoxTipo_SelectedIndexChanged;

            ConfigurarGridClientes();
            ConfigurarGridCilindros();
            ConfigurarGridVendedores();
            ConfigurarToolTips();
            ActualizarGridClientes();
            ActualizarGridCilindros();
            ActualizarGridVendedores();
        }

        private void ConfigurarToolTips()
        {
            var toolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 500,
                ReshowDelay = 500,
                ShowAlways = true
            };

            toolTip.SetToolTip(txtNumeroCilindro, "Ingrese el número único del cilindro (ej: CIL-001)");
            toolTip.SetToolTip(txtPesoInicial, "Ingrese el peso en gramos (ej: 5000)");
            toolTip.SetToolTip(txtPrecioGramo222, "Precio por gramo (sugerido según tipo)");
            toolTip.SetToolTip(comboBoxTipo, "Seleccione el tipo de gas del cilindro");
            toolTip.SetToolTip(btnAddCilindro, "Agregar nuevo cilindro al inventario");
            toolTip.SetToolTip(btnDeleteCilindro, "Eliminar cilindro seleccionado (solo si no está prestado)");
            toolTip.SetToolTip(btnToggleDisponibilidad, "Cambiar estado de disponibilidad del cilindro");
        }

        private void btnAddCilindro_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNumeroCilindro.Text) ||
                string.IsNullOrWhiteSpace(txtPesoInicial.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioGramo222.Text) ||
                comboBoxTipo.SelectedItem == null)
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de formato del número de cilindro
            if (!Regex.IsMatch(txtNumeroCilindro.Text.Trim(), @"^[A-Za-z0-9\-]+$"))
            {
                MessageBox.Show("El número de cilindro solo puede contener letras, números y guiones", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string numeroCilindro = txtNumeroCilindro.Text.Trim();

            // Validación de duplicados
            if (cilindros.Any(c => c.NumeroCilindro.Equals(numeroCilindro, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un cilindro con este número", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de peso
            if (!double.TryParse(txtPesoInicial.Text, out double pesoInicial) || pesoInicial <= 0)
            {
                MessageBox.Show("Ingrese un peso válido mayor a cero", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de precio
            if (!double.TryParse(txtPrecioGramo222.Text, out double precioGramo) || precioGramo <= 0)
            {
                MessageBox.Show("Ingrese un precio por gramo válido mayor a cero", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmación antes de agregar
            if (MessageBox.Show($"¿Agregar cilindro {numeroCilindro} ({comboBoxTipo.SelectedItem}) con {pesoInicial}g a ${precioGramo}/g?",
                               "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            cilindros.Add(new Cilindro
            {
                Id = cilindros.Any() ? cilindros.Max(c => c.Id) + 1 : 1,
                NumeroCilindro = numeroCilindro,
                Tipo = comboBoxTipo.SelectedItem.ToString(),
                PesoInicial = pesoInicial,
                PrecioPorGramo = precioGramo,
                Estado = "Disponible"
            });

            GuardarDatos(RutaCilindros, cilindros);
            ActualizarGridCilindros();
            LimpiarCamposCilindro();
            MessageBox.Show("Cilindro agregado exitosamente", "Éxito",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool EstaPrestado(int idCilindro)
        {
            const string RutaTransacciones = "transacciones.txt";
            var transacciones = CargarDatos<Transaccion>(RutaTransacciones);

            return transacciones.Any(t =>
                t.Cilindro?.Id == idCilindro &&
                t.estado == "prestado");
        }

        private void DgvCilindros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var cilindro = dgvCilindros.Rows[e.RowIndex].DataBoundItem as Cilindro;
            if (cilindro == null) return;

            bool estaPrestado = EstaPrestado(cilindro.Id);

            if (estaPrestado)
            {
                e.CellStyle.BackColor = Color.LightGray;
                e.CellStyle.ForeColor = Color.DarkGray;
                e.CellStyle.Font = new Font(dgvCilindros.Font, FontStyle.Italic);
            }
            else
            {
                if (dgvCilindros.Columns[e.ColumnIndex].Name == "Tipo")
                {
                    switch (cilindro.Tipo)
                    {
                        case "R22":
                            e.CellStyle.BackColor = Color.LightGreen;
                            break;
                        case "R410":
                            e.CellStyle.BackColor = Color.LightPink;
                            break;
                        case "R134":
                            e.CellStyle.BackColor = Color.LightBlue;
                            break;
                    }
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void dgvCilindros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCilindros.SelectedRows.Count > 0)
            {
                var cilindro = (Cilindro)dgvCilindros.SelectedRows[0].DataBoundItem;
                bool estaPrestado = EstaPrestado(cilindro.Id);

                btnToggleDisponibilidad.Enabled = !estaPrestado;
                btnDeleteCilindro.Enabled = !estaPrestado;

                if (estaPrestado)
                {
                    btnToggleDisponibilidad.Text = "PRESTADO";
                }
                else
                {
                    btnToggleDisponibilidad.Text = cilindro.Estado == "Disponible" ?
                        "MARCAR COMO NO DISPONIBLE" : "MARCAR COMO DISPONIBLE";
                }
            }
        }

        private void btnToggleDisponibilidad_Click(object sender, EventArgs e)
        {
            if (dgvCilindros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cilindro", "Advertencia",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cilindroSeleccionado = (Cilindro)dgvCilindros.SelectedRows[0].DataBoundItem;

            if (EstaPrestado(cilindroSeleccionado.Id))
            {
                MessageBox.Show("No se puede cambiar el estado de un cilindro prestado.\n" +
                              "Debe ser devuelto primero en la pantalla principal.",
                              "Operación no permitida",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cilindroSeleccionado.Estado = cilindroSeleccionado.Estado == "Disponible" ? "NoDisponible" : "Disponible";

            GuardarDatos(RutaCilindros, cilindros);
            dgvCilindros.Refresh();
            _form1.Form1_Load_1(sender, e);
        }

        private void btnDeleteCilindro_Click(object sender, EventArgs e)
        {
            if (dgvCilindros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cilindro", "Advertencia",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cilindro = (Cilindro)dgvCilindros.SelectedRows[0].DataBoundItem;

            // Verificar si el cilindro está prestado
            if (EstaPrestado(cilindro.Id))
            {
                MessageBox.Show("No se puede eliminar un cilindro prestado.\n" +
                              "Debe ser devuelto primero en la pantalla principal.",
                              "Operación no permitida",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar transacciones históricas
            if (TieneTransaccionesHistoricas(cilindro.Id))
            {
                MessageBox.Show("Este cilindro tiene transacciones históricas.\n" +
                              "Se recomienda marcarlo como no disponible en lugar de eliminarlo.",
                              "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación detallada
            if (MessageBox.Show($"¿Está seguro que desea ELIMINAR PERMANENTEMENTE el cilindro {cilindro.NumeroCilindro} ({cilindro.Tipo})?\n\n" +
                              $"Esta acción no se puede deshacer.",
                              "Confirmar Eliminación",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cilindros.Remove(cilindro);
                GuardarDatos(RutaCilindros, cilindros);
                ActualizarGridCilindros();
                MessageBox.Show("Cilindro eliminado exitosamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool TieneTransaccionesHistoricas(int idCilindro)
        {
            const string RutaTransacciones = "transacciones.txt";
            var transacciones = CargarDatos<Transaccion>(RutaTransacciones);
            return transacciones.Any(t => t.Cilindro?.Id == idCilindro);
        }

        private void ComboBoxTipo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var comboBox = sender as ComboBox;
            string tipo = comboBox.Items[e.Index].ToString();

            Color backgroundColor = Color.White;
            Color textColor = Color.Black;

            switch (tipo)
            {
                case "R22":
                    backgroundColor = Color.LightGreen;
                    break;
                case "R410":
                    backgroundColor = Color.LightPink;
                    break;
                case "R134":
                    backgroundColor = Color.LightBlue;
                    break;
            }

            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);
            TextRenderer.DrawText(e.Graphics, tipo, e.Font, e.Bounds, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.DrawFocusRectangle();
            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedItem != null)
            {
                string tipo = comboBoxTipo.SelectedItem.ToString();
                double precioSugerido = tipo == "R22" ? 65 : tipo == "R410" ? 55 : 45;
                txtPrecioGramo222.Text = precioSugerido.ToString();
            }
        }

        private void ConfigurarGridClientes()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configura las columnas como editables
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                ReadOnly = true // El ID no debe ser editable
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 200,
                ReadOnly = false // Permitir edición
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefono",
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                ReadOnly = false // Permitir edición
            });

            // Agregar evento para guardar los cambios 
            dgvClientes.CellEndEdit += DgvClientes_CellEndEdit;
        }

        private void DgvClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var clienteEditado = dgvClientes.Rows[e.RowIndex].DataBoundItem as Cliente;
            if (clienteEditado == null) return;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(clienteEditado.Nombre))
            {
                MessageBox.Show("El nombre no puede estar vacío", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClientes.CancelEdit();
                return;
            }

            // Verificar si ya existe un cliente con el mismo nombre (excepto el mismo cliente)
            if (clientes.Any(c => c.Nombre.Equals(clienteEditado.Nombre, StringComparison.OrdinalIgnoreCase) &&
                                 c.Id != clienteEditado.Id))
            {
                MessageBox.Show("Ya existe un cliente con este nombre", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClientes.CancelEdit();
                return;
            }

            // Guardar los cambios
            GuardarDatos(RutaClientes, clientes);
        }

        private void ConfigurarGridCilindros()
        {
            dgvCilindros.AutoGenerateColumns = false;
            dgvCilindros.AllowUserToAddRows = false;
            dgvCilindros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCilindros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NumeroCilindro",
                DataPropertyName = "NumeroCilindro",
                HeaderText = "Número",
                ReadOnly = true
            });

            dgvCilindros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tipo",
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                ReadOnly = true
            });

            dgvCilindros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PesoInicial",
                DataPropertyName = "PesoInicial",
                HeaderText = "Peso (gr)",
                ReadOnly = true
            });

            dgvCilindros.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecioPorGramo",
                DataPropertyName = "PrecioPorGramo",
                HeaderText = "Precio/gr",
                ReadOnly = false
            });

            dgvCilindros.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Disponible",
                DataPropertyName = "Disponible",
                HeaderText = "Disponible",
                ReadOnly = true
            });

            dgvCilindros.CellFormatting += DgvCilindros_CellFormatting;
            dgvCilindros.CellEndEdit += dgvCilindros_CellEndEdit;

            dgvCilindros.CellBeginEdit += (sender, e) =>
            {
                var column = dgvCilindros.Columns[e.ColumnIndex];
                if (column.Name != "PrecioPorGramo")
                {
                    e.Cancel = true;
                }
            };
        }

        private void dgvCilindros_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var column = dgvCilindros.Columns[e.ColumnIndex];
            if (column.Name == "PrecioPorGramo")
            {
                var cilindro = dgvCilindros.Rows[e.RowIndex].DataBoundItem as Cilindro;
                if (cilindro == null) return;

                var newValue = dgvCilindros.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Validación de precio
                if (newValue == null || !double.TryParse(newValue.ToString(), out double nuevoPrecio) ||
                    nuevoPrecio <= 0 || nuevoPrecio > 1000) // Precio máximo de $1000/gr
                {
                    MessageBox.Show("Ingrese un precio válido entre 0.01 y 1000", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvCilindros.CancelEdit();
                    return;
                }

                // Confirmación de cambio
                if (MessageBox.Show($"¿Cambiar precio de {cilindro.PrecioPorGramo:C2}/gr a {nuevoPrecio:C2}/gr?",
                                  "Confirmar Cambio",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cilindro.PrecioPorGramo = nuevoPrecio;
                    GuardarDatos(RutaCilindros, cilindros);
                }
                else
                {
                    dgvCilindros.CancelEdit();
                }
            }
        }

        private void ActualizarGridClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = new BindingList<Cliente>(clientes.OrderBy(c => c.Nombre).ToList());
        }

        private void ActualizarGridCilindros()
        {
            var listaActual = new BindingList<Cilindro>(
                cilindros
                    .OrderBy(c => c.Tipo)
                    .ThenBy(c => int.TryParse(c.NumeroCilindro, out int num) ? num : int.MaxValue)
                    .ToList()
            );
            dgvCilindros.DataSource = null;
            dgvCilindros.DataSource = listaActual;
        }

        private List<T> CargarDatos<T>(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                var json = File.ReadAllText(rutaArchivo);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                    }
                    catch (JsonException)
                    {
                        return new List<T>();
                    }
                }
            }
            return new List<T>();
        }

        private void GuardarDatos<T>(string rutaArchivo, List<T> datos)
        {
            var json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, json);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese la contraseña", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Limitar intentos
            if (intentosLogin >= 3)
            {
                MessageBox.Show("Demasiados intentos fallidos. La aplicación se cerrará.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            if (txtPassword.Text == ContraseñaAdmin)
            {
                foreach (TabPage page in tabControl1.TabPages)
                {
                    page.Enabled = true;
                }

                tabControl1.SelectedTab = tabMain;
                txtPassword.Clear();
                intentosLogin = 0;

                // Registrar acceso
                RegistrarAcceso("Login exitoso");
            }
            else
            {
                intentosLogin++;
                MessageBox.Show($"Contraseña incorrecta. Intentos restantes: {3 - intentosLogin}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }

        private void RegistrarAcceso(string mensaje)
        {
            try
            {
                string logPath = "accesos.log";
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {mensaje}\n";
                File.AppendAllText(logPath, logEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar acceso: {ex.Message}");
            }
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre del cliente", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de teléfono
            if (string.IsNullOrWhiteSpace(txtTelefonoCliente.Text) ||
                !Regex.IsMatch(txtTelefonoCliente.Text, @"^[0-9\-\+\(\)\s]+$"))
            {
                MessageBox.Show("Ingrese un número de teléfono válido", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreCliente = txtNombreCliente.Text.Trim();

            // Validación de duplicados
            if (clientes.Any(c => c.Nombre.Equals(nombreCliente, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un cliente con este nombre", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmación antes de agregar
            if (MessageBox.Show($"¿Agregar cliente {nombreCliente} con teléfono {txtTelefonoCliente.Text.Trim()}?",
                               "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            clientes.Add(new Cliente
            {
                Id = clientes.Any() ? clientes.Max(c => c.Id) + 1 : 1,
                Nombre = nombreCliente,
                Telefono = txtTelefonoCliente.Text.Trim()
            });

            GuardarDatos(RutaClientes, clientes);
            ActualizarGridClientes();
            LimpiarCamposCliente();
            MessageBox.Show("Cliente agregado exitosamente", "Éxito",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            _form1.Form1_Load_1(sender, e);
        }

        private void btnDeleteCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"¿Eliminar cliente {cliente.Nombre}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clientes.Remove(cliente);
                GuardarDatos(RutaClientes, clientes);
                ActualizarGridClientes();
                _form1.Form1_Load_1(sender, e);

            }
        }

        private void LimpiarCamposCliente()
        {
            txtNombreCliente.Clear();
            txtTelefonoCliente.Clear();
        }

        private void LimpiarCamposCilindro()
        {
            txtNumeroCilindro.Clear();
            txtPesoInicial.Clear();
            txtPrecioGramo222.Clear();
            comboBoxTipo.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabLogin;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir del administrador?",
                               "Confirmar Salida",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // Evitar que el usuario regrese al login sin confirmación
            if (e.TabPage == tabLogin && tabControl1.SelectedTab != tabLogin)
            {
                if (MessageBox.Show("¿Desea cerrar la sesión administrativa?",
                                   "Confirmar",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    // Deshabilitar todas las pestañas excepto login
                    foreach (TabPage page in tabControl1.TabPages)
                    {
                        if (page != tabLogin)
                        {
                            page.Enabled = false;
                        }
                    }
                    txtPassword.Focus();
                }
            }
        }

        

        private void LimpiarCamposVendedor()
        {
            txtNombreVendedor.Clear();
        }
        private bool EstaAsociadoATransaccionPrestada(int idVendedor)
        {
            const string RutaTransacciones = "transacciones.txt";

            // Si no existe el archivo, no hay transacciones
            if (!File.Exists(RutaTransacciones))
            {
                return false;
            }

            try
            {
                // Cargar transacciones
                var json = File.ReadAllText(RutaTransacciones);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return false;
                }

                var transacciones = JsonSerializer.Deserialize<List<Transaccion>>(json) ?? new List<Transaccion>();

                // Verificar solo transacciones con estado "prestado"
                return transacciones.Any(t =>
                    t.estado == "prestado" && // Solo considerar transacciones prestadas
                    (t.Vendedor != null && t.Vendedor.Id == idVendedor ||
                     t.VendedorRecibe != null && t.VendedorRecibe.Id == idVendedor));
            }
            catch (Exception ex)
            {
                // En caso de error, asumir que no está asociado para no bloquear la operación
                Console.WriteLine($"Error al verificar transacciones: {ex.Message}");
                return false;
            }
        }
        private void btnDeleteVendedor_Click(object sender, EventArgs e)
        {
            if (dgvVendedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un vendedor", "Advertencia",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var vendedor = (Vendedor)dgvVendedores.SelectedRows[0].DataBoundItem;

            // Verificar si el vendedor está asociado a alguna transacción
            if (EstaAsociadoATransaccionPrestada(vendedor.Id))
            {
                MessageBox.Show("No se puede eliminar este vendedor porque está asociado a transacciones existentes.",
                               "Operación no permitida",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Eliminar vendedor {vendedor.Nombre}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                vendedores.Remove(vendedor);
                GuardarDatos(RutaVendedores, vendedores);
                ActualizarGridVendedores();
                _form1.Form1_Load_1(sender, e);

            }
        }
        private void btnAddVendedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreVendedor.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre del vendedor", "Advertencia",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreVendedor = txtNombreVendedor.Text.Trim();

            if (vendedores.Any(v => v.Nombre.Equals(nombreVendedor, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un vendedor con este nombre", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vendedores.Add(new Vendedor
            {
                Id = vendedores.Any() ? vendedores.Max(v => v.Id) + 1 : 1,
                Nombre = nombreVendedor
            });

            GuardarDatos(RutaVendedores, vendedores);
            ActualizarGridVendedores();
            LimpiarCamposVendedor();
            _form1.Form1_Load_1(sender, e);

        }

        private void ActualizarGridVendedores()
        {
            dgvVendedores.DataSource = null;
            dgvVendedores.DataSource = new BindingList<Vendedor>(vendedores.OrderBy(v => v.Nombre).ToList());
        }

        private void ConfigurarGridVendedores()
        {
            dgvVendedores.AutoGenerateColumns = false;
            dgvVendedores.AllowUserToAddRows = false;
            dgvVendedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvVendedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                ReadOnly = true
            });

            dgvVendedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                ReadOnly = false
            });
        }


        private void dgvVendedores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var column = dgvVendedores.Columns[e.ColumnIndex];
            if (column.Name == "Nombre")
            {
                var vendedor = dgvVendedores.Rows[e.RowIndex].DataBoundItem as Vendedor;
                if (vendedor == null) return;

                var newValue = dgvVendedores.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Validación de nombre vacío
                if (newValue == null || string.IsNullOrWhiteSpace(newValue.ToString()))
                {
                    MessageBox.Show("El nombre no puede estar vacío", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvVendedores.CancelEdit();
                    return;
                }

                string nuevoNombre = newValue.ToString().Trim();

                // Validación de duplicados
                if (vendedores.Any(v => v.Id != vendedor.Id &&
                                       v.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ya existe un vendedor con este nombre", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvVendedores.CancelEdit();
                    return;
                }

                // Confirmación de cambio
                if (MessageBox.Show($"¿Cambiar nombre de '{vendedor.Nombre}' a '{nuevoNombre}'?",
                                  "Confirmar Cambio",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    vendedor.Nombre = nuevoNombre;
                    GuardarDatos(RutaVendedores, vendedores);
                    _form1.Form1_Load_1(sender, e);
                }
                else
                {
                    dgvVendedores.CancelEdit();
                }
            }
        }
    }
}