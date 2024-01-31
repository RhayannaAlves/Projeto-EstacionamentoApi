namespace EstacionamentoAPI.Model
{
     public class Estacionamento : IEstacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo(string placa)
        {
            veiculos.Add(placa);
        }

        public decimal RemoverVeiculo(string placa, int horas)
        {
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                decimal valorTotal = (precoInicial + (precoPorHora * horas));

                veiculos.Remove(placa);
                return valorTotal;
            }
            return 0;
        }

        public string[] ListarVeiculos()
        {
            return veiculos.ToArray();
        }
    }
}