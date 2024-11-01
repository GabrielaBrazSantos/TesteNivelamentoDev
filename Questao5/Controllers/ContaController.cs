
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers;
using Questao5.Controllers.Tools;

namespace Questao5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        /// <summary>
        /// Cria Movimento na Conta Corrente
        /// </summary>
        /// <returns>Retorna o Resultado da Requisição</returns>
        /// <response code="200">Retorna o Resultado da Requisição</response>
        /// <response code="400">Retorna mensagem informando o erro da requisição. Todos os campos são obrigatórios. Tipo de Movimento D para Débito ou C para Crédito.</response>        
        [HttpPost("Movimento/")]
        
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status400BadRequest)]                   
        public async Task<ActionResult> Movimento([FromBody] MovimentoRequest command, [FromServices] MovimentoHandler handler)
        {
            return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
        }

        /// <summary>
        /// Saldo da Conta Corrente
        /// </summary>
        /// <returns>Retorna o Resultado da Requisição</returns>
        /// <response code="200">Retorna Dados da Conta: Número da Conta, Titular e Saldo</response>
        /// <response code="400">Retorna mensagem informando o erro da requisição. Somente contas ativas são validas.</response>        
        [HttpGet("Saldo/{NumeroConta}")]

        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Saldo(int NumeroConta, [FromServices] SaldoHandler handler)
        {
            SaldoRequest command = new SaldoRequest(NumeroConta);
            return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
        }
    }
}
