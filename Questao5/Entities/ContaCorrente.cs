using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Entities
{
    [Table("contacorrente")]
    public class ContaCorrente
    {
        [Key]
        [Column("idcontacorrente")]
        public string Id { get; set; }

        [Column("numero")]
        public int Numero { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
