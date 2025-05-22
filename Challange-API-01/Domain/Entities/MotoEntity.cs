using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challange_API_01.Domain.Entities
{
    [Table("tb_mtt_moto")]
    public class MotoEntity
    {
        [Key]
        public int IdMoto { get; set; }

        [Required]
        public string DsPlaca { get; set; }

        [Required]
        public string NmModelo { get; set; }

        public string DsCor { get; set; }

        public int? NrAno { get; set; }

        [Required]
        public string DsStatus { get; set; } = "Disponível";

        [Required]
        public int IdEstacao { get; set; }

        [Required]
        public string DsVaga { get; set; }
    }
}
