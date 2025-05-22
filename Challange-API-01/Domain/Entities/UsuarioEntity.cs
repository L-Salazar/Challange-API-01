using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challange_API_01.Domain.Entities
{
    [Table("tb_mtt_usuario")]
    public class UsuarioEntity
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string NmUsuario { get; set; }

        [Required]
        public string DsEmail { get; set; }

        [Required]
        public string DsSenha { get; set; }

        [Required]
        public string TpUsuario { get; set; } = "operador";

    }
}
