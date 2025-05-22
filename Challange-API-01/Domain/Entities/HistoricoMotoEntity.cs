using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challange_API_01.Domain.Entities
{
    [Table("tb_mtt_historico_moto")]
    public class HistoricoMotoEntity
    {
        [Key]
        public int IdHistorico { get; set; }

        [Required]
        public int IdMoto { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public string TpAcao { get; set; } // 'Liberação' ou 'Devolução'

        [Required]
        public DateTime DtAcao { get; set; }
    }
}
