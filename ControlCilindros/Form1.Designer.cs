namespace ControlCilindros
{
    partial class Form1
    {
        private System.Windows.Forms.Label lblClientes;

        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.Button btnRegistrarCliente;
        private System.Windows.Forms.DataGridView dgvClientes;

        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.ComboBox cbVendedores;
        private System.Windows.Forms.ComboBox cbCilindros;
        private System.Windows.Forms.TextBox txtPesoFinal;
        private System.Windows.Forms.Button btnRegistrarTransaccion;

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblClientes = new Label();
            txtNombreCliente = new TextBox();
            txtTelefonoCliente = new TextBox();
            btnRegistrarCliente = new Button();
            dgvClientes = new DataGridView();
            cbClientes = new ComboBox();
            cbVendedores = new ComboBox();
            cbCilindros = new ComboBox();
            txtPesoFinal = new TextBox();
            btnRegistrarTransaccion = new Button();
            dgvTransacciones = new DataGridView();
            labelCliente = new Label();
            labelVendedor = new Label();
            labelCilindro = new Label();
            cbTransacciones = new ComboBox();
            lblRecibir = new Label();
            lblLlevar = new Label();
            label1 = new Label();
            btnRecibir = new Button();
            textPesoRegreso = new TextBox();
            gridCilindroRecibido = new DataGridView();
            label2 = new Label();
            cbRecibe = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnHistorial = new Button();
            label6 = new Label();
            button1 = new Button();
            btnEliminarTransaccion = new Button();
            label7 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransacciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridCilindroRecibido).BeginInit();
            SuspendLayout();
            // 
            // lblClientes
            // 
            lblClientes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClientes.Location = new Point(307, 67);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(100, 23);
            lblClientes.TabIndex = 0;
            lblClientes.Text = "Clientes";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(9, 68);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.PlaceholderText = "Nombre";
            txtNombreCliente.Size = new Size(100, 23);
            txtNombreCliente.TabIndex = 4;
            // 
            // txtTelefonoCliente
            // 
            txtTelefonoCliente.Location = new Point(115, 68);
            txtTelefonoCliente.Name = "txtTelefonoCliente";
            txtTelefonoCliente.PlaceholderText = "Teléfono";
            txtTelefonoCliente.Size = new Size(100, 23);
            txtTelefonoCliente.TabIndex = 5;
            // 
            // btnRegistrarCliente
            // 
            btnRegistrarCliente.Location = new Point(221, 68);
            btnRegistrarCliente.Name = "btnRegistrarCliente";
            btnRegistrarCliente.Size = new Size(75, 23);
            btnRegistrarCliente.TabIndex = 6;
            btnRegistrarCliente.Text = "Registrar Cliente";
            btnRegistrarCliente.Click += btnRegistrarCliente_Click_1;
            // 
            // dgvClientes
            // 
            dgvClientes.Location = new Point(12, 97);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(395, 103);
            dgvClientes.TabIndex = 7;
            // 
            // cbClientes
            // 
            cbClientes.Location = new Point(12, 292);
            cbClientes.Name = "cbClientes";
            cbClientes.Size = new Size(150, 23);
            cbClientes.TabIndex = 16;
            cbClientes.SelectedIndexChanged += cbClientes_SelectedIndexChanged;
            // 
            // cbVendedores
            // 
            cbVendedores.Location = new Point(179, 292);
            cbVendedores.Name = "cbVendedores";
            cbVendedores.Size = new Size(150, 23);
            cbVendedores.TabIndex = 17;
            // 
            // cbCilindros
            // 
            cbCilindros.Location = new Point(355, 292);
            cbCilindros.Name = "cbCilindros";
            cbCilindros.Size = new Size(150, 23);
            cbCilindros.TabIndex = 18;
            // 
            // txtPesoFinal
            // 
            txtPesoFinal.Location = new Point(533, 292);
            txtPesoFinal.Name = "txtPesoFinal";
            txtPesoFinal.PlaceholderText = "Peso inicial";
            txtPesoFinal.Size = new Size(100, 23);
            txtPesoFinal.TabIndex = 19;
            // 
            // btnRegistrarTransaccion
            // 
            btnRegistrarTransaccion.BackColor = SystemColors.InactiveBorder;
            btnRegistrarTransaccion.Location = new Point(884, 292);
            btnRegistrarTransaccion.Name = "btnRegistrarTransaccion";
            btnRegistrarTransaccion.Size = new Size(132, 27);
            btnRegistrarTransaccion.TabIndex = 20;
            btnRegistrarTransaccion.Text = "Registrar Transacción";
            btnRegistrarTransaccion.UseVisualStyleBackColor = false;
            btnRegistrarTransaccion.Click += btnRegistrarTransaccion_Click_Llevar;
            // 
            // dgvTransacciones
            // 
            dgvTransacciones.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvTransacciones.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvTransacciones.Location = new Point(12, 351);
            dgvTransacciones.Name = "dgvTransacciones";
            dgvTransacciones.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransacciones.Size = new Size(1004, 151);
            dgvTransacciones.TabIndex = 21;
            // 
            // labelCliente
            // 
            labelCliente.BackColor = SystemColors.ControlLightLight;
            labelCliente.Location = new Point(12, 276);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new Size(93, 13);
            labelCliente.TabIndex = 22;
            labelCliente.Text = "Cliente";
            // 
            // labelVendedor
            // 
            labelVendedor.BackColor = SystemColors.ControlLightLight;
            labelVendedor.Location = new Point(179, 276);
            labelVendedor.Name = "labelVendedor";
            labelVendedor.Size = new Size(130, 13);
            labelVendedor.TabIndex = 23;
            labelVendedor.Text = "Vendedor que entrega";
            labelVendedor.Click += labelVendedor_Click;
            // 
            // labelCilindro
            // 
            labelCilindro.BackColor = SystemColors.ControlLightLight;
            labelCilindro.Location = new Point(355, 276);
            labelCilindro.Name = "labelCilindro";
            labelCilindro.Size = new Size(93, 13);
            labelCilindro.TabIndex = 24;
            labelCilindro.Text = "Cilindro";
            // 
            // cbTransacciones
            // 
            cbTransacciones.Location = new Point(12, 538);
            cbTransacciones.Name = "cbTransacciones";
            cbTransacciones.Size = new Size(421, 23);
            cbTransacciones.TabIndex = 25;
            cbTransacciones.SelectedIndexChanged += cbTransacciones_SelectedIndexChanged;
            // 
            // lblRecibir
            // 
            lblRecibir.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecibir.Location = new Point(12, 505);
            lblRecibir.Name = "lblRecibir";
            lblRecibir.Size = new Size(150, 30);
            lblRecibir.TabIndex = 26;
            lblRecibir.Text = "Recibir cilindro";
            // 
            // lblLlevar
            // 
            lblLlevar.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLlevar.Location = new Point(12, 237);
            lblLlevar.Name = "lblLlevar";
            lblLlevar.Size = new Size(203, 30);
            lblLlevar.TabIndex = 3;
            lblLlevar.Text = "Prestar cilindro";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 329);
            label1.Name = "label1";
            label1.Size = new Size(156, 19);
            label1.TabIndex = 27;
            label1.Text = "Cilindros prestados";
            // 
            // btnRecibir
            // 
            btnRecibir.BackColor = SystemColors.ControlLightLight;
            btnRecibir.Location = new Point(884, 535);
            btnRecibir.Name = "btnRecibir";
            btnRecibir.Size = new Size(132, 27);
            btnRecibir.TabIndex = 28;
            btnRecibir.Text = "Registrar Transacción";
            btnRecibir.UseVisualStyleBackColor = false;
            btnRecibir.Click += btnRecibir_Click;
            // 
            // textPesoRegreso
            // 
            textPesoRegreso.Location = new Point(633, 538);
            textPesoRegreso.Name = "textPesoRegreso";
            textPesoRegreso.PlaceholderText = "Peso regreso";
            textPesoRegreso.Size = new Size(100, 23);
            textPesoRegreso.TabIndex = 29;
            // 
            // gridCilindroRecibido
            // 
            gridCilindroRecibido.Location = new Point(12, 601);
            gridCilindroRecibido.Name = "gridCilindroRecibido";
            gridCilindroRecibido.Size = new Size(1155, 105);
            gridCilindroRecibido.TabIndex = 30;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 579);
            label2.Name = "label2";
            label2.Size = new Size(156, 19);
            label2.TabIndex = 31;
            label2.Text = "Cilindro recibido";
            // 
            // cbRecibe
            // 
            cbRecibe.Location = new Point(451, 539);
            cbRecibe.Name = "cbRecibe";
            cbRecibe.Size = new Size(150, 23);
            cbRecibe.TabIndex = 33;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Location = new Point(451, 523);
            label3.Name = "label3";
            label3.Size = new Size(130, 13);
            label3.TabIndex = 34;
            label3.Text = "Vendedor que recibe";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Location = new Point(533, 276);
            label4.Name = "label4";
            label4.Size = new Size(93, 13);
            label4.TabIndex = 35;
            label4.Text = "Peso inicial";
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ControlLightLight;
            label5.Location = new Point(630, 523);
            label5.Name = "label5";
            label5.Size = new Size(93, 13);
            label5.TabIndex = 36;
            label5.Text = "Peso final";
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = SystemColors.ButtonHighlight;
            btnHistorial.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnHistorial.Location = new Point(1174, 622);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(161, 38);
            btnHistorial.TabIndex = 37;
            btnHistorial.Text = "Historial transacciones";
            btnHistorial.UseVisualStyleBackColor = false;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(696, 709);
            label6.Name = "label6";
            label6.Size = new Size(236, 22);
            label6.TabIndex = 38;
            label6.Text = "ING MELQUICEDETH";
            label6.Click += label6_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1174, 670);
            button1.Name = "button1";
            button1.Size = new Size(161, 38);
            button1.TabIndex = 39;
            button1.Text = "Actualizar tablas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnEliminarTransaccion
            // 
            btnEliminarTransaccion.BackColor = Color.IndianRed;
            btnEliminarTransaccion.Cursor = Cursors.No;
            btnEliminarTransaccion.Location = new Point(949, 351);
            btnEliminarTransaccion.Name = "btnEliminarTransaccion";
            btnEliminarTransaccion.Size = new Size(67, 27);
            btnEliminarTransaccion.TabIndex = 40;
            btnEliminarTransaccion.Text = "Eliminar transacción";
            btnEliminarTransaccion.UseVisualStyleBackColor = false;
            btnEliminarTransaccion.Click += btnEliminarTransaccion_Click_1;
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ControlLightLight;
            label7.Location = new Point(1332, 709);
            label7.Name = "label7";
            label7.Size = new Size(53, 17);
            label7.TabIndex = 41;
            label7.Text = "V. 1.01.8";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            button2.Location = new Point(1275, 68);
            button2.Name = "button2";
            button2.Size = new Size(101, 25);
            button2.TabIndex = 42;
            button2.Text = "Administración";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AccessibleName = "Control de cilindros";
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.InactiveCaption;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1388, 727);
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(btnEliminarTransaccion);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(btnHistorial);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbRecibe);
            Controls.Add(label2);
            Controls.Add(gridCilindroRecibido);
            Controls.Add(textPesoRegreso);
            Controls.Add(btnRecibir);
            Controls.Add(label1);
            Controls.Add(lblRecibir);
            Controls.Add(cbTransacciones);
            Controls.Add(labelCilindro);
            Controls.Add(labelVendedor);
            Controls.Add(labelCliente);
            Controls.Add(lblClientes);
            Controls.Add(lblLlevar);
            Controls.Add(txtNombreCliente);
            Controls.Add(txtTelefonoCliente);
            Controls.Add(btnRegistrarCliente);
            Controls.Add(dgvClientes);
            Controls.Add(cbClientes);
            Controls.Add(cbVendedores);
            Controls.Add(cbCilindros);
            Controls.Add(txtPesoFinal);
            Controls.Add(btnRegistrarTransaccion);
            Controls.Add(dgvTransacciones);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control de Cilindros";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransacciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridCilindroRecibido).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelCliente;
        private Label labelVendedor;
        private Label labelCilindro;
        private ComboBox cbTransacciones;
        private Label lblRecibir;
        private Label lblLlevar;
        private Label label1;
        private Button btnRecibir;
        private TextBox textPesoRegreso;
        private DataGridView gridCilindroRecibido;
        private Label label2;
        private ComboBox cbRecibe;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnHistorial;
        private Label label6;
        public DataGridView dgvTransacciones;
        private Button button1;
        private Button btnEliminarTransaccion;
        private Label label7;
        private Button button2;
    }
}
