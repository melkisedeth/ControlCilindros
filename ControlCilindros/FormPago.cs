using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlCilindros
{
    public partial class FormPago : MaterialForm
    {
        public double MontoRecibido { get; private set; }
        public double Cambio { get; private set; }
        private readonly double montoAPagar;

        public FormPago(double montoAPagar)
        {
            InitializeComponent();
            this.montoAPagar = montoAPagar;
            ConfigurarMaterialSkin();
            ConfigurarControles();
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

        private void ConfigurarControles()
        {
            lblMontoAPagar.Text = montoAPagar.ToString("C2");
            txtMontoRecibido.KeyPress += TxtMontoRecibido_KeyPress;
            txtMontoRecibido.TextChanged += TxtMontoRecibido_TextChanged;

            // Configurar label para mostrar el cambio
            lblCambio = new MaterialLabel();
            lblCambio.AutoSize = true;
            lblCambio.Depth = 0;
            lblCambio.Font = new Font("Roboto", 11F);
            lblCambio.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblCambio.Location = new Point(50, 200);
            lblCambio.MouseState = MaterialSkin.MouseState.HOVER;
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(100, 19);
            lblCambio.TabIndex = 6;
            lblCambio.Text = "Cambio: $0.00";
            this.Controls.Add(lblCambio);
        }

        private void TxtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtMontoRecibido.Text, out double montoRecibido))
            {
                double cambio = montoRecibido - montoAPagar;
                lblCambio.Text = $"Cambio: {cambio.ToString("C2")}";

                // Cambiar color según si es suficiente o no
                if (cambio < 0)
                {
                    lblCambio.ForeColor = Color.Red;
                }
                else
                {
                    lblCambio.ForeColor = Color.FromArgb(222, 0, 0, 0); // Color original
                }
            }
            else
            {
                lblCambio.Text = "Cambio: $0.00";
                lblCambio.ForeColor = Color.FromArgb(222, 0, 0, 0);
            }
        }

        private void TxtMontoRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtMontoRecibido.Text, out double montoRecibido) || montoRecibido <= 0)
            {
                MessageBox.Show("Ingrese un monto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (montoRecibido < montoAPagar)
            {
                MessageBox.Show($"El monto recibido ({montoRecibido:C2}) es menor al monto a pagar ({montoAPagar:C2})",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MontoRecibido = montoRecibido;
            Cambio = montoRecibido - montoAPagar;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
