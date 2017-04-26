using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabelaFipe.BLL;
using TabelaFipe.UI.Reports;

namespace TabelaFipe.UI
{
    public partial class ListaMarcasForm : Form
    {
        MarcaBO bo;

        Marca _marca;

        public ListaMarcasForm()
        {
            InitializeComponent();

            bo = new MarcaBO();
        }

        public ListaMarcasForm(Marca marca) : this()
        {
            _marca = marca;
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            var form = new CadastroMarcasForm(this, _marca);
            form.Show();
        }

        private void ListaMarcasForm_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        public void AtualizarGrid()
        {

            bsMarcas.DataSource = bo.Listar();
        }

        private void dgvMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dgvMarcas.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                try
                {
                    var marca = bo.Encontrar(id);

                    if (marca == null)
                        MessageBox.Show("Marca não encontrada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        var form = new CadastroMarcasForm(this, marca);
                        form.Show();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void dgvMarcas_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                var row = dgvMarcas.CurrentRow;

                if(row == null)
                {
                    MessageBox.Show("Nenhum registro foi selecionado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var id = row.Cells["Id"].Value.ToString().ToInt();
                    var marca = row.Cells["Nome"].Value.ToString();

                    var result = MessageBox.Show($"Tem certeza que deseja remover {marca}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        bo.Remover(id);

                        MessageBox.Show("Removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AtualizarGrid();
                    }
                }
            }
        }

        private void relatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TabelaFipeReportForm();
            form.Show();
        }
    }
}
