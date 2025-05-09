namespace ControlCilindros
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            txtPrecioGramo22 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            tabControl1 = new TabControl();
            tabLogin = new TabPage();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            btnLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            tabMain = new TabPage();
            btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            btnBack = new MaterialSkin.Controls.MaterialRaisedButton();
            tabControl2 = new TabControl();
            tabClientes = new TabPage();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            btnDeleteCliente = new MaterialSkin.Controls.MaterialRaisedButton();
            btnAddCliente = new MaterialSkin.Controls.MaterialRaisedButton();
            txtTelefonoCliente = new MaterialSkin.Controls.MaterialSingleLineTextField();
            txtNombreCliente = new MaterialSkin.Controls.MaterialSingleLineTextField();
            dgvClientes = new DataGridView();
            tabCilindros = new TabPage();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            txtPrecioGramo222 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            btnDeleteCilindro = new MaterialSkin.Controls.MaterialRaisedButton();
            btnToggleDisponibilidad = new MaterialSkin.Controls.MaterialRaisedButton();
            btnAddCilindro = new MaterialSkin.Controls.MaterialRaisedButton();
            comboBoxTipo = new ComboBox();
            txtPesoInicial = new MaterialSkin.Controls.MaterialSingleLineTextField();
            txtNumeroCilindro = new MaterialSkin.Controls.MaterialSingleLineTextField();
            dgvCilindros = new DataGridView();
            tabControl1.SuspendLayout();
            tabLogin.SuspendLayout();
            tabMain.SuspendLayout();
            tabControl2.SuspendLayout();
            tabClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            tabCilindros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCilindros).BeginInit();
            SuspendLayout();
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Microsoft Sans Serif", 11F);
            materialLabel7.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel7.Location = new Point(607, 170);
            materialLabel7.Margin = new Padding(4, 0, 4, 0);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(117, 19);
            materialLabel7.TabIndex = 10;
            materialLabel7.Text = "Precio por gramo";
            // 
            // txtPrecioGramo22
            // 
            txtPrecioGramo22.Depth = 0;
            txtPrecioGramo22.Hint = "";
            txtPrecioGramo22.Location = new Point(607, 193);
            txtPrecioGramo22.Margin = new Padding(4, 3, 4, 3);
            txtPrecioGramo22.MaxLength = 32767;
            txtPrecioGramo22.MouseState = MaterialSkin.MouseState.HOVER;
            txtPrecioGramo22.Name = "txtPrecioGramo22";
            txtPrecioGramo22.PasswordChar = '\0';
            txtPrecioGramo22.SelectedText = "";
            txtPrecioGramo22.SelectionLength = 0;
            txtPrecioGramo22.SelectionStart = 0;
            txtPrecioGramo22.Size = new Size(233, 23);
            txtPrecioGramo22.TabIndex = 11;
            txtPrecioGramo22.TabStop = false;
            txtPrecioGramo22.UseSystemPasswordChar = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabLogin);
            tabControl1.Controls.Add(tabMain);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(933, 519);
            tabControl1.TabIndex = 0;
            // 
            // tabLogin
            // 
            tabLogin.Controls.Add(materialLabel1);
            tabLogin.Controls.Add(txtPassword);
            tabLogin.Controls.Add(btnLogin);
            tabLogin.Location = new Point(4, 24);
            tabLogin.Margin = new Padding(4, 3, 4, 3);
            tabLogin.Name = "tabLogin";
            tabLogin.Padding = new Padding(4, 3, 4, 3);
            tabLogin.Size = new Size(925, 491);
            tabLogin.TabIndex = 0;
            tabLogin.Text = "Login";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 11F);
            materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel1.Location = new Point(350, 115);
            materialLabel1.Margin = new Padding(4, 0, 4, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(202, 19);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Ingrese contraseña de admin";
            // 
            // txtPassword
            // 
            txtPassword.Depth = 0;
            txtPassword.Hint = "";
            txtPassword.Location = new Point(292, 173);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.MaxLength = 32767;
            txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.SelectedText = "";
            txtPassword.SelectionLength = 0;
            txtPassword.SelectionStart = 0;
            txtPassword.Size = new Size(350, 23);
            txtPassword.TabIndex = 1;
            txtPassword.TabStop = false;
            txtPassword.UseSystemPasswordChar = false;
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = true;
            btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogin.Depth = 0;
            btnLogin.Icon = null;
            btnLogin.Location = new Point(408, 231);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            btnLogin.Name = "btnLogin";
            btnLogin.Primary = true;
            btnLogin.Size = new Size(86, 36);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Ingresar";
            btnLogin.Click += btnLogin_Click;
            // 
            // tabMain
            // 
            tabMain.Controls.Add(btnClose);
            tabMain.Controls.Add(btnBack);
            tabMain.Controls.Add(tabControl2);
            tabMain.Location = new Point(4, 24);
            tabMain.Margin = new Padding(4, 3, 4, 3);
            tabMain.Name = "tabMain";
            tabMain.Padding = new Padding(4, 3, 4, 3);
            tabMain.Size = new Size(925, 491);
            tabMain.TabIndex = 1;
            tabMain.Text = "Main";
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClose.Depth = 0;
            btnClose.Icon = null;
            btnClose.Location = new Point(793, 438);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            btnClose.Name = "btnClose";
            btnClose.Primary = true;
            btnClose.Size = new Size(73, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Cerrar";
            btnClose.Click += btnClose_Click;
            // 
            // btnBack
            // 
            btnBack.AutoSize = true;
            btnBack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBack.Depth = 0;
            btnBack.Icon = null;
            btnBack.Location = new Point(12, 438);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.MouseState = MaterialSkin.MouseState.HOVER;
            btnBack.Name = "btnBack";
            btnBack.Primary = true;
            btnBack.Size = new Size(72, 36);
            btnBack.TabIndex = 1;
            btnBack.Text = "Volver";
            btnBack.Click += btnBack_Click;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabClientes);
            tabControl2.Controls.Add(tabCilindros);
            tabControl2.Dock = DockStyle.Top;
            tabControl2.Location = new Point(4, 3);
            tabControl2.Margin = new Padding(4, 3, 4, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(917, 427);
            tabControl2.TabIndex = 0;
            // 
            // tabClientes
            // 
            tabClientes.Controls.Add(materialLabel3);
            tabClientes.Controls.Add(materialLabel2);
            tabClientes.Controls.Add(btnDeleteCliente);
            tabClientes.Controls.Add(btnAddCliente);
            tabClientes.Controls.Add(txtTelefonoCliente);
            tabClientes.Controls.Add(txtNombreCliente);
            tabClientes.Controls.Add(dgvClientes);
            tabClientes.Location = new Point(4, 24);
            tabClientes.Margin = new Padding(4, 3, 4, 3);
            tabClientes.Name = "tabClientes";
            tabClientes.Padding = new Padding(4, 3, 4, 3);
            tabClientes.Size = new Size(909, 399);
            tabClientes.TabIndex = 0;
            tabClientes.Text = "Clientes";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 11F);
            materialLabel3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel3.Location = new Point(607, 127);
            materialLabel3.Margin = new Padding(4, 0, 4, 0);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(69, 19);
            materialLabel3.TabIndex = 6;
            materialLabel3.Text = "Teléfono";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 11F);
            materialLabel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel2.Location = new Point(607, 35);
            materialLabel2.Margin = new Padding(4, 0, 4, 0);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(63, 19);
            materialLabel2.TabIndex = 5;
            materialLabel2.Text = "Nombre";
            // 
            // btnDeleteCliente
            // 
            btnDeleteCliente.AutoSize = true;
            btnDeleteCliente.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteCliente.Depth = 0;
            btnDeleteCliente.Icon = null;
            btnDeleteCliente.Location = new Point(735, 231);
            btnDeleteCliente.Margin = new Padding(4, 3, 4, 3);
            btnDeleteCliente.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteCliente.Name = "btnDeleteCliente";
            btnDeleteCliente.Primary = true;
            btnDeleteCliente.Size = new Size(83, 36);
            btnDeleteCliente.TabIndex = 4;
            btnDeleteCliente.Text = "Eliminar";
            btnDeleteCliente.Click += btnDeleteCliente_Click;
            // 
            // btnAddCliente
            // 
            btnAddCliente.AutoSize = true;
            btnAddCliente.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddCliente.Depth = 0;
            btnAddCliente.Icon = null;
            btnAddCliente.Location = new Point(607, 231);
            btnAddCliente.Margin = new Padding(4, 3, 4, 3);
            btnAddCliente.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddCliente.Name = "btnAddCliente";
            btnAddCliente.Primary = true;
            btnAddCliente.Size = new Size(83, 36);
            btnAddCliente.TabIndex = 3;
            btnAddCliente.Text = "Agregar";
            btnAddCliente.Click += btnAddCliente_Click;
            // 
            // txtTelefonoCliente
            // 
            txtTelefonoCliente.Depth = 0;
            txtTelefonoCliente.Hint = "";
            txtTelefonoCliente.Location = new Point(607, 150);
            txtTelefonoCliente.Margin = new Padding(4, 3, 4, 3);
            txtTelefonoCliente.MaxLength = 32767;
            txtTelefonoCliente.MouseState = MaterialSkin.MouseState.HOVER;
            txtTelefonoCliente.Name = "txtTelefonoCliente";
            txtTelefonoCliente.PasswordChar = '\0';
            txtTelefonoCliente.SelectedText = "";
            txtTelefonoCliente.SelectionLength = 0;
            txtTelefonoCliente.SelectionStart = 0;
            txtTelefonoCliente.Size = new Size(233, 23);
            txtTelefonoCliente.TabIndex = 2;
            txtTelefonoCliente.TabStop = false;
            txtTelefonoCliente.UseSystemPasswordChar = false;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Depth = 0;
            txtNombreCliente.Hint = "";
            txtNombreCliente.Location = new Point(607, 58);
            txtNombreCliente.Margin = new Padding(4, 3, 4, 3);
            txtNombreCliente.MaxLength = 32767;
            txtNombreCliente.MouseState = MaterialSkin.MouseState.HOVER;
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.PasswordChar = '\0';
            txtNombreCliente.SelectedText = "";
            txtNombreCliente.SelectionLength = 0;
            txtNombreCliente.SelectionStart = 0;
            txtNombreCliente.Size = new Size(233, 23);
            txtNombreCliente.TabIndex = 1;
            txtNombreCliente.TabStop = false;
            txtNombreCliente.UseSystemPasswordChar = false;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(7, 7);
            dgvClientes.Margin = new Padding(4, 3, 4, 3);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(583, 383);
            dgvClientes.TabIndex = 0;
            // 
            // tabCilindros
            // 
            tabCilindros.Controls.Add(materialLabel8);
            tabCilindros.Controls.Add(txtPrecioGramo222);
            tabCilindros.Controls.Add(materialLabel6);
            tabCilindros.Controls.Add(materialLabel5);
            tabCilindros.Controls.Add(materialLabel4);
            tabCilindros.Controls.Add(btnDeleteCilindro);
            tabCilindros.Controls.Add(btnToggleDisponibilidad);
            tabCilindros.Controls.Add(btnAddCilindro);
            tabCilindros.Controls.Add(comboBoxTipo);
            tabCilindros.Controls.Add(txtPesoInicial);
            tabCilindros.Controls.Add(txtNumeroCilindro);
            tabCilindros.Controls.Add(dgvCilindros);
            tabCilindros.Location = new Point(4, 24);
            tabCilindros.Margin = new Padding(4, 3, 4, 3);
            tabCilindros.Name = "tabCilindros";
            tabCilindros.Padding = new Padding(4, 3, 4, 3);
            tabCilindros.Size = new Size(909, 399);
            tabCilindros.TabIndex = 1;
            tabCilindros.Text = "Cilindros";
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 11F);
            materialLabel8.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel8.Location = new Point(607, 279);
            materialLabel8.Margin = new Padding(4, 0, 4, 0);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(149, 19);
            materialLabel8.TabIndex = 11;
            materialLabel8.Text = "Precio por Gramo ($)";
            // 
            // txtPrecioGramo222
            // 
            txtPrecioGramo222.Depth = 0;
            txtPrecioGramo222.Hint = "";
            txtPrecioGramo222.Location = new Point(607, 301);
            txtPrecioGramo222.Margin = new Padding(4, 3, 4, 3);
            txtPrecioGramo222.MaxLength = 32767;
            txtPrecioGramo222.MouseState = MaterialSkin.MouseState.HOVER;
            txtPrecioGramo222.Name = "txtPrecioGramo222";
            txtPrecioGramo222.PasswordChar = '\0';
            txtPrecioGramo222.SelectedText = "";
            txtPrecioGramo222.SelectionLength = 0;
            txtPrecioGramo222.SelectionStart = 0;
            txtPrecioGramo222.Size = new Size(233, 23);
            txtPrecioGramo222.TabIndex = 10;
            txtPrecioGramo222.TabStop = false;
            txtPrecioGramo222.UseSystemPasswordChar = false;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 11F);
            materialLabel6.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel6.Location = new Point(607, 219);
            materialLabel6.Margin = new Padding(4, 0, 4, 0);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(39, 19);
            materialLabel6.TabIndex = 9;
            materialLabel6.Text = "Tipo";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 11F);
            materialLabel5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel5.Location = new Point(607, 127);
            materialLabel5.Margin = new Padding(4, 0, 4, 0);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(108, 19);
            materialLabel5.TabIndex = 8;
            materialLabel5.Text = "Peso (gramos)";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 11F);
            materialLabel4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel4.Location = new Point(607, 35);
            materialLabel4.Margin = new Padding(4, 0, 4, 0);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(119, 19);
            materialLabel4.TabIndex = 7;
            materialLabel4.Text = "Número Cilindro";
            // 
            // btnDeleteCilindro
            // 
            btnDeleteCilindro.AutoSize = true;
            btnDeleteCilindro.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteCilindro.Depth = 0;
            btnDeleteCilindro.Icon = null;
            btnDeleteCilindro.Location = new Point(802, 354);
            btnDeleteCilindro.Margin = new Padding(4, 3, 4, 3);
            btnDeleteCilindro.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteCilindro.Name = "btnDeleteCilindro";
            btnDeleteCilindro.Primary = true;
            btnDeleteCilindro.Size = new Size(83, 36);
            btnDeleteCilindro.TabIndex = 6;
            btnDeleteCilindro.Text = "Eliminar";
            btnDeleteCilindro.Click += btnDeleteCilindro_Click;
            // 
            // btnToggleDisponibilidad
            // 
            btnToggleDisponibilidad.AutoSize = true;
            btnToggleDisponibilidad.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnToggleDisponibilidad.Depth = 0;
            btnToggleDisponibilidad.Icon = null;
            btnToggleDisponibilidad.Location = new Point(696, 354);
            btnToggleDisponibilidad.Margin = new Padding(4, 3, 4, 3);
            btnToggleDisponibilidad.MouseState = MaterialSkin.MouseState.HOVER;
            btnToggleDisponibilidad.Name = "btnToggleDisponibilidad";
            btnToggleDisponibilidad.Primary = true;
            btnToggleDisponibilidad.Size = new Size(98, 36);
            btnToggleDisponibilidad.TabIndex = 5;
            btnToggleDisponibilidad.Text = "Disponible";
            btnToggleDisponibilidad.Click += btnToggleDisponibilidad_Click;
            // 
            // btnAddCilindro
            // 
            btnAddCilindro.AutoSize = true;
            btnAddCilindro.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddCilindro.Depth = 0;
            btnAddCilindro.Icon = null;
            btnAddCilindro.Location = new Point(605, 354);
            btnAddCilindro.Margin = new Padding(4, 3, 4, 3);
            btnAddCilindro.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddCilindro.Name = "btnAddCilindro";
            btnAddCilindro.Primary = true;
            btnAddCilindro.Size = new Size(83, 36);
            btnAddCilindro.TabIndex = 4;
            btnAddCilindro.Text = "Agregar";
            btnAddCilindro.Click += btnAddCilindro_Click;
            // 
            // comboBoxTipo
            // 
            comboBoxTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipo.FormattingEnabled = true;
            comboBoxTipo.Location = new Point(607, 242);
            comboBoxTipo.Margin = new Padding(4, 3, 4, 3);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(233, 23);
            comboBoxTipo.TabIndex = 3;
            // 
            // txtPesoInicial
            // 
            txtPesoInicial.Depth = 0;
            txtPesoInicial.Hint = "";
            txtPesoInicial.Location = new Point(607, 150);
            txtPesoInicial.Margin = new Padding(4, 3, 4, 3);
            txtPesoInicial.MaxLength = 32767;
            txtPesoInicial.MouseState = MaterialSkin.MouseState.HOVER;
            txtPesoInicial.Name = "txtPesoInicial";
            txtPesoInicial.PasswordChar = '\0';
            txtPesoInicial.SelectedText = "";
            txtPesoInicial.SelectionLength = 0;
            txtPesoInicial.SelectionStart = 0;
            txtPesoInicial.Size = new Size(233, 23);
            txtPesoInicial.TabIndex = 2;
            txtPesoInicial.TabStop = false;
            txtPesoInicial.UseSystemPasswordChar = false;
            // 
            // txtNumeroCilindro
            // 
            txtNumeroCilindro.Depth = 0;
            txtNumeroCilindro.Hint = "";
            txtNumeroCilindro.Location = new Point(607, 58);
            txtNumeroCilindro.Margin = new Padding(4, 3, 4, 3);
            txtNumeroCilindro.MaxLength = 32767;
            txtNumeroCilindro.MouseState = MaterialSkin.MouseState.HOVER;
            txtNumeroCilindro.Name = "txtNumeroCilindro";
            txtNumeroCilindro.PasswordChar = '\0';
            txtNumeroCilindro.SelectedText = "";
            txtNumeroCilindro.SelectionLength = 0;
            txtNumeroCilindro.SelectionStart = 0;
            txtNumeroCilindro.Size = new Size(233, 23);
            txtNumeroCilindro.TabIndex = 1;
            txtNumeroCilindro.TabStop = false;
            txtNumeroCilindro.UseSystemPasswordChar = false;
            // 
            // dgvCilindros
            // 
            dgvCilindros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCilindros.Location = new Point(7, 7);
            dgvCilindros.Margin = new Padding(4, 3, 4, 3);
            dgvCilindros.Name = "dgvCilindros";
            dgvCilindros.Size = new Size(583, 383);
            dgvCilindros.TabIndex = 0;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Admin";
            Text = "Administración - Control de Cilindros";
            tabControl1.ResumeLayout(false);
            tabLogin.ResumeLayout(false);
            tabLogin.PerformLayout();
            tabMain.ResumeLayout(false);
            tabMain.PerformLayout();
            tabControl2.ResumeLayout(false);
            tabClientes.ResumeLayout(false);
            tabClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            tabCilindros.ResumeLayout(false);
            tabCilindros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCilindros).EndInit();
            ResumeLayout(false);

            tabVendedores = new TabPage();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            btnDeleteVendedor = new MaterialSkin.Controls.MaterialRaisedButton();
            btnAddVendedor = new MaterialSkin.Controls.MaterialRaisedButton();
            txtNombreVendedor = new MaterialSkin.Controls.MaterialSingleLineTextField();
            dgvVendedores = new DataGridView();

            // Configuración de la pestaña de vendedores
            tabVendedores.Controls.Add(materialLabel9);
            tabVendedores.Controls.Add(btnDeleteVendedor);
            tabVendedores.Controls.Add(btnAddVendedor);
            tabVendedores.Controls.Add(txtNombreVendedor);
            tabVendedores.Controls.Add(dgvVendedores);
            tabVendedores.Location = new Point(4, 24);
            tabVendedores.Name = "tabVendedores";
            tabVendedores.Padding = new Padding(3);
            tabVendedores.Size = new Size(909, 399);
            tabVendedores.TabIndex = 2;
            tabVendedores.Text = "Vendedores";

            // materialLabel9
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 11F);
            materialLabel9.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel9.Location = new Point(607, 35);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(63, 19);
            materialLabel9.TabIndex = 5;
            materialLabel9.Text = "Nombre";

            // btnDeleteVendedor
            btnDeleteVendedor.AutoSize = true;
            btnDeleteVendedor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteVendedor.Depth = 0;
            btnDeleteVendedor.Icon = null;
            btnDeleteVendedor.Location = new Point(735, 231);
            btnDeleteVendedor.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteVendedor.Name = "btnDeleteVendedor";
            btnDeleteVendedor.Primary = true;
            btnDeleteVendedor.Size = new Size(83, 36);
            btnDeleteVendedor.TabIndex = 4;
            btnDeleteVendedor.Text = "Eliminar";
            btnDeleteVendedor.Click += btnDeleteVendedor_Click;

            // btnAddVendedor
            btnAddVendedor.AutoSize = true;
            btnAddVendedor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddVendedor.Depth = 0;
            btnAddVendedor.Icon = null;
            btnAddVendedor.Location = new Point(607, 231);
            btnAddVendedor.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddVendedor.Name = "btnAddVendedor";
            btnAddVendedor.Primary = true;
            btnAddVendedor.Size = new Size(83, 36);
            btnAddVendedor.TabIndex = 3;
            btnAddVendedor.Text = "Agregar";
            btnAddVendedor.Click += btnAddVendedor_Click;

            // txtNombreVendedor
            txtNombreVendedor.Depth = 0;
            txtNombreVendedor.Hint = "";
            txtNombreVendedor.Location = new Point(607, 58);
            txtNombreVendedor.MaxLength = 32767;
            txtNombreVendedor.MouseState = MaterialSkin.MouseState.HOVER;
            txtNombreVendedor.Name = "txtNombreVendedor";
            txtNombreVendedor.PasswordChar = '\0';
            txtNombreVendedor.SelectedText = "";
            txtNombreVendedor.SelectionLength = 0;
            txtNombreVendedor.SelectionStart = 0;
            txtNombreVendedor.Size = new Size(233, 23);
            txtNombreVendedor.TabIndex = 1;
            txtNombreVendedor.UseSystemPasswordChar = false;

            // dgvVendedores
            dgvVendedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendedores.Location = new Point(7, 7);
            dgvVendedores.Name = "dgvVendedores";
            dgvVendedores.Size = new Size(583, 383);
            dgvVendedores.TabIndex = 0;
            dgvVendedores.CellEndEdit += dgvVendedores_CellEndEdit;

            // Agrega la pestaña al tabControl2
            tabControl2.Controls.Add(tabVendedores);
        }

        #endregion
        private TabPage tabVendedores;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialRaisedButton btnDeleteVendedor;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddVendedor;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreVendedor;
        private DataGridView dgvVendedores;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLogin;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private MaterialSkin.Controls.MaterialRaisedButton btnLogin;
        private System.Windows.Forms.TabPage tabMain;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
        private MaterialSkin.Controls.MaterialRaisedButton btnBack;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabClientes;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton btnDeleteCliente;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddCliente;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTelefonoCliente;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreCliente;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.TabPage tabCilindros;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialRaisedButton btnDeleteCilindro;
        private MaterialSkin.Controls.MaterialRaisedButton btnToggleDisponibilidad;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddCilindro;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPesoInicial;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNumeroCilindro;
        private System.Windows.Forms.DataGridView dgvCilindros;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrecioGramo22;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrecioGramo222;
    }
}