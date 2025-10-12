using System.ComponentModel.DataAnnotations;

namespace CadastroEstudantesIEL.Models
{
    public class Estudante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [Display(Name = "CPF")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O Endereço deve ter no máximo 200 caracteres.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Data de Conclusão é obrigatório.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Conclusão")]
        public DateTime DataConclusao { get; set; }
    }
}