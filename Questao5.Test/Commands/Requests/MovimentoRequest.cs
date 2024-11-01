
namespace Questao5.Test.Commands.Requests
{
    public class MovimentoRequest
    {
        public string Requisicao { get; set; }
        public int NumeroConta { get; set; }
        public DateTime DataMovimento { get; set; }
        public string TipoMovimento { get; set; }
        public double Valor { get; set; }

        public MovimentoRequest(string requisicao, int numeroConta, DateTime dataMovimento, string tipoMovimento, double valor) 
        {
            Requisicao  = requisicao;
            NumeroConta = numeroConta;
            DataMovimento = dataMovimento;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }
    }
}
