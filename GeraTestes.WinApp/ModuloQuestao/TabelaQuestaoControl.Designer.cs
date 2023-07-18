namespace GeraTestes.WinApp.ModuloQuestao
{
    partial class TabelaQuestaoControl
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
            tabelaQuestao = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaQuestao).BeginInit();
            SuspendLayout();
            // 
            // tabelaQuestao
            // 
            tabelaQuestao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaQuestao.Dock = DockStyle.Fill;
            tabelaQuestao.Location = new Point(0, 0);
            tabelaQuestao.Name = "tabelaQuestao";
            tabelaQuestao.RowTemplate.Height = 25;
            tabelaQuestao.Size = new Size(150, 150);
            tabelaQuestao.TabIndex = 0;
            // 
            // TabelaQuestaoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaQuestao);
            Name = "TabelaQuestaoControl";
            ((System.ComponentModel.ISupportInitialize)tabelaQuestao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaQuestao;
    }
}
