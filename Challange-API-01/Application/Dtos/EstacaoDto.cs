using System.ComponentModel.DataAnnotations;

namespace Challange_API_01.Application.Dtos
{
    public class EstacaoDto
    {
        public int IdEstacao { get; set; }

        [Required(ErrorMessage = "O nome da estação é obrigatório")]
        public string NmEstacao { get; set; } = string.Empty;

        public string DsLocalizacao { get; set; } = string.Empty;

        public int? NrCapacidade { get; set; }

        [Required(ErrorMessage = "O status da estação é obrigatório")]
        public string DsStatus { get; set; } = "Ativa";

        [Required(ErrorMessage = "A data de criação é obrigatória")]
        public DateTime DtCriacao { get; set; }

        public DateTime? DtUltimaAtualizacao { get; set; }

        public string DsResponsavel { get; set; } = string.Empty;
    }
}
