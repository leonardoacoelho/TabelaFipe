using TabelaFipe.BLL.Base;
using TabelaFipe.DAL;
using System;
using System.Collections.Generic;
using TabelaFipe.DAL.Context;
using System.Linq;

namespace TabelaFipe.BLL
{
    public class ModeloBO : BaseBO<Modelo, ModeloDAO>
    {
        public override void Salvar(Modelo entidade)
        {
            try
            {
                if (string.IsNullOrEmpty(entidade.Descricao) || string.IsNullOrEmpty(entidade.Combustivel))
                    throw new ArgumentNullException();

                if (entidade.Potencia == null || entidade.QuantPortas == null)
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
