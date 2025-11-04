namespace SistemaIncidenciasAguaPotable.Formularios
{
    partial class FrmPrincipalAdmin
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
            this.ColumID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumFechaReporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumDescripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumApellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizarEstado = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.cboNuevoEstado = new System.Windows.Forms.ComboBox();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 36);
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
            this.ColumID,
            this.ColumFechaReporte,
            this.ColumTipo,
            this.ColumSector,
            this.ColumDescripción,
            this.ColumEstado,
            this.ColumNombres,
            this.ColumApellidos,
            this.ColumDNI});
            this.dgvIncidencias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIncidencias.Location = new System.Drawing.Point(18, 78);
            this.dgvIncidencias.Name = "dgvIncidencias";
            this.dgvIncidencias.RowHeadersWidth = 51;
            this.dgvIncidencias.RowTemplate.Height = 24;
            this.dgvIncidencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidencias.Size = new System.Drawing.Size(1165, 304);
            this.dgvIncidencias.TabIndex = 1;
            this.dgvIncidencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidencias_CellContentClick);
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
            // ColumDescripción
            // 
            this.ColumDescripción.HeaderText = "Descripcion";
            this.ColumDescripción.MinimumWidth = 6;
            this.ColumDescripción.Name = "ColumDescripción";
            this.ColumDescripción.ReadOnly = true;
            this.ColumDescripción.Width = 125;
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
            // btnActualizarEstado
            // 
            this.btnActualizarEstado.Location = new System.Drawing.Point(12, 407);
            this.btnActualizarEstado.Name = "btnActualizarEstado";
            this.btnActualizarEstado.Size = new System.Drawing.Size(180, 37);
            this.btnActualizarEstado.TabIndex = 2;
            this.btnActualizarEstado.Text = "Actualizar Estado";
            this.btnActualizarEstado.UseVisualStyleBackColor = true;
            this.btnActualizarEstado.Click += new System.EventHandler(this.btnActualizarEstado_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(12, 450);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(118, 29);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // cboNuevoEstado
            // 
            this.cboNuevoEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNuevoEstado.FormattingEnabled = true;
            this.cboNuevoEstado.Items.AddRange(new object[] {
            "Pendiente",
            "En proceso",
            "Resuelto"});
            this.cboNuevoEstado.Location = new System.Drawing.Point(210, 414);
            this.cboNuevoEstado.Name = "cboNuevoEstado";
            this.cboNuevoEstado.Size = new System.Drawing.Size(246, 24);
            this.cboNuevoEstado.TabIndex = 5;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(1050, 450);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(133, 29);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FrmPrincipalAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 495);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.cboNuevoEstado);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnActualizarEstado);
            this.Controls.Add(this.dgvIncidencias);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmPrincipalAdmin";
            this.Text = "FrmPrincipalAdmin";
            this.Load += new System.EventHandler(this.FrmPrincipalAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvIncidencias;
        private System.Windows.Forms.Button btnActualizarEstado;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ComboBox cboNuevoEstado;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumFechaReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumSector;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumDescripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumApellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumDNI;
    }
}