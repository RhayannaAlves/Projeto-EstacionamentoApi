using System;
namespace EstacionamentoAPI.Model
{
    public interface IEstacionamento
    {
        void AdicionarVeiculo(string placa);
        decimal RemoverVeiculo(string placa, int horas);
        string[] ListarVeiculos();
    }
}