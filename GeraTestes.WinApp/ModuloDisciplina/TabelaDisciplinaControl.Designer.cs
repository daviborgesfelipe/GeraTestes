namespace GeraTestes.WinApp.ModuloDisciplina
{
    partial class TabelaDisciplinaControl
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
            tabelaDisciplina = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaDisciplina).BeginInit();
            SuspendLayout();
            // 
            // tabelaDisciplina
            // 
            tabelaDisciplina.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaDisciplina.Dock = DockStyle.Fill;
            tabelaDisciplina.Location = new Point(0, 0);
            tabelaDisciplina.Name = "tabelaDisciplina";
            tabelaDisciplina.RowTemplate.Height = 25;
            tabelaDisciplina.Size = new Size(150, 150);
            tabelaDisciplina.TabIndex = 0;
            // 
            // TabelaDisciplinaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaDisciplina);
            Name = "TabelaDisciplinaControl";
            ((System.ComponentModel.ISupportInitialize)tabelaDisciplina).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaDisciplina;
    }
}
