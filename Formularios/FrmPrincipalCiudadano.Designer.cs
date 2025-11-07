namespace SistemaIncidenciasAguaPotable.Formularios
{
    partial class FrmPrincipalCiudadano
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvIncidencias = new System.Windows.Forms.DataGridView();
            this.ColumId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumFechaReporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumApellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnVerMisIncidencias = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 25);
            this.lblTitulo.TabIndex = 0;
            // 
            // dgvIncidencias
            // 
            this.dgvIncidencias.AllowUserToAddRows = false;
            this.dgvIncidencias.AllowUserToDeleteRows = false;
            this.dgvIncidencias.AllowUserToResizeColumns = false;
            this.dgvIncidencias.AllowUserToResizeRows = false;
            this.dgvIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumId,
            this.ColumFechaReporte,
            this.ColumTipo,
            this.ColumSector,
            this.ColumDescripcion,
            this.ColumEstado,
            this.ColumNombres,
            this.ColumApellidos,
            this.ColumDNI});
            this.dgvIncidencias.Location = new System.Drawing.Point(12, 92);
            this.dgvIncidencias.Name = "dgvIncidencias";
            this.dgvIncidencias.ReadOnly = true;
            this.dgvIncidencias.RowHeadersWidth = 51;
            this.dgvIncidencias.RowTemplate.Height = 24;
            this.dgvIncidencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidencias.Size = new System.Drawing.Size(1170, 415);
            this.dgvIncidencias.TabIndex = 1;
            // 
            // ColumId
            // 
            this.ColumId.HeaderText = "ID";
            this.ColumId.MinimumWidth = 6;
            this.ColumId.Name = "ColumId";
            this.ColumId.ReadOnly = true;
            this.ColumId.Width = 125;
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
            // ColumNombres
            // 
            this.ColumNombres.HeaderText = "Nombres";
            this.ColumNombres.MinimumWidth = 6;
            this.ColumNombres.Name = "ColumNombres";
            this.ColumNombres.ReadOnly = true;
            this.ColumNombres.Width = 125;
            // 
            // ColumApellidos
            // 
            this.ColumApellidos.HeaderText = "Apellidos";
            this.ColumApellidos.MinimumWidth = 6;
            this.ColumApellidos.Name = "ColumApellidos";
            this.ColumApellidos.ReadOnly = true;
            this.ColumApellidos.Width = 125;
            // 
            // ColumDNI
            // 
            this.ColumDNI.HeaderText = "DNI";
            this.ColumDNI.MinimumWidth = 6;
            this.ColumDNI.Name = "ColumDNI";
            this.ColumDNI.ReadOnly = true;
            this.ColumDNI.Width = 125;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(11, 522);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(129, 32);
            this.btnRegistrar.TabIndex = 2;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(170, 522);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(129, 32);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(922, 531);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(129, 32);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnVerMisIncidencias
            // 
            this.btnVerMisIncidencias.Location = new System.Drawing.Point(326, 522);
            this.btnVerMisIncidencias.Name = "btnVerMisIncidencias";
            this.btnVerMisIncidencias.Size = new System.Drawing.Size(179, 32);
            this.btnVerMisIncidencias.TabIndex = 5;
            this.btnVerMisIncidencias.Text = "Historial de reportes";
            this.btnVerMisIncidencias.UseVisualStyleBackColor = true;
            this.btnVerMisIncidencias.Click += new System.EventHandler(this.btnVerMisIncidencias_Click);
            // 
            // FrmPrincipalCiudadano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 590);
            this.Controls.Add(this.btnVerMisIncidencias);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.dgvIncidencias);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmPrincipalCiudadano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipalCiudadano";
            this.Load += new System.EventHandler(this.FrmPrincipalCiudadano_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvIncidencias;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnVerMisIncidencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumFechaReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumSector;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumApellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumDNI;
    }
}