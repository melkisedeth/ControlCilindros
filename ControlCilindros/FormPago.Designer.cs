namespace ControlCilindros
{
    partial class FormPago
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialLabel lblMontoAPagar;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMontoRecibido;
        private MaterialSkin.Controls.MaterialRaisedButton btnAceptar;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancelar;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel lblCambio;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMontoAPagar = new MaterialSkin.Controls.MaterialLabel();
            this.txtMontoRecibido = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnAceptar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();

            // lblMontoAPagar
            this.lblMontoAPagar.AutoSize = true;
            this.lblMontoAPagar.Depth = 0;
            this.lblMontoAPagar.Font = new Font("Roboto", 11F);
            this.lblMontoAPagar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            this.lblMontoAPagar.Location = new Point(150, 100);
            this.lblMontoAPagar.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMontoAPagar.Name = "lblMontoAPagar";
            this.lblMontoAPagar.Size = new Size(100, 19);
            this.lblMontoAPagar.TabIndex = 0;
            this.lblMontoAPagar.Text = "$0.00";

            // txtMontoRecibido
            this.txtMontoRecibido.Depth = 0;
            this.txtMontoRecibido.Hint = "";
            this.txtMontoRecibido.Location = new Point(150, 170);
            this.txtMontoRecibido.MaxLength = 32767;
            this.txtMontoRecibido.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.PasswordChar = '\0';
            this.txtMontoRecibido.SelectedText = "";
            this.txtMontoRecibido.SelectionLength = 0;
            this.txtMontoRecibido.SelectionStart = 0;
            this.txtMontoRecibido.Size = new Size(200, 23);
            this.txtMontoRecibido.TabIndex = 1;
            this.txtMontoRecibido.UseSystemPasswordChar = false;

            // btnAceptar
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnAceptar.Depth = 0;
            this.btnAceptar.Icon = null;
            this.btnAceptar.Location = new Point(50, 250);
            this.btnAceptar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Primary = true;
            this.btnAceptar.Size = new Size(80, 36);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            // btnCancelar
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new Point(150, 250);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Primary = true;
            this.btnCancelar.Size = new Size(90, 36);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // materialLabel1
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new Font("Roboto", 11F);
            this.materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            this.materialLabel1.Location = new Point(50, 100);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new Size(100, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Total a pagar:";

            // materialLabel2
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new Font("Roboto", 11F);
            this.materialLabel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            this.materialLabel2.Location = new Point(50, 170);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new Size(110, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Monto recibido:";

            // FormPago
            this.ClientSize = new Size(400, 350);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtMontoRecibido);
            this.Controls.Add(this.lblMontoAPagar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPago";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Registro de Pago";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}