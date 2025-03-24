namespace ControlCilindros
{
    partial class Form3
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
            dgvHistorialR10 = new DataGridView();
            cbCilindros = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialR10).BeginInit();
            SuspendLayout();
            // 
            // dgvHistorialR10
            // 
            dgvHistorialR10.Location = new Point(12, 105);
            dgvHistorialR10.Name = "dgvHistorialR10";
            dgvHistorialR10.Size = new Size(1293, 150);
            dgvHistorialR10.TabIndex = 5;
            dgvHistorialR10.CellContentClick += dgvHistorialR10_CellContentClick;
            // 
            // cbCilindros
            // 
            cbCilindros.Location = new Point(12, 44);
            cbCilindros.Name = "cbCilindros";
            cbCilindros.Size = new Size(150, 23);
            cbCilindros.TabIndex = 19;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 451);
            Controls.Add(cbCilindros);
            Controls.Add(dgvHistorialR10);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorialR10).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHistorialR10;
        private ComboBox cbCilindros;
    }
}