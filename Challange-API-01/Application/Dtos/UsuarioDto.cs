using System.ComponentModel.DataAnnotations;

namespace Challange_API_01.Application.Dtos
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string NmUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email informado não é válido")]
        public string DsEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string DsSenha { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo do usuário é obrigatório")]
        public string TpUsuario { get; set; } = "operador";
    }
}
