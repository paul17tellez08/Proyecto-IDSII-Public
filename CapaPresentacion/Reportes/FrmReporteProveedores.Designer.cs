namespace CapaPresentacion
{
    partial class FrmReporteProveedores
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.spbuscar_proveedor_razon_socialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spbuscar_proveedor_razon_socialTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.spbuscar_proveedor_razon_socialTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spbuscar_proveedor_razon_socialBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "spbuscarproveedorrazonsocial";
            reportDataSource1.Value = this.spbuscar_proveedor_razon_socialBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptProveedor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(970, 474);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spbuscar_proveedor_razon_socialBindingSource
            // 
            this.spbuscar_proveedor_razon_socialBindingSource.DataMember = "spbuscar_proveedor_razon_social";
            this.spbuscar_proveedor_razon_socialBindingSource.DataSource = this.dsPrincipal;
            // 
            // spbuscar_proveedor_razon_socialTableAdapter
            // 
            this.spbuscar_proveedor_razon_socialTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 474);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteProveedores";
            this.Text = "FrmReporteProveedores";
            this.Load += new System.EventHandler(this.FrmReporteProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spbuscar_proveedor_razon_socialBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spbuscar_proveedor_razon_socialBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.spbuscar_proveedor_razon_socialTableAdapter spbuscar_proveedor_razon_socialTableAdapter;
    }
}