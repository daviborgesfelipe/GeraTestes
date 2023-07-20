namespace GeraTestes.WinApp.ModuloQuestao
{
    partial class TelaCadastroQuestaoForm
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
            cmbMaterias = new ComboBox();
            label4 = new Label();
            cmbDisciplinas = new ComboBox();
            label3 = new Label();
            txtEnunciado = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            listAlternativas = new CheckedListBox();
            toolStrip1 = new ToolStrip();
            btnRemover = new ToolStripButton();
            btnAdicionar = new Button();
            txtResposta = new TextBox();
            label5 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            txtId = new TextBox();
            label1 = new Label();
            label6 = new Label();
            chkJaUtilizada = new CheckBox();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbMaterias
            // 
            cmbMaterias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterias.FormattingEnabled = true;
            cmbMaterias.Location = new Point(85, 86);
            cmbMaterias.Name = "cmbMaterias";
            cmbMaterias.Size = new Size(217, 23);
            cmbMaterias.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 89);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 0;
            label4.Text = "Matéria:";
            // 
            // cmbDisciplinas
            // 
            cmbDisciplinas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplinas.FormattingEnabled = true;
            cmbDisciplinas.Location = new Point(85, 57);
            cmbDisciplinas.Name = "cmbDisciplinas";
            cmbDisciplinas.Size = new Size(217, 23);
            cmbDisciplinas.TabIndex = 2;
            cmbDisciplinas.SelectedIndexChanged += cmbDisciplinas_Changed;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 61);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 0;
            label3.Text = "Disciplina:";
            // 
            // txtEnunciado
            // 
            txtEnunciado.Location = new Point(85, 133);
            txtEnunciado.Multiline = true;
            txtEnunciado.Name = "txtEnunciado";
            txtEnunciado.Size = new Size(389, 46);
            txtEnunciado.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 135);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 0;
            label2.Text = "Enunciado:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listAlternativas);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Location = new Point(18, 247);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(456, 255);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alternativas";
            // 
            // listAlternativas
            // 
            listAlternativas.CheckOnClick = true;
            listAlternativas.FormattingEnabled = true;
            listAlternativas.Location = new Point(8, 70);
            listAlternativas.Name = "listAlternativas";
            listAlternativas.Size = new Size(442, 166);
            listAlternativas.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnRemover });
            toolStrip1.Location = new Point(3, 19);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(450, 40);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnRemover
            // 
            btnRemover.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnRemover.ImageTransparentColor = Color.Magenta;
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(58, 37);
            btnRemover.Text = "Remover";
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(381, 184);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(93, 46);
            btnAdicionar.TabIndex = 6;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // txtResposta
            // 
            txtResposta.Location = new Point(85, 185);
            txtResposta.Multiline = true;
            txtResposta.Name = "txtResposta";
            txtResposta.Size = new Size(290, 45);
            txtResposta.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 200);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 0;
            label5.Text = "Resposta:";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(399, 515);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(318, 515);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 7;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(85, 28);
            txtId.Name = "txtId";
            txtId.Size = new Size(60, 23);
            txtId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 31);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(108, 112);
            label6.Name = "label6";
            label6.Size = new Size(154, 15);
            label6.TabIndex = 13;
            label6.Text = "Já utilizada em algum teste?";
            // 
            // chkJaUtilizada
            // 
            chkJaUtilizada.AutoSize = true;
            chkJaUtilizada.Enabled = false;
            chkJaUtilizada.Location = new Point(86, 113);
            chkJaUtilizada.Name = "chkJaUtilizada";
            chkJaUtilizada.Size = new Size(15, 14);
            chkJaUtilizada.TabIndex = 12;
            chkJaUtilizada.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroQuestaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 572);
            Controls.Add(label6);
            Controls.Add(chkJaUtilizada);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(btnAdicionar);
            Controls.Add(cmbMaterias);
            Controls.Add(txtResposta);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(cmbDisciplinas);
            Controls.Add(label3);
            Controls.Add(txtEnunciado);
            Controls.Add(label2);
            Name = "TelaCadastroQuestaoForm";
            Text = "Cadastro de Questões";
            groupBox1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEnunciado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtResposta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRemover;
        private System.Windows.Forms.ComboBox cmbAlternativaCorreta;
        private System.Windows.Forms.CheckedListBox listAlternativas;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private Label label6;
        private CheckBox chkJaUtilizada;
    }
}