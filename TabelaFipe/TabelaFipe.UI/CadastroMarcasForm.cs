using System;
using System.Windows.Forms;
using TabelaFipe.BLL;

namespace TabelaFipe.UI
{
    public partial class CadastroMarcasForm : Form
    {
        MarcaBO bo;

        Marca _marca;

        Modelo _modelo;

        ListaMarcasForm _listaMarcas;

        public CadastroMarcasForm(ListaMarcasForm lista, Marca marca)
        {
            InitializeComponent();

            bo = new MarcaBO();

            _listaMarcas = lista;
            _marca = marca;
        }

        public CadastroMarcasForm(ListaMarcasForm lista, Marca marca, Modelo modelo) : this(lista, marca)
        {
            _modelo = modelo;
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            var form = new CadastroModelosForm(_marca, this);
            form.Show();
        }

        private void menuSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _marca = new Marca
                {
                    Id = txtId.Text.ToInt(),
                    Nome = txtNome.Text
                };

                bo.Salvar(_marca);

                MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _listaMarcas.AtualizarGrid();
                    Hide();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Os Campos em negrito são obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CadastroMarcasForm_Load(object sender, EventArgs e)
        {
            if (_marca != null)
            {
                txtId.Text = _marca.Id.ToString();
                txtNome.Text = _marca.Nome;

                menuRemover.Visible = true;
                menuAdd.Visible = true;
                AtualizarGrid();
            }
            else
            {
                menuRemover.Visible = false;
                menuAdd.Visible = false;
            }

        }

        public void AtualizarGrid()
        {
            var modeloBo = new ModeloBO();
            bsModelos.DataSource = modeloBo.Listar(x => x.Marca_Id == _marca.Id);
        }

        private void menuRemover_Click(object sender, EventArgs e)
        {
            var id = txtId.Text.ToInt();

            var result = MessageBox.Show($"Tem certeza que deseja remover {txtNome.Text}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bo.Remover(id);

                MessageBox.Show("Removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _listaMarcas.AtualizarGrid();
                Hide();
            }
        }

        private void dgvModelos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dgvModelos.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                try
                {
                    var modeloBo = new ModeloBO();
                    var modelo = modeloBo.Encontrar(id);

                    if (modelo == null)
                        MessageBox.Show("Modelo não encontrado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        var form = new CadastroModelosForm(_marca, this, modelo);
                        form.Show();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
