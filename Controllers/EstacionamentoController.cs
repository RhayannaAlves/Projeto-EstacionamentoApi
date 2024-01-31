using System.ComponentModel;
using EstacionamentoAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("/estacionamento")]
    public class EstacionamentoController : ControllerBase
    {
        IEstacionamento estacionamento;

        public EstacionamentoController(IEstacionamento estacionamento)
        {
            this.estacionamento = estacionamento;
        }

        /// Método para inclusão de novo veículo no estacionamento.
        [HttpPost()]
        public ActionResult AdicionarVeiculo(string placa)
        {
            if(placa.Length == 7)
            {
            estacionamento.AdicionarVeiculo(placa.ToUpper());    
            return Ok();
            }
            return BadRequest("Formato de placa incorreto. Deve conter sete caracteres.");
        }


        /// Método para remover um veículo do estacionamento.
        [HttpDelete()]
        public ActionResult<string> RemoverVeiculo(string placa, string totalHoras)
        {
            int horas = int.Parse(totalHoras);
            decimal valorTotal = estacionamento.RemoverVeiculo(placa.ToUpper(), horas);
            if (valorTotal == 0)
            {
                return "Veículo não está no estacionamento.";
            }
            return ($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}.");
        }

        // Método para listar os veículos
        [HttpGet()]
        public ActionResult<string[]> ListarVeiculos()
        {
            return estacionamento.ListarVeiculos();
        }
    }
}