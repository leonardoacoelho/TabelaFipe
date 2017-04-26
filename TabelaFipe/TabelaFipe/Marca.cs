using System.Collections.Generic;
using TabelaFipe.Base;

namespace TabelaFipe
{
    public class Marca : BaseEntidade
    {
        public string Nome { get; set; }

        public List<Modelo> Modelos { get; set; }
    }
}
