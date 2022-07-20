using System.ComponentModel.DataAnnotations;

namespace IntelitraderAPI.ViewModels
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage = "Informe o firstName do usuário!")]
        public string firstName { get; set; } = null!;

        public string? surname { get; set; }

        [Required(ErrorMessage = "Informe a idade do usuário!")]
        public int? age { get; set; } = null!;
    }
}
