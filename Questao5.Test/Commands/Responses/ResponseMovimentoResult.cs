

namespace Questao5.Test.Commands.Responses
{
    public class ResponseMovimentoResult
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public RequisicaoResult Data { get; private set; }
    }

    public class RequisicaoResult
    {
        public string Requisicao { get; set; }
        public string Resultado { get; set; }
        public bool IsValid { get; set; }
    }
}
