using System.Collections.Generic;
using TabelaFipe.Base;

namespace TabelaFipe
{
    public class Modelo : BaseEntidade
    {
        public string Descricao { get; set; }

        public int Potencia { get; set; }

        public string Combustivel { get; set; }

        public int QuantPortas { get; set; }

        public Marca Marca { get; private set; }

        public int Marca_Id { get; set; }

        public List<AnoModelo> AnosModelos { get; set; }
    }
}