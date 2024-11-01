using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Commands.Requests
{
    public class SaldoRequest : ICommand
    {
        [Required]
        public int NumeroConta { get; set; }

        public bool IsValid => Validate();

        private bool Validate()
        {
            return
                this.NumeroConta > 0;
        }

        public SaldoRequest(int numeroConta)
        {
            this.NumeroConta = numeroConta;
        }
    }
}
