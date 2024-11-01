using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Entities
{
    [Table("movimento")]
    public class Movimento
    {
        [Key]
        [Column("idmovimento")]
        public string Id { get; set; }

        [Column("idcontacorrente")]
        public string IdContaCorrente { get; set; }

        [Column("datamovimento")]
        public string DataMovimento { get; set; }

        [Column("tipomovimento")]
        public string TipoMovimento { get; set; }

        [Column("valor")]
        public double Valor { get; set; }
    }
}
