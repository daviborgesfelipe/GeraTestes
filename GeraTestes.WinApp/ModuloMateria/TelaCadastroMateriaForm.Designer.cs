namespace GeraTestes.WinApp.ModuloMateria
{
    partial class TelaCadastroMateriaForm
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
            btnCancelar = new Button();
            btnGravar = new Button();
            txtNome = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cmbDisciplinas = new ComboBox();
            label4 = new Label();
            cmbSeries = new ComboBox();
            label1 = new Label();
            txtId = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(260, 157);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(179, 157);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(100, 45);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(236, 23);
            txtNome.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 48);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 0;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 78);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 0;
            label3.Text = "Disciplina:";
            // 
            // cmbDisciplinas
            // 
            cmbDisciplinas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplinas.FormattingEnabled = true;
            cmbDisciplinas.Location = new Point(100, 74);
            cmbDisciplinas.Name = "cmbDisciplinas";
            cmbDisciplinas.Size = new Size(104, 23);
            cmbDisciplinas.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 107);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 0;
            label4.Text = "Série:";
            // 
            // cmbSeries
            // 
            cmbSeries.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeries.FormattingEnabled = true;
            cmbSeries.Location = new Point(100, 103);
            cmbSeries.Name = "cmbSeries";
            cmbSeries.Size = new Size(104, 23);
            cmbSeries.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 19);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(100, 16);
            txtId.Name = "txtId";
            txtId.Size = new Size(60, 23);
            txtId.TabIndex = 1;
            // 
            // TelaCadastroMateriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 220);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(cmbSeries);
            Controls.Add(label4);
            Controls.Add(cmbDisciplinas);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Name = "TelaCadastroMateriaForm";
            Text = "Cadastro de Matérias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
    }
}