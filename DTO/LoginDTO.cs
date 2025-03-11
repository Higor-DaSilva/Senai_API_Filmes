using System.ComponentModel.DataAnnotations;

namespace api_filmes_senai.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O email e obrigatorio!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha eh obrigatoria!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no mínimo r caracteres e no máximo 60")]
        public string? Senha { get; set; }
    }
}
