namespace SistemaIncidenciasAguaPotable.Formularios
{
    partial class FrmMisIncidencias
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
            this.dgvIncidencias = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ColumID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumFechaReporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIncidencias
            // 
            this.dgvIncidencias.AllowUserToAddRows = false;
            this.dgvIncidencias.AllowUserToDeleteRows = false;
            this.dgvIncidencias.AllowUserToResizeColumns = false;
            this.dgvIncidencias.AllowUserToResizeRows = false;
            this.dgvIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumID,
            this.ColumFechaReporte,
            this.ColumTipo,
            this.ColumSector,
            this.ColumDescripcion,
            this.ColumEstado});
            this.dgvIncidencias.Location = new System.Drawing.Point(43, 37);
            this.dgvIncidencias.Name = "dgvIncidencias";
            this.dgvIncidencias.RowHeadersWidth = 51;
            this.dgvIncidencias.RowTemplate.Height = 24;
            this.dgvIncidencias.Size = new System.Drawing.Size(802, 429);
            this.dgvIncidencias.TabIndex = 0;
            this.dgvIncidencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumID
            // 
            this.ColumID.HeaderText = "ID";
            this.ColumID.MinimumWidth = 6;
            this.ColumID.Name = "ColumID";
            this.ColumID.ReadOnly = true;
            this.ColumID.Width = 125;
            // 
            // ColumFechaReporte
            // 
            this.ColumFechaReporte.HeaderText = "Fecha Reporte";
            this.ColumFechaReporte.MinimumWidth = 6;
            this.ColumFechaReporte.Name = "ColumFechaReporte";
            this.ColumFechaReporte.ReadOnly = true;
            this.ColumFechaReporte.Width = 125;
            // 
            // ColumTipo
            // 
            this.ColumTipo.HeaderText = "Tipo";
            this.ColumTipo.MinimumWidth = 6;
            this.ColumTipo.Name = "ColumTipo";
            this.ColumTipo.ReadOnly = true;
            this.ColumTipo.Width = 125;
            // 
            // ColumSector
            // 
            this.ColumSector.HeaderText = "Sector";
            this.ColumSector.MinimumWidth = 6;
            this.ColumSector.Name = "ColumSector";
            this.ColumSector.ReadOnly = true;
            this.ColumSector.Width = 125;
            // 
            // ColumDescripcion
            // 
            this.ColumDescripcion.HeaderText = "Descripcion";
            this.ColumDescripcion.MinimumWidth = 6;
            this.ColumDescripcion.Name = "ColumDescripcion";
            this.ColumDescripcion.ReadOnly = true;
            this.ColumDescripcion.Width = 125;
            // 
            // ColumEstado
            // 
            this.ColumEstado.HeaderText = "Estado";
            this.ColumEstado.MinimumWidth = 6;
            this.ColumEstado.Name = "ColumEstado";
            this.ColumEstado.ReadOnly = true;
            this.ColumEstado.Width = 125;
            // 
            // FrmMisIncidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 503);
            this.Controls.Add(this.dgvIncidencias);
            this.Name = "FrmMisIncidencias";
            this.Text = "FrmMisIncidencias";
            this.Load += new System.EventHandler(this.FrmMisIncidencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncidencias;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumFechaReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumSector;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumEstado;
    }
}