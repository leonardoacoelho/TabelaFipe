using System;
using TabelaFipe.BLL.Base;
using TabelaFipe.DAL;

namespace TabelaFipe.BLL
{
    public class MarcaBO : BaseBO<Marca, MarcaDAO>
    {
        public override void Salvar(Marca entidade)
        {
            try
            {
                if (string.IsNullOrEmpty(entidade.Nome))
                    throw new ArgumentNullException();

                base.Salvar(entidade);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
