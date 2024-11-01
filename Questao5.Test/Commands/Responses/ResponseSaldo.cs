
namespace Questao5.Test.Commands.Responses
{
    public class ResponseSaldo
    {
        public int NumeroConta { get; set; }
        public string Nome { get; set; }
        public DateTime DataRespostaConsulta { get; set; }
        public double Valor { get; set; }

        public ResponseSaldo() { }
        public ResponseSaldo(int numeroConta, string nome, DateTime dataRespostaConsulta, double valor) 
        { 
            NumeroConta = numeroConta;
            Nome = nome;    
            DataRespostaConsulta = dataRespostaConsulta;
            Valor = valor;
        }
    }
}
