using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challange_API_01.Domain.Entities
{
    [Table("tb_mtt_estacao")]
    public class EstacaoEntity
    {
        [Key]
        public int IdEstacao { get; set; }

        [Required]
        public string NmEstacao { get; set; }

        [Required]
        public string DsLocalizacao { get; set; }

        [Required]
        public int NrCapacidade { get; set; }

        [Required]
        public string DsStatus { get; set; } = "Ativa";

        [Required]
        public DateTime DtCriacao { get; set; }

        public DateTime? DtUltimaAtualizacao { get; set; }
        [Required]
        public string DsResponsavel { get; set; }
    }
}
