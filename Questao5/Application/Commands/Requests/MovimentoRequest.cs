using Questao5.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentoRequest : ICommand
    {
        [Required]
        public string Requisicao { get; set; }
        [Required]
        public int NumeroConta { get; set; }
        [Required]
        public DateTime DataMovimento { get; set; }        
        [Required]
        public string TipoMovimento { get; set; }        
        [Required]
        public double Valor { get; set; }
    }
}
