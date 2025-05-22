using System.ComponentModel.DataAnnotations;

namespace Challange_API_01.Application.Dtos
{
    public class MotoDto
    {
        public int IdMoto { get; set; }

        [Required(ErrorMessage = "A placa da moto é obrigatória")]
        public string DsPlaca { get; set; } = string.Empty;

        [Required(ErrorMessage = "O modelo da moto é obrigatório")]
        public string NmModelo { get; set; } = string.Empty;

        public string DsCor { get; set; } = string.Empty;

        public int? NrAno { get; set; }

        [Required(ErrorMessage = "O status da moto é obrigatório")]
        public string DsStatus { get; set; } = "Disponível";

        [Required(ErrorMessage = "O id da estação é obrigatório")]
        public int IdEstacao { get; set; }

        [Required(ErrorMessage = "A vaga da moto é obrigatória")]
        public string DsVaga { get; set; } = string.Empty;
    }
}
