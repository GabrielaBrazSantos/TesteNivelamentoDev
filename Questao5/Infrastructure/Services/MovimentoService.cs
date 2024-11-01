
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Interfaces;
using Questao5.Entities;
using Questao5.Infrastructure.Interfaces;


namespace Questao5.Infrastructure.Services
{
    public class MovimentoService: IMovimentoService
    {
        private readonly IMovimento _repository;
        private List<string> ErrorMessages = new List<string>();
        public MovimentoService(IMovimento repository)
        {
            _repository = repository;            
        }
        public async Task<RequestResult> Add(MovimentoRequest Command)
        {
            var ContaCorrente = _repository.GetContaCorrente(Command.NumeroConta);

            ValidateMovimento(Command);
            ValidaContaCorrente(ContaCorrente);
            
            if (ErrorMessages.Count > 0)
            {
                string detail = string.Empty;
                ErrorMessages.ForEach(error =>
                {
                    detail = $"{detail} {error}";
                }
                );
                
                return new RequestResult().BadRequest(detail);
            }

            Movimento movimento = new Movimento();
            movimento.Id = Guid.NewGuid().ToString();
            movimento.IdContaCorrente = ContaCorrente.Id;
            movimento.DataMovimento = DateTime.Now.ToString();
            movimento.TipoMovimento = Command.TipoMovimento.ToUpper();
            movimento.Valor = Command.Valor;
            await _repository.Add(movimento);

            return new RequestResult().Ok(movimento.Id);
        }

        public async Task<RequestResult> GetSaldo(SaldoRequest Command)
        {
            
            if (!Command.IsValid)
            {
                return new RequestResult().BadRequest("INVALID_ACCOUNT");
            }

            var ContaCorrente = _repository.GetContaCorrente(Command.NumeroConta);
            ValidaContaCorrente(ContaCorrente);

            if (ErrorMessages.Count > 0)
            {
                string detail = string.Empty;
                ErrorMessages.ForEach(error =>
                {
                    detail = $"{detail} {error}";
                }
                );

                return new RequestResult().BadRequest(detail);
            }

            SaldoResponse saldoResponse = new SaldoResponse();
            saldoResponse.NumeroConta = ContaCorrente.Numero;
            saldoResponse.Nome = ContaCorrente.Nome;
            saldoResponse.DataRespostaConsulta = DateTime.Now;
            saldoResponse.Valor = _repository.GetSaldo(ContaCorrente.Id);
            
            return new RequestResult().Ok(saldoResponse);
        }

        private void ValidateMovimento(MovimentoRequest Command) 
        {            
            if (Command.NumeroConta <= 0)
                ErrorMessages.Add("TIPO: INVALID_ACCOUNT.");                            
            if (Command.Valor <= 0)
                ErrorMessages.Add("TIPO: INVALID_VALUE.");
            if (string.IsNullOrWhiteSpace(Command.TipoMovimento.ToString()))
                ErrorMessages.Add("TIPO: INVALID_TYPE.");
            else
            {
                if (! (Command.TipoMovimento.ToString().ToUpper() == "C" || Command.TipoMovimento.ToString().ToUpper() == "D"))
                    ErrorMessages.Add("TIPO: INVALID_TYPE.");
            }                       
        }

        private void ValidaContaCorrente(ContaCorrente contaCorrente)
        {
            if (contaCorrente == null)
                ErrorMessages.Add("TIPO: INVALID_ACCOUNT.");
            else
            {
                if (!contaCorrente.Ativo)
                    ErrorMessages.Add("TIPO: INACTIVE_ACCOUNT.");
            }

        }
    }
}
