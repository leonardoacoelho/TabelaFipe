using TabelaFipe.Base;

namespace TabelaFipe
{
    public class AnoModelo : BaseEntidade
    {
        public int Ano { get; set; }

        public double Valor { get; set; }

        public Modelo Modelo { get; private set; }

        public int Modelo_Id { get; set; }
    }
}