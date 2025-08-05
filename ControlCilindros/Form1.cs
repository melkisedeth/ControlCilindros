using MaterialSkin;
using MaterialSkin.Controls;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Text.Json;
using System.Windows.Forms;

namespace ControlCilindros
{
    public partial class Form1 : MaterialForm
    {
        private System.Windows.Forms.Timer backgroundTimer;
        private readonly MaterialSkinManager materialSkinManager;
        private const string RutaClientes = "clientes.txt";
        private const string RutaVendedores = "vendedores.txt";
        private const string RutaCilindros = "cilindros.txt";
        private const string RutaTransacciones = "transacciones.txt";

        private List<Cliente> clientes = new List<Cliente>();
        private List<Vendedor> vendedores = new List<Vendedor>();
        private List<Cilindro> cilindros = new List<Cilindro>();
        private List<Transaccion> transacciones = new List<Transaccion>();

        public Form1()
        {

            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);

            backgroundTimer = new System.Windows.Forms.Timer();
            backgroundTimer.Interval = 3 * 60 * 1000;
            backgroundTimer.Tick += new EventHandler(BackgroundTimer_Tick);

            backgroundTimer.Start();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

        }

        private void BackgroundTimer_Tick(object sender, EventArgs e)
        {
            Form1_Load_1(sender, e);
        }


