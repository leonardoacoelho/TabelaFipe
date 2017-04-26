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

namespace TabelaFipe.UI
{
    public partial class CadastroModelosForm : Form
    {
        CadastroMarcasForm _cadMarcas;

        ModeloBO bo;

        Modelo _modelo;

        Marca _marca;

        public CadastroModelosForm(Marca marca, CadastroMarcasForm cadastro)
        {
            InitializeComponent();

            bo = new ModeloBO();
            _marca = marca;
            _cadMarcas = cadastro;
        }

        public CadastroModelosForm(Marca marca, CadastroMarcasForm cadastro, Modelo modelo) : this(marca, cadastro)
        {
            _modelo = modelo;
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            var form = new CadastroAnosForm(_modelo, this);
            form.Show();
        }

        private void menuSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _modelo = new Modelo
                {
                    Id = txtId.Text.ToInt(),
                    Descricao = txtDescricao.Text,
                    Potencia = txtPotencia.Text.ToInt(),
                    Combustivel = txtCombustivel.Text,
                    QuantPortas = txtPortas.Text.ToInt(),
                    Marca_Id = _marca.Id
                };

                bo.Salvar(_modelo);

                picModelo.Image.Exportar("Modelo", _modelo.Id);

                MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
                _cadMarcas.AtualizarGrid();

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

        private void menuRemover_Click(object sender, EventArgs e)
        {
            var id = txtId.Text.ToInt();

            var result = MessageBox.Show($"Tem certeza que deseja remover {txtDescricao.Text}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                RemoverImagem();

                bo.Remover(id);

                MessageBox.Show("Removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _cadMarcas.AtualizarGrid();
                Hide();
            }
        }

        private void CadastroModelosForm_Load(object sender, EventArgs e)
        {
            if (_modelo != null)
            {
                txtId.Text = _modelo.Id.ToString();
                txtDescricao.Text = _modelo.Descricao;
                txtPotencia.Text = _modelo.Potencia.ToString();
                txtCombustivel.Text = _modelo.Combustivel.ToString();
                txtPortas.Text = _modelo.QuantPortas.ToString();
                txtMarcaId.Text = _modelo.Marca_Id.ToString();
                txtMarca.Text = _marca.Nome;

                picModelo.Image = ImagemBo.Importar("Modelo", _modelo.Id);

                AtualizarGrid();
                menuRemover.Visible = true;
                menuAdd.Visible = true;
            }
            else
            {
                txtMarca.Text = _marca.Nome;
                menuRemover.Visible = false;
                menuAdd.Visible = false;
            }

        }

        public void AtualizarGrid()
        {
            var anosBo = new AnoModeloBO();
            bsAnos.DataSource = anosBo.Listar(x => x.Modelo_Id == _modelo.Id);
        }

        private void dgvAnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dgvAnos.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                try
                {
                    var anoBo = new AnoModeloBO();
                    var ano = anoBo.Encontrar(id);

                    if (ano == null)
                        MessageBox.Show("Ano não encontrado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        var form = new CadastroAnosForm(_modelo, this, ano);
                        form.Show();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnRemoverImage_Click(object sender, EventArgs e)
        {
            RemoverImagem();
        }

        private void RemoverImagem()
        {
            picModelo.Image = null;
            ImagemBo.Delete("Modelo", _modelo.Id);
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            if (ofdImagem.ShowDialog() == DialogResult.OK)
            {
                picModelo.Image = new Bitmap(ofdImagem.FileName);
            }
        }
    }
}
