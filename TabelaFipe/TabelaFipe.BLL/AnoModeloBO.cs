using TabelaFipe.BLL.Base;
using TabelaFipe.DAL;
using System;

namespace TabelaFipe.BLL
{
    public class AnoModeloBO : BaseBO<AnoModelo, AnoModeloDAO>
    {
        public override void Salvar(AnoModelo entidade)
        {
            try
            {
                if (entidade.Ano <= 0|| entidade.Valor <= 0)
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