        private void btnRegistrarCliente_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) || string.IsNullOrWhiteSpace(txtTelefonoCliente.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            clientes.Add(new Cliente
            {
                Id = clientes.Count + 1,
                Nombre = txtNombreCliente.Text,
                Telefono = txtTelefonoCliente.Text
            });

            GuardarDatos(RutaClientes, clientes);
            ActualizarClientesGrid();
            ActualizarComboboxClientes();
            LimpiarCamposClientes();
            LimpiarCamposGramos();
        }

        private void ActualizarClientesGrid()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes.Select(c => new
            {
                c.Id,
                c.Nombre,
                c.Telefono
            }).ToList();
        }

        private void LimpiarCamposClientes()
        {
            txtNombreCliente.Clear();
            txtTelefonoCliente.Clear();
        }

        private void LimpiarCamposGramos()
        {
            txtPesoFinal.Clear();
            textPesoRegreso.Clear();
        }

        //private void btnRegistrarVendedor_Click_2(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtNombreVendedor.Text))
        //    {
        //        MessageBox.Show("Por favor, ingrese el nombre del vendedor.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //        return;
        //    }

        //    vendedores.Add(new Vendedor
        //    {
        //        Id = vendedores.Count + 1,
        //        Nombre = txtNombreVendedor.Text
        //    });

        //    GuardarDatos(RutaVendedores, vendedores);
        //    ActualizarVendedoresGrid();
        //    ActualizarComboboxVendedores();
        //    ActualizarComboboxVendedorRecibe();
        //    LimpiarCamposVendedores();
        //}

        //private void ActualizarVendedoresGrid()
        //{
        //    dgvVendedores.DataSource = null;
        //    dgvVendedores.DataSource = vendedores.Select(v => new
        //    {
        //        v.Id,
        //        v.Nombre
        //    }).ToList();
        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

        //private void LimpiarCamposVendedores()
        //{
        //    txtNombreVendedor.Clear();
        //}

        //private void btnRegistrarCilindro_Click(object sender, EventArgs e)
        //{

        //    if (string.IsNullOrWhiteSpace(txtNumeroCilindro.Text) ||
        //          string.IsNullOrWhiteSpace(txtPesoInicialCilindro.Text) ||
        //          comboBoxTipo.SelectedItem == null)
        //    {
        //        MessageBox.Show("Por favor, complete todos los campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //        return;
        //    }

        //    double pesoInicial;
        //    if (!double.TryParse(txtPesoInicialCilindro.Text, out pesoInicial) || pesoInicial <= 0)
        //    {
        //        MessageBox.Show("El peso inicial debe ser un número mayor que 0.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }


        //    var tipo = comboBoxTipo.SelectedItem.ToString();

        //    cilindros.Add(new Cilindro
        //    {
        //        Id = cilindros.Count + 1,
        //        NumeroCilindro = txtNumeroCilindro.Text,
        //        PesoInicial = double.Parse(txtPesoInicialCilindro.Text),
        //        PrecioPorGramo = tipo == "R22" ? 65 : tipo == "R410" ? 55 : 45,
        //        Tipo = comboBoxTipo.SelectedItem.ToString(),
        //    });

        //    GuardarDatos(RutaCilindros, cilindros);
        //    ActualizarCilindrosGrid();
        //    ActualizarComboboxCilindros();
        //    LimpiarCamposCilindros();
        //}

        //private void ActualizarCilindrosGrid()
        //{
        //    dgvCilindros.DataSource = null;
        //    dgvCilindros.DataSource = cilindros.Select(c => new
        //    {
        //        c.Id,
        //        c.NumeroCilindro,
        //        c.PesoInicial,
        //        c.PrecioPorGramo,
        //        c.Tipo
        //    }).ToList();

        //    dgvCilindros.CellFormatting -= dgvCilindros_CellFormatting; // Evita suscripciones múltiples
        //    dgvCilindros.CellFormatting += dgvCilindros_CellFormatting;
        //}

        //private void dgvCilindros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && dgvCilindros.Columns["Tipo"] != null)
        //    {
        //        string tipo = dgvCilindros.Rows[e.RowIndex].Cells["Tipo"].Value?.ToString();

        //        if (tipo == "R22")
        //        {
        //            dgvCilindros.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
        //            dgvCilindros.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        //        }
        //        else if (tipo == "R410")
        //        {
        //            dgvCilindros.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
        //            dgvCilindros.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        //        }
        //        else
        //        {
        //            dgvCilindros.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
        //            dgvCilindros.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        //        }
        //    }
        //}


        //private void ActualizarTipoCilindro()
        //{
        //    comboBoxTipo.DataSource = null;
        //    comboBoxTipo.Items.Clear();
        //    comboBoxTipo.Items.AddRange(new object[] { "R22", "R410", "R134" });

        //    comboBoxTipo.DrawMode = DrawMode.OwnerDrawFixed;
        //    comboBoxTipo.DrawItem += new DrawItemEventHandler(comboBoxTipo_DrawItem);
        //}

        //private void comboBoxTipo_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    if (e.Index < 0) return;

        //    string itemText = comboBoxTipo.Items[e.Index].ToString();

        //    Color backgroundColor = Color.White;
        //    Color textColor = Color.Black;

        //    if (itemText == "R22")
        //    {
        //        backgroundColor = Color.LightGreen;
        //        textColor = Color.Black;
        //    }
        //    else if (itemText == "R410")
        //    {
        //        backgroundColor = Color.LightPink;
        //        textColor = Color.Black;
        //    }
        //    else
        //    {
        //        backgroundColor = Color.LightBlue;
        //        textColor = Color.Black;
        //    }


        //    e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);


        //    TextRenderer.DrawText(
        //        e.Graphics,
        //        itemText,
        //        e.Font,
        //        e.Bounds,
        //        textColor,
        //        TextFormatFlags.VerticalCenter | TextFormatFlags.Left
        //    );

        //    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        //    {
        //        e.DrawFocusRectangle();
        //    }
        //}




        private void ActualizarCilindroRecibidoGrid(Transaccion transaccion)
        {
            gridCilindroRecibido.DataSource = null;

            var resumen = new[]
            {
        new
        {
            Id = transaccion.Id,
            Cliente = transaccion.Cliente?.Nombre,
            Vendedor = transaccion.Vendedor?.Nombre,
            Vendedor_recibe = transaccion.VendedorRecibe?.Nombre,
            Cilindro = transaccion.CilindroInfo,
            PesoInicial = transaccion.PesoFinal + transaccion.Consumo,
            PesoFinal = transaccion.PesoFinal,
            Consumo = transaccion.Consumo,
            Valor_gramo = $"${Math.Round(transaccion.Cilindro.PrecioPorGramo, 0):N0}",
            Total_pagar = $"${Math.Round(transaccion.Total, 0):N0}",
            Fecha_recibido = transaccion.FechaRecibido
        }
    };

            gridCilindroRecibido.DataSource = resumen;
        }



        //private void LimpiarCamposCilindros()
        //{
        //    txtNumeroCilindro.Clear();
        //    txtPesoInicialCilindro.Clear();
        //}

        //private void btnRegistrarTransaccion_Click(object sender, EventArgs e)
        //{
        //    var cliente = (Cliente)cbClientes.SelectedItem;
        //    var vendedor = (Vendedor)cbVendedores.SelectedItem;
        //    var cilindro = (Cilindro)cbCilindros.SelectedItem;
        //    var pesoFinal = double.Parse(txtPesoFinal.Text);

        //    if (pesoFinal >= cilindro.PesoInicial)
        //    {
        //        MessageBox.Show("El peso final no puede ser mayor o igual al peso inicial del cilindro.");
        //        return;
        //    }

        //    var consumo = cilindro.PesoInicial - pesoFinal;
        //    var total = consumo * cilindro.PrecioPorGramo;

        //    var transaccion = new Transaccion
        //    {
        //        Id = transacciones.Count + 1,
        //        Cliente = cliente,
        //        Vendedor = vendedor,
        //        Cilindro = cilindro,
        //        Fecha = DateTime.Now,
        //        PesoFinal = pesoFinal,
        //        Total = total,
        //        Consumo = consumo
        //    };

        //    cilindro.PesoInicial = pesoFinal;

        //    transacciones.Add(transaccion);

        //    GuardarDatos(RutaCilindros, cilindros);
        //    GuardarDatos(RutaTransacciones, transacciones);

        //    ActualizarCilindrosGrid();
        //    ActualizarTransaccionesGrid();
        //    Form1_Load_1(sender, e);

        //    MessageBox.Show($"Transacción registrada.\nConsumo: {consumo} gramos\nTotal a pagar: ${total:F2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //    txtPesoFinal.Clear();
        //}


        private void ActualizarTransaccionesGrid()
        {
            var transaccionesModificables = transacciones
                .Where(x => x.estado == "prestado")
                .Select(t => new TransaccionViewModelEntrega
                {
                    Id = t.Id,
                    Cliente = t.Cliente.Nombre,
                    Telefono = t.Cliente.Telefono,  
                    Vendedor = t.Vendedor.Nombre,
                    Cilindro = t.CilindroInfo,
                    FechaEntregado = t.Fecha,
                    PesoInicial = t.PesoFinal,
                    PrecioPorGramo = t.Cilindro.PrecioPorGramo,
                }).ToList();

            var bindingList = new BindingList<TransaccionViewModelEntrega>(transaccionesModificables);
            dgvTransacciones.DataSource = bindingList;

            dgvTransacciones.AllowUserToAddRows = false;
            dgvTransacciones.Columns["PesoInicial"].ReadOnly = true;

            dgvTransacciones.CellFormatting -= dgvTransacciones_CellFormatting;
            dgvTransacciones.CellFormatting += dgvTransacciones_CellFormatting;
        }

        private void dgvTransacciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTransacciones.Columns[e.ColumnIndex].Name == "PesoInicial")
            {
                int id = (int)dgvTransacciones.Rows[e.RowIndex].Cells["Id"].Value;
                double nuevoPesoInicial;

                if (double.TryParse(dgvTransacciones.Rows[e.RowIndex].Cells["PesoInicial"].Value?.ToString(), out nuevoPesoInicial))
                {
                    var transaccion = transacciones.FirstOrDefault(t => t.Id == id);
                    if (transaccion != null)
                    {
                        transaccion.PesoFinal = nuevoPesoInicial; // Actualizar dato original
                        GuardarDatos(RutaTransacciones, transacciones); // Guardar en archivo
                        MessageBox.Show("Peso Inicial actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un valor numérico válido para Peso Inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActualizarTransaccionesGrid();
                }
            }
        }

        private void dgvTransacciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvTransacciones.Columns[e.ColumnIndex].Name == "Cilindro")
                {
                    string cilindroInfo = e.Value?.ToString();

                    if (cilindroInfo?.Contains("R22") == true)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else if (cilindroInfo?.Contains("R410") == true)
                    {
                        e.CellStyle.BackColor = Color.LightPink;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.LightBlue;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }

                if (dgvTransacciones.Columns[e.ColumnIndex].Name == "Cliente" || dgvTransacciones.Columns[e.ColumnIndex].Name == "Id")
                {
                    DateTime fechaEntregado = (DateTime)dgvTransacciones.Rows[e.RowIndex].Cells["FechaEntregado"].Value;
                    if (DateTime.Now.Subtract(fechaEntregado).TotalHours > 24)
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }



        private void ActualizarComboboxClientes()
        {
            cbClientes.DataSource = null;

            clientes = clientes.OrderBy(c => c.Nombre).ToList();

            cbClientes.DataSource = clientes;
            cbClientes.DisplayMember = "Nombre";
            cbClientes.ValueMember = "Id";

            cbClientes.SelectedIndex = -1;
        }


        private void ActualizarComboboxOperaciones()
        {
            cbTransacciones.DataSource = null;
            cbTransacciones.DataSource = transacciones.Where(x => x.estado == "prestado").ToList();
            cbTransacciones.DisplayMember = "ClienteInfo";
            cbTransacciones.ValueMember = "Id";

            cbTransacciones.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTransacciones.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbTransacciones.SelectedIndex = -1;
        }

        private void ActualizarComboboxVendedores()
        {
            cbVendedores.DataSource = null;
            cbVendedores.DataSource = vendedores.ToList(); // Crear una copia de la lista
            cbVendedores.DisplayMember = "Nombre";
            cbVendedores.ValueMember = "Id";

            cbVendedores.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbVendedores.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbVendedores.SelectedIndex = -1;
        }

        private void ActualizarComboboxVendedorRecibe()
        {
            cbRecibe.DataSource = null;
            cbRecibe.DataSource = vendedores.ToList();
            cbRecibe.DisplayMember = "Nombre";
            cbRecibe.ValueMember = "Id";

            cbRecibe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbRecibe.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbRecibe.SelectedIndex = -1;
        }

        private void ActualizarEstadosCilindros()
        {
            var idsActivos = new List<string> { "30", "9", "7", "11", "20", "13", "12", "14", "16", "17", "19" };

            foreach (var cilindro in cilindros)
            {
                cilindro.Estado = idsActivos.Contains(cilindro.NumeroCilindro) ? "Disponible" : "NoDisponible";
            }

            GuardarDatos(RutaCilindros, cilindros);
        }

        private void ActualizarComboboxCilindros()
        {
            // Solo mostrar cilindros disponibles y no prestados
            var cilindrosDisponibles = cilindros
                .Where(c => c.Estado == "Disponible" &&
                       !transacciones.Any(t => t.estado == "prestado" && t.Cilindro?.Id == c.Id))
                .ToList();

            cbCilindros.DataSource = null;
            cbCilindros.DataSource = cilindrosDisponibles;
            cbCilindros.DisplayMember = "ClienteInfo";
            cbCilindros.ValueMember = "Id";

            cbCilindros.DrawMode = DrawMode.OwnerDrawFixed;
            cbCilindros.DrawItem += CbCilindros_DrawItem;
            cbCilindros.SelectedIndex = -1;
        }

        private void CbCilindros_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var comboBox = sender as ComboBox;
            var cilindro = comboBox.Items[e.Index] as Cilindro;

            Color backgroundColor = cilindro.Tipo == "R22" ? Color.LightGreen : cilindro.Tipo == "R410" ? Color.LightPink : Color.LightBlue;
            Color textColor = Color.Black;

            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

            TextRenderer.DrawText(e.Graphics, cilindro.ClienteInfo, e.Font, e.Bounds, textColor, TextFormatFlags.Left);

            e.DrawFocusRectangle();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarVendedor_Click_1(object sender, EventArgs e)
        {

        }



        public void Form1_Load_1(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Form1_Load_1(sender, e)));
                return;
            }


            clientes = CargarDatos<Cliente>(RutaClientes);
            vendedores = CargarDatos<Vendedor>(RutaVendedores);
            cilindros = CargarDatos<Cilindro>(RutaCilindros);
            transacciones = CargarDatos<Transaccion>(RutaTransacciones);
            dgvTransacciones.EditMode = DataGridViewEditMode.EditOnKeystroke;

            LimpiarCamposGramos();
            ActualizarClientesGrid();
            //ActualizarVendedoresGrid();
            //ActualizarCilindrosGrid();
            ActualizarTransaccionesGrid();

            ActualizarComboboxClientes();
            ActualizarComboboxVendedores();
            ActualizarComboboxVendedorRecibe();
            ActualizarComboboxOperaciones();
            //ActualizarTipoCilindro();
            //ActualizarEstadosCilindros();

            ActualizarComboboxCilindros();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundTimer.Stop();
        }

        private void btnRegistrarTransaccion_Click_Llevar(object sender, EventArgs e)
        {
            if (cbClientes.SelectedItem == null || cbVendedores.SelectedItem == null || cbCilindros.SelectedItem == null || txtPesoFinal.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = (Cliente)cbClientes.SelectedItem;
            var vendedor = (Vendedor)cbVendedores.SelectedItem;
            var cilindro = (Cilindro)cbCilindros.SelectedItem;
            var pesoFinal = double.Parse(txtPesoFinal.Text);

            string resumenTransaccion = $"Cliente: {cliente.Nombre}\n" +
                                        $"Vendedor: {vendedor.Nombre}\n" +
                                        $"Cilindro: {cilindro.NumeroCilindro} ({cilindro.Tipo})\n" +
                                        $"Peso: {pesoFinal:N0} gr\n" +
                                        "¿Está seguro de registrar esta transacción?";

            var confirmacion = MessageBox.Show(
                resumenTransaccion,
                "Confirmación de Transacción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.No)
            {
                return;
            }

            Random r = new Random();
            int n = r.Next(100, 1000);

            var transaccion = new Transaccion
            {
                Id = n,
                Cliente = cliente,
                Vendedor = vendedor,
                Cilindro = cilindro,
                Fecha = DateTime.Now,
                PesoFinal = pesoFinal,
                Total = 0,
                Consumo = 0,
                estado = "prestado"
            };

            transacciones.Add(transaccion);
            GuardarDatos(RutaTransacciones, transacciones);

            // Imprimir el ticket
            ImprimirTicket(transaccion);

            MessageBox.Show($"Transacción registrada exitosamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ActualizarTransaccionesGrid();
            ActualizarComboboxOperaciones();
            Form1_Load_1(sender, e);
        }

        private void btnRegistrarTransaccion_Click_RegistrarRegreso(object sender, EventArgs e)
        {
            if (cbRecibe.SelectedItem == null || string.IsNullOrWhiteSpace(textPesoRegreso.Text) || cbTransacciones.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var vendedor = (Vendedor)cbRecibe.SelectedItem;
            var pesoFinal = double.Parse(textPesoRegreso.Text);
            var transaccion = (Transaccion)cbTransacciones.SelectedItem;

            if (transaccion != null)
            {
                if (pesoFinal > transaccion.PesoFinal)
                {
                    MessageBox.Show("El peso final no puede ser mayor o igual al peso inicial del cilindro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var consumo = transaccion.PesoFinal - pesoFinal;
                var total = consumo * transaccion.Cilindro.PrecioPorGramo;

                transaccion.PesoFinal = pesoFinal;
                transaccion.Consumo = consumo;
                transaccion.Total = total;
                transaccion.estado = "devuelto";
                transaccion.VendedorRecibe = vendedor;
                transaccion.FechaRecibido = DateTime.Now;

                GuardarDatos(RutaCilindros, cilindros);
                GuardarDatos(RutaTransacciones, transacciones);

                MessageBox.Show($"Transacción completada. Consumo: {consumo} gramos. Total a pagar: ${total:F2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form mensajeForm = new Form
                {
                    WindowState = FormWindowState.Maximized, // Pantalla completa
                    BackColor = Color.Red, // Fondo rojo
                    FormBorderStyle = FormBorderStyle.None, // Sin bordes
                    StartPosition = FormStartPosition.CenterScreen
                };

                Label mensajeLabel = new Label
                {
                    Text = "¡¡¡RECUERDE FACTURAR EL GAS EN EL SISTEMA!!!",
                    Font = new Font("Arial", 48, FontStyle.Bold), // Fuente grande
                    ForeColor = Color.White, // Texto blanco
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                Button btnAceptar = new Button
                {
                    Text = "ACEPTAR",
                    Font = new Font("Arial", 24, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Dock = DockStyle.Bottom,
                    Height = 100
                };
                btnAceptar.Click += (s, ev) => mensajeForm.Close();

                mensajeForm.Controls.Add(mensajeLabel);
                mensajeForm.Controls.Add(btnAceptar);
                mensajeForm.ShowDialog();

                //ActualizarCilindrosGrid();
                //LimpiarCamposCilindros();
                ActualizarComboboxOperaciones();
                ActualizarTransaccionesGrid();
                ActualizarCilindroRecibidoGrid(transaccion);
                Form1_Load_1(sender, e);
            }
            else
            {
                MessageBox.Show("No se encontró la transacción para este cliente y cilindro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarResumenPago(Transaccion transaccion)
        {
            string mensaje = $"RESUMEN DE PAGO\n\n" +
                            $"Cliente: {transaccion.Cliente.Nombre}\n" +
                            $"Cilindro: {transaccion.CilindroInfo}\n" +
                            $"Peso inicial: {transaccion.PesoFinal + transaccion.Consumo:N0}g\n" +
                            $"Peso devuelto: {transaccion.PesoFinal:N0}g\n" +
                            $"Consumo: {transaccion.Consumo:N0}g\n" +
                            $"Precio por gramo: {transaccion.Cilindro.PrecioPorGramo:C2}\n" +
                            $"Total a pagar: {transaccion.Total:C2}\n" +
                            $"Monto recibido: {transaccion.MontoRecibido:C2}\n" +
                            $"Cambio: {transaccion.Cambio:C2}";

            MessageBox.Show(mensaje, "Resumen de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GenerarTicketDevolucion(Transaccion transaccion)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, e) =>
                {
                    Graphics graphics = e.Graphics;
                    Font font = new Font("Courier New", 10);
                    Font fontBold = new Font("Courier New", 12, FontStyle.Bold);
                    Font fontTitle = new Font("Courier New", 14, FontStyle.Bold);

                    float startX = 10;
                    float startY = 10;
                    float offset = 20;

                    // Encabezado
                    graphics.DrawString("CONTROL DE CILINDROS", fontTitle, Brushes.Black, startX, startY);
                    startY += offset + 10;
                    graphics.DrawString("RECIBO DE DEVOLUCIÓN", fontBold, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("--------------------------------", font, Brushes.Black, startX, startY);
                    startY += offset;

                    // Datos de la transacción
                    graphics.DrawString($"Fecha: {transaccion.FechaRecibido:g}", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString($"Cliente: {transaccion.Cliente.Nombre}", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString($"Vendedor: {transaccion.VendedorRecibe.Nombre}", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString($"Cilindro: {transaccion.CilindroInfo}", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("--------------------------------", font, Brushes.Black, startX, startY);
                    startY += offset;

                    // Detalles del consumo
                    graphics.DrawString($"Peso inicial: {transaccion.PesoFinal + transaccion.Consumo:N0}g", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString($"Peso devuelto: {transaccion.PesoFinal:N0}g", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString($"Consumo: {transaccion.Consumo:N0}g", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString($"Precio por gramo: {transaccion.Cilindro.PrecioPorGramo:C2}", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("--------------------------------", font, Brushes.Black, startX, startY);
                    startY += offset;

                    // Totales
                    graphics.DrawString($"TOTAL A PAGAR: {transaccion.Total:C2}", fontBold, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString($"MONTO RECIBIDO: {transaccion.MontoRecibido:C2}", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString($"CAMBIO: {transaccion.Cambio:C2}", font, Brushes.Black, startX, startY);
                    startY += offset + 10;
                    graphics.DrawString("--------------------------------", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("¡Gracias por su preferencia!", font, Brushes.Black, startX, startY);
                };

                // Mostrar diálogo de impresión
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = pd;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTransacciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            btnRegistrarTransaccion_Click_RegistrarRegreso(sender, e);
        }

        private void labelVendedor_Click(object sender, EventArgs e)
        {

        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void GuardarDatos<T>(string rutaArchivo, List<T> datos)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                throw new ArgumentException("La ruta del archivo no puede ser nula, vacía o contener solo espacios.", nameof(rutaArchivo));
            }

            if (datos == null)
            {
                throw new ArgumentNullException(nameof(datos), "La lista de datos no puede ser nula.");
            }

            try
            {
                var json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });

                var directorio = Path.GetDirectoryName(rutaArchivo);
                if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                File.WriteAllText(rutaArchivo, json);
            }
            catch (Exception ex)
            {
                throw new IOException($"Ocurrió un error al guardar los datos en el archivo '{rutaArchivo}'.", ex);
            }
        }


        private List<T> CargarDatos<T>(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                var json = File.ReadAllText(rutaArchivo);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<T>();

                }
                try
                {
                    return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                }
                catch (JsonException)
                {
                    return new List<T>();
                }
            }

            return new List<T>();
        }

        private void gridCilindroRecibido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridCilindroRecibido.Columns["PesoInicial"].Index)
            {
                var transaccionId = (int)gridCilindroRecibido.Rows[e.RowIndex].Cells["Id"].Value;

                var transaccion = transacciones.FirstOrDefault(t => t.Id == transaccionId);

                if (transaccion != null)
                {
                    if (double.TryParse(gridCilindroRecibido.Rows[e.RowIndex].Cells["PesoInicial"].Value?.ToString(), out double nuevoPesoInicial) && nuevoPesoInicial > 0)
                    {
                        double pesoFinal = transaccion.PesoFinal;

                        if (nuevoPesoInicial < pesoFinal)
                        {
                            MessageBox.Show("El Peso Inicial no puede ser menor que el Peso Final registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ActualizarCilindroRecibidoGrid(transaccion);
                            return;
                        }

                        transaccion.PesoFinal = nuevoPesoInicial - transaccion.Consumo;
                        transaccion.Cilindro.PesoInicial = nuevoPesoInicial;
                        transaccion.Total = transaccion.Consumo * transaccion.Cilindro.PrecioPorGramo;

                        GuardarDatos(RutaCilindros, cilindros);
                        GuardarDatos(RutaTransacciones, transacciones);

                        MessageBox.Show("Peso Inicial actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un valor numérico válido para el Peso Inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActualizarCilindroRecibidoGrid(transaccion);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la transacción asociada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarGridCilindroRecibido()
        {
            gridCilindroRecibido.CellEndEdit -= gridCilindroRecibido_CellEndEdit;
            gridCilindroRecibido.CellEndEdit += gridCilindroRecibido_CellEndEdit;

            // Habilitar edición en la columna "PesoInicial"
            gridCilindroRecibido.Columns["PesoInicial"].ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Load_1(sender, e);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ImprimirTicket(Transaccion transaccion)
        {
            try
            {
                // Crear el ticket
                var ticket = new Ticket
                {
                    Cliente = transaccion.Cliente.Nombre,
                    Vendedor = transaccion.Vendedor.Nombre,
                    Cilindro = transaccion.CilindroInfo,
                    NumeroCilindro = transaccion.Cilindro.NumeroCilindro,
                    Peso = transaccion.PesoFinal,
                    Fecha = transaccion.Fecha,
                    Tipo = transaccion.Cilindro.Tipo
                };

                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, e) =>
                {
                    Graphics graphics = e.Graphics;
                    Font font = new Font("Courier New", 10);
                    Font font2 = new Font("Courier New", 10);
                    Font fontBold = new Font("Courier New", 10, FontStyle.Bold);
                    Font fontTitle = new Font("Courier New", 14, FontStyle.Bold);

                    float startX = 10;
                    float startY = 10;
                    float offset = 20;

                    graphics.DrawString("CONTROL DE CILINDROS", fontTitle, Brushes.Black, startX, startY);
                    startY += offset + 10;

                    graphics.DrawString("--------------------------------", font, Brushes.Black, startX, startY);
                    startY += offset;

                    graphics.DrawString($"FECHA: {ticket.Fecha:g}", fontBold, Brushes.Black, startX, startY);
                    startY += offset;

                    graphics.DrawString($"CLIENTE: {ticket.Cliente}", fontBold, Brushes.Black, startX, startY);
                    startY += offset;

                    graphics.DrawString($"VENDEDOR: {ticket.Vendedor}", fontBold, Brushes.Black, startX, startY);
                    startY += offset;

                    graphics.DrawString($"CILINDRO: {ticket.NumeroCilindro}", fontBold, Brushes.Black, startX, startY);
                    startY += offset;

                    graphics.DrawString($"TIPO: {ticket.Tipo}", fontBold, Brushes.Black, startX, startY);
                    startY += offset;

                    graphics.DrawString($"PESO: {ticket.Peso:N0} gr", fontBold, Brushes.Black, startX, startY);
                    startY += offset;

                    graphics.DrawString($"ESTADO: {ticket.Estado}", fontBold, Brushes.Black, startX, startY);
                    startY += offset + 10;

                    graphics.DrawString("--------------------------------", font, Brushes.Black, startX, startY);
                    startY += offset;

                    graphics.DrawString("**DEBE DEVOLVER EL CILINDRO**", fontBold, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("EN EL MISMO ESTADO EN QUE SE", fontBold, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("LO ENTREGAMOS", fontBold, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("Gracias por su preferencia", font, Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("DevMelk", font2, Brushes.Black, startX, startY);
                };

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = pd;


                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir el ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarTransaccion_Click_1(object sender, EventArgs e)
        {
            if (dgvTransacciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una transacción para eliminar.",
                              "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvTransacciones.SelectedRows[0];
            int idTransaccion = (int)selectedRow.Cells["Id"].Value;

            var transaccionAEliminar = transacciones.FirstOrDefault(t => t.Id == idTransaccion);

            if (transaccionAEliminar == null)
            {
                MessageBox.Show("No se encontró la transacción seleccionada.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mensajeConfirmacion = $"¿Está seguro de eliminar esta transacción?\n\n" +
                                       $"ID: {transaccionAEliminar.Id}\n" +
                                       $"Cliente: {transaccionAEliminar.Cliente?.Nombre}\n" +
                                       $"Cilindro: {transaccionAEliminar.CilindroInfo}\n" +
                                       $"Fecha: {transaccionAEliminar.Fecha:g}";

            DialogResult confirmacion = MessageBox.Show(mensajeConfirmacion,
                                                     "Confirmar Eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            string contraseñaCorrecta = "123"; // Cambia esto por tu contraseña real
            string contraseñaIngresada = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese la contraseña de administrador para confirmar:",
                "Autenticación Requerida",
                "");

            if (contraseñaIngresada != contraseñaCorrecta)
            {
                MessageBox.Show("Contraseña incorrecta. Operación cancelada.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            transacciones.Remove(transaccionAEliminar);

            if (transaccionAEliminar.estado == "prestado" && transaccionAEliminar.Cilindro != null)
            {
                transaccionAEliminar.Cilindro.Estado = "Disponible";
                GuardarDatos(RutaCilindros, cilindros); // Guardar cambio de estado del cilindro
            }

            GuardarDatos(RutaTransacciones, transacciones);

            ActualizarTransaccionesGrid();
            ActualizarComboboxCilindros();
            ActualizarComboboxOperaciones();

            MessageBox.Show("Transacción eliminada correctamente.",
                           "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(this);
            admin.Show();
        }
    }
}