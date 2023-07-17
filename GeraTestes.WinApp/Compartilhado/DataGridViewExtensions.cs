namespace GeraTestes.WinApp.Compartilhado
{
    public static class DataGridViewExtensions
    {
        public static void ConfigurarGridZebrado(this DataGridView tabela)
        {
            Font font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

            DataGridViewCellStyle linhaEscura = new DataGridViewCellStyle
            {
                BackColor = Color.LightGray,
                Font = font,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightYellow,
                SelectionForeColor = Color.Black
            };

            tabela.AlternatingRowsDefaultCellStyle = linhaEscura;

            DataGridViewCellStyle linhaClara = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                Font = font,
                SelectionBackColor = Color.LightYellow,
                SelectionForeColor = Color.Black
            };

            tabela.RowsDefaultCellStyle = linhaClara;
        }

        public static void ConfigurarGridSomenteLeitura(this DataGridView tabela)
        {
            tabela.AllowUserToAddRows = false;
            tabela.AllowUserToDeleteRows = false;

            tabela.BorderStyle = BorderStyle.None;
            tabela.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabela.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;


            tabela.MultiSelect = false;
            tabela.ReadOnly = true;

            tabela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabela.AutoGenerateColumns = false;

            tabela.AllowUserToResizeRows = false;

            tabela.RowsAdded += (sender, e) =>
            {
                tabela.ClearSelection();
            };

            tabela.RowsRemoved += (sender, e) =>
            {
                tabela.ClearSelection();
            };
        }

        public static int SelecionarId(this DataGridView tabela)
        {
            const int firstLine = 0, firstColumn = 0;
            if (tabela.SelectedRows.Count == 0)
                return default;

            object value = tabela.SelectedRows[firstLine].Cells[firstColumn].Value;

            if (value == null)
                return default;

            return Convert.ToInt32(value);
        }
    }
}
