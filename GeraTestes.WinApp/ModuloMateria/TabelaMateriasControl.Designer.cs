namespace GeraTestes.WinApp.ModuloMateria
{
    partial class TabelaMateriasControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabelaMaterias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaMaterias).BeginInit();
            SuspendLayout();
            // 
            // tabelaMaterias
            // 
            tabelaMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaMaterias.Dock = DockStyle.Fill;
            tabelaMaterias.Location = new Point(0, 0);
            tabelaMaterias.Name = "tabelaMaterias";
            tabelaMaterias.RowTemplate.Height = 25;
            tabelaMaterias.Size = new Size(150, 150);
            tabelaMaterias.TabIndex = 0;
            // 
            // TabelaMateriasControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaMaterias);
            Name = "TabelaMateriasControl";
            ((System.ComponentModel.ISupportInitialize)tabelaMaterias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaMaterias;
    }
}
