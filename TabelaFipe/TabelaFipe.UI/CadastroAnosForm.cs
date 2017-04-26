using System;
using System.Windows.Forms;
using TabelaFipe.BLL;

namespace TabelaFipe.UI
{
    public partial class CadastroAnosForm : Form
    {
        AnoModeloBO bo;

        CadastroModelosForm _cadModelos;

        AnoModelo _ano;

        Marca _marca;

        Modelo _modelo;

        public CadastroAnosForm(Modelo modelo, CadastroModelosForm cadastro)
        {
            InitializeComponent();

            bo = new AnoModeloBO();

            _marca = modelo.Marca;
            _modelo = modelo;
            _cadModelos = cadastro;
        }

        public CadastroAnosForm(Modelo modelo, CadastroModelosForm cadastro, AnoModelo ano) : this(modelo, cadastro)
        {
            _ano = ano;
        }

        private void menuSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _ano = new AnoModelo
                {
                    Id = txtId.Text.ToInt(),
                    Ano = txtAno.Text.ToInt(),
                    Valor = txtValor.Text.ToDouble(),
                    Modelo_Id = _modelo.Id
                };

                bo.Salvar(_ano);

                MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
                _cadModelos.AtualizarGrid();

            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Os Campos em negrito são obrigatórios e devem ser preenchidos corretamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void menuRemover_Click(object sender, EventArgs e)
        {
            var id = txtId.Text.ToInt();

            var result = MessageBox.Show($"Tem certeza que deseja remover {txtAno.Text}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bo.Remover(id);

                MessageBox.Show("Removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _cadModelos.AtualizarGrid();
                Hide();
            }
        }

        private void CadastroAnosForm_Load(object sender, EventArgs e)
        {
            if (_ano != null)
            {
                txtId.Text = _ano.Id.ToString();
                txtAno.Text = _ano.Ano.ToString();
                txtValor.Text = _ano.Valor.ToString();
            }
        }
    }
}