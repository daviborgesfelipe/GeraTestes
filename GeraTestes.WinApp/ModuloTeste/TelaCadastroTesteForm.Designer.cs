namespace GeraTestes.WinApp.ModuloTeste
{
    partial class TelaCadastroTesteForm
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
            label2 = new Label();
            txtTitulo = new TextBox();
            label5 = new Label();
            chkProvao = new CheckBox();
            groupBox1 = new GroupBox();
            toolStrip1 = new ToolStrip();
            btnSortear = new ToolStripButton();
            listQuestoes = new ListBox();
            btnCancelar = new Button();
            btnGravar = new Button();
            txtQtdQuestoes = new NumericUpDown();
            label1 = new Label();
            txtId = new TextBox();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtQtdQuestoes).BeginInit();
            SuspendLayout();
            // 
            // cmbMaterias
            // 
            cmbMaterias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterias.FormattingEnabled = true;
            cmbMaterias.Location = new Point(102, 148);
            cmbMaterias.Name = "cmbMaterias";
            cmbMaterias.Size = new Size(324, 23);
            cmbMaterias.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 151);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 31;
            label4.Text = "Matéria:";
            // 
            // cmbDisciplinas
            // 
            cmbDisciplinas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplinas.FormattingEnabled = true;
            cmbDisciplinas.Location = new Point(102, 89);
            cmbDisciplinas.Name = "cmbDisciplinas";
            cmbDisciplinas.Size = new Size(167, 23);
            cmbDisciplinas.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 93);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 29;
            label3.Text = "Disciplina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(278, 93);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 26;
            label2.Text = "Qtd. Questões:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(102, 55);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(324, 23);
            txtTitulo.TabIndex = 34;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(53, 57);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 33;
            label5.Text = "Título:";
            // 
            // chkProvao
            // 
            chkProvao.AutoSize = true;
            chkProvao.Location = new Point(99, 121);
            chkProvao.Margin = new Padding(3, 2, 3, 2);
            chkProvao.Name = "chkProvao";
            chkProvao.RightToLeft = RightToLeft.Yes;
            chkProvao.Size = new Size(71, 19);
            chkProvao.TabIndex = 38;
            chkProvao.Text = "? Provão";
            chkProvao.TextAlign = ContentAlignment.MiddleCenter;
            chkProvao.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Controls.Add(listQuestoes);
            groupBox1.Location = new Point(12, 188);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(414, 259);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões Selecionadas:";
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnSortear });
            toolStrip1.Location = new Point(3, 18);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(408, 50);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnSortear
            // 
            btnSortear.Image = Properties.Resources.format_list_numbered_FILL0_wght400_GRAD0_opsz24;
            btnSortear.ImageScaling = ToolStripItemImageScaling.None;
            btnSortear.ImageTransparentColor = Color.Magenta;
            btnSortear.Margin = new Padding(5);
            btnSortear.Name = "btnSortear";
            btnSortear.Padding = new Padding(5);
            btnSortear.Size = new Size(82, 40);
            btnSortear.Text = "Sortear";
            // 
            // listQuestoes
            // 
            listQuestoes.Dock = DockStyle.Bottom;
            listQuestoes.FormattingEnabled = true;
            listQuestoes.ItemHeight = 15;
            listQuestoes.Location = new Point(3, 73);
            listQuestoes.Margin = new Padding(3, 2, 3, 2);
            listQuestoes.Name = "listQuestoes";
            listQuestoes.Size = new Size(408, 184);
            listQuestoes.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(351, 457);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 41;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(270, 457);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 40;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // txtQtdQuestoes
            // 
            txtQtdQuestoes.Location = new Point(373, 89);
            txtQtdQuestoes.Margin = new Padding(3, 2, 3, 2);
            txtQtdQuestoes.Name = "txtQtdQuestoes";
            txtQtdQuestoes.Size = new Size(53, 23);
            txtQtdQuestoes.TabIndex = 42;
            txtQtdQuestoes.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 29);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 44;
            label1.Text = "Id:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(102, 26);
            txtId.Name = "txtId";
            txtId.Size = new Size(60, 23);
            txtId.TabIndex = 43;
            // 
            // TelaCadastroTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 519);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(txtQtdQuestoes);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(chkProvao);
            Controls.Add(txtTitulo);
            Controls.Add(label5);
            Controls.Add(cmbMaterias);
            Controls.Add(label4);
            Controls.Add(cmbDisciplinas);
            Controls.Add(label3);
            Controls.Add(label2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TelaCadastroTesteForm";
            Text = "Geração de Testes";
            groupBox1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtQtdQuestoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkProvao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSortear;
        private System.Windows.Forms.ListBox listQuestoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.NumericUpDown txtQtdQuestoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
    }
}