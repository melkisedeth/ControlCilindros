namespace ControlCilindros
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvHistorialR22;
        private DataGridView dgvHistorialR10;
        private DataGridView dataGridViewR134;
        private Label lblCilindros;
        private Label label1;
        private Label label2;
        private Label label3;

        // Labels para estadísticas de R22
        private Label lblR22TotalConsumo;
        private Label lblR22TotalIngresos;
        private Label lblR22Transacciones;
        private Label lblR22PromedioConsumo;

        // Labels para estadísticas de R410
        private Label lblR410TotalConsumo;
        private Label lblR410TotalIngresos;
        private Label lblR410Transacciones;
        private Label lblR410PromedioConsumo;

        // Labels para estadísticas de R134
        private Label lblR134TotalConsumo;
        private Label lblR134TotalIngresos;
        private Label lblR134Transacciones;
        private Label lblR134PromedioConsumo;

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
            dgvHistorialR22 = new DataGridView();
            lblCilindros = new Label();
            label1 = new Label();
            label2 = new Label();
            dgvHistorialR10 = new DataGridView();
            dataGridViewR134 = new DataGridView();
            label3 = new Label();
            lblR22TotalConsumo = new Label();
            lblR22TotalIngresos = new Label();
            lblR22Transacciones = new Label();
            lblR22PromedioConsumo = new Label();
            lblR410TotalConsumo = new Label();
            lblR410TotalIngresos = new Label();
            lblR410Transacciones = new Label();
            lblR410PromedioConsumo = new Label();
            lblR134TotalConsumo = new Label();
            lblR134TotalIngresos = new Label();
            lblR134Transacciones = new Label();
            lblR134PromedioConsumo = new Label();
            reporteCilindro = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialR22).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialR10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewR134).BeginInit();
            SuspendLayout();
            // 
            // dgvHistorialR22
            // 
            dgvHistorialR22.Location = new Point(12, 100);
            dgvHistorialR22.Name = "dgvHistorialR22";
            dgvHistorialR22.Size = new Size(1293, 150);
            dgvHistorialR22.TabIndex = 0;
            dgvHistorialR22.CellContentClick += dgvCilindros_CellContentClick;
            // 
            // lblCilindros
            // 
            lblCilindros.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCilindros.Location = new Point(467, 9);
            lblCilindros.Name = "lblCilindros";
            lblCilindros.Size = new Size(276, 23);
            lblCilindros.TabIndex = 1;
            lblCilindros.Text = "Historial de transacciones realizadas";
            // 
            // label1
            // 
            label1.BackColor = Color.GreenYellow;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(49, 23);
            label1.TabIndex = 2;
            label1.Text = "R22";
            // 
            // label2
            // 
            label2.BackColor = Color.Pink;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 270);
            label2.Name = "label2";
            label2.Size = new Size(49, 21);
            label2.TabIndex = 3;
            label2.Text = "R410";
            // 
            // dgvHistorialR10
            // 
            dgvHistorialR10.Location = new Point(12, 300);
            dgvHistorialR10.Name = "dgvHistorialR10";
            dgvHistorialR10.Size = new Size(1293, 150);
            dgvHistorialR10.TabIndex = 4;
            // 
            // dataGridViewR134
            // 
            dataGridViewR134.Location = new Point(12, 500);
            dataGridViewR134.Name = "dataGridViewR134";
            dataGridViewR134.Size = new Size(1293, 150);
            dataGridViewR134.TabIndex = 5;
            // 
            // label3
            // 
            label3.BackColor = Color.SkyBlue;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 470);
            label3.Name = "label3";
            label3.Size = new Size(49, 21);
            label3.TabIndex = 6;
            label3.Text = "R134";
            // 
            // lblR22TotalConsumo
            // 
            lblR22TotalConsumo.AutoSize = true;
            lblR22TotalConsumo.Location = new Point(12, 40);
            lblR22TotalConsumo.Name = "lblR22TotalConsumo";
            lblR22TotalConsumo.Size = new Size(94, 15);
            lblR22TotalConsumo.TabIndex = 7;
            lblR22TotalConsumo.Text = "Consumo Total: ";
            // 
            // lblR22TotalIngresos
            // 
            lblR22TotalIngresos.AutoSize = true;
            lblR22TotalIngresos.Location = new Point(200, 40);
            lblR22TotalIngresos.Name = "lblR22TotalIngresos";
            lblR22TotalIngresos.Size = new Size(97, 15);
            lblR22TotalIngresos.TabIndex = 8;
            lblR22TotalIngresos.Text = "Ingresos Totales: ";
            // 
            // lblR22Transacciones
            // 
            lblR22Transacciones.AutoSize = true;
            lblR22Transacciones.Location = new Point(400, 40);
            lblR22Transacciones.Name = "lblR22Transacciones";
            lblR22Transacciones.Size = new Size(87, 15);
            lblR22Transacciones.TabIndex = 9;
            lblR22Transacciones.Text = "Transacciones: ";
            // 
            // lblR22PromedioConsumo
            // 
            lblR22PromedioConsumo.AutoSize = true;
            lblR22PromedioConsumo.Location = new Point(600, 40);
            lblR22PromedioConsumo.Name = "lblR22PromedioConsumo";
            lblR22PromedioConsumo.Size = new Size(120, 15);
            lblR22PromedioConsumo.TabIndex = 10;
            lblR22PromedioConsumo.Text = "Consumo Promedio: ";
            // 
            // lblR410TotalConsumo
            // 
            lblR410TotalConsumo.AutoSize = true;
            lblR410TotalConsumo.Location = new Point(12, 250);
            lblR410TotalConsumo.Name = "lblR410TotalConsumo";
            lblR410TotalConsumo.Size = new Size(94, 15);
            lblR410TotalConsumo.TabIndex = 11;
            lblR410TotalConsumo.Text = "Consumo Total: ";
            // 
            // lblR410TotalIngresos
            // 
            lblR410TotalIngresos.AutoSize = true;
            lblR410TotalIngresos.Location = new Point(200, 250);
            lblR410TotalIngresos.Name = "lblR410TotalIngresos";
            lblR410TotalIngresos.Size = new Size(97, 15);
            lblR410TotalIngresos.TabIndex = 12;
            lblR410TotalIngresos.Text = "Ingresos Totales: ";
            // 
            // lblR410Transacciones
            // 
            lblR410Transacciones.AutoSize = true;
            lblR410Transacciones.Location = new Point(400, 250);
            lblR410Transacciones.Name = "lblR410Transacciones";
            lblR410Transacciones.Size = new Size(87, 15);
            lblR410Transacciones.TabIndex = 13;
            lblR410Transacciones.Text = "Transacciones: ";
            // 
            // lblR410PromedioConsumo
            // 
            lblR410PromedioConsumo.AutoSize = true;
            lblR410PromedioConsumo.Location = new Point(600, 250);
            lblR410PromedioConsumo.Name = "lblR410PromedioConsumo";
            lblR410PromedioConsumo.Size = new Size(120, 15);
            lblR410PromedioConsumo.TabIndex = 14;
            lblR410PromedioConsumo.Text = "Consumo Promedio: ";
            // 
            // lblR134TotalConsumo
            // 
            lblR134TotalConsumo.AutoSize = true;
            lblR134TotalConsumo.Location = new Point(12, 450);
            lblR134TotalConsumo.Name = "lblR134TotalConsumo";
            lblR134TotalConsumo.Size = new Size(94, 15);
            lblR134TotalConsumo.TabIndex = 15;
            lblR134TotalConsumo.Text = "Consumo Total: ";
            // 
            // lblR134TotalIngresos
            // 
            lblR134TotalIngresos.AutoSize = true;
            lblR134TotalIngresos.Location = new Point(200, 450);
            lblR134TotalIngresos.Name = "lblR134TotalIngresos";
            lblR134TotalIngresos.Size = new Size(97, 15);
            lblR134TotalIngresos.TabIndex = 16;
            lblR134TotalIngresos.Text = "Ingresos Totales: ";
            // 
            // lblR134Transacciones
            // 
            lblR134Transacciones.AutoSize = true;
            lblR134Transacciones.Location = new Point(400, 450);
            lblR134Transacciones.Name = "lblR134Transacciones";
            lblR134Transacciones.Size = new Size(87, 15);
            lblR134Transacciones.TabIndex = 17;
            lblR134Transacciones.Text = "Transacciones: ";
            // 
            // lblR134PromedioConsumo
            // 
            lblR134PromedioConsumo.AutoSize = true;
            lblR134PromedioConsumo.Location = new Point(600, 450);
            lblR134PromedioConsumo.Name = "lblR134PromedioConsumo";
            lblR134PromedioConsumo.Size = new Size(120, 15);
            lblR134PromedioConsumo.TabIndex = 18;
            lblR134PromedioConsumo.Text = "Consumo Promedio: ";
            // 
            // reporteCilindro
            // 
            reporteCilindro.BackColor = SystemColors.InactiveBorder;
            reporteCilindro.Location = new Point(1158, 40);
            reporteCilindro.Name = "reporteCilindro";
            reporteCilindro.Size = new Size(132, 27);
            reporteCilindro.TabIndex = 21;
            reporteCilindro.Text = "Reporte por cilindro";
            reporteCilindro.UseVisualStyleBackColor = false;
            reporteCilindro.Click += reporteCilindro_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 673);
            Controls.Add(reporteCilindro);
            Controls.Add(lblR134PromedioConsumo);
            Controls.Add(lblR134Transacciones);
            Controls.Add(lblR134TotalIngresos);
            Controls.Add(lblR134TotalConsumo);
            Controls.Add(lblR410PromedioConsumo);
            Controls.Add(lblR410Transacciones);
            Controls.Add(lblR410TotalIngresos);
            Controls.Add(lblR410TotalConsumo);
            Controls.Add(lblR22PromedioConsumo);
            Controls.Add(lblR22Transacciones);
            Controls.Add(lblR22TotalIngresos);
            Controls.Add(lblR22TotalConsumo);
            Controls.Add(label3);
            Controls.Add(dataGridViewR134);
            Controls.Add(dgvHistorialR10);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblCilindros);
            Controls.Add(dgvHistorialR22);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorialR22).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialR10).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewR134).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button reporteCilindro;
    }
}