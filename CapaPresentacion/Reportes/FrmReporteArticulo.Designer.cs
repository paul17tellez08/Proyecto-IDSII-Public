namespace CapaPresentacion
{
    partial class FrmReporteArticulo
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
            this.spbuscar_categoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spbuscar_categoriaTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.spbuscar_categoriaTableAdapter();
            this.spbuscar_articulo_nombreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spbuscar_articulo_nombreTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.spbuscar_articulo_nombreTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spbuscar_categoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spbuscar_articulo_nombreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BUSCARARTICULO";
            reportDataSource1.Value = this.spbuscar_articulo_nombreBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptArticulos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(746, 444);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spbuscar_categoriaBindingSource
            // 
            this.spbuscar_categoriaBindingSource.DataMember = "spbuscar_categoria";
            this.spbuscar_categoriaBindingSource.DataSource = this.dsPrincipal;
            // 
            // spbuscar_categoriaTableAdapter
            // 
            this.spbuscar_categoriaTableAdapter.ClearBeforeFill = true;
            // 
            // spbuscar_articulo_nombreBindingSource
            // 
            this.spbuscar_articulo_nombreBindingSource.DataMember = "spbuscar_articulo_nombre";
            this.spbuscar_articulo_nombreBindingSource.DataSource = this.dsPrincipal;
            // 
            // spbuscar_articulo_nombreTableAdapter
            // 
            this.spbuscar_articulo_nombreTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 444);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteArticulo";
            this.Text = ".:: Reporte de Articulos ::.";
            this.Load += new System.EventHandler(this.FrmReporteArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spbuscar_categoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spbuscar_articulo_nombreBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spbuscar_categoriaBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.spbuscar_categoriaTableAdapter spbuscar_categoriaTableAdapter;
        private System.Windows.Forms.BindingSource spbuscar_articulo_nombreBindingSource;
        private dsPrincipalTableAdapters.spbuscar_articulo_nombreTableAdapter spbuscar_articulo_nombreTableAdapter;
    }
}