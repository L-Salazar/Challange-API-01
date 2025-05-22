using System.ComponentModel.DataAnnotations;

namespace Challange_API_01.Application.Dtos
{
    public class HistoricoMotoDto
    {
        public int IdHistorico { get; set; }

        [Required(ErrorMessage = "O id da moto é obrigatório")]
        public int IdMoto { get; set; }

        [Required(ErrorMessage = "O id do usuário é obrigatório")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O tipo de ação é obrigatório")]
        public string TpAcao { get; set; } = string.Empty; // "Liberação" ou "Devolução"

        [Required(ErrorMessage = "A data da ação é obrigatória")]
        public DateTime DtAcao { get; set; }
    }
}
