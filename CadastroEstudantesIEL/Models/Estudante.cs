using System.ComponentModel.DataAnnotations;

namespace CadastroEstudantesIEL.Models
{
    public class Estudante
    {
        [Key]
        public int Id { get; set}

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório")]
        [StringLength(200, ErrorMessage = "O endereço não pode exceder 200 caracteres")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Data de Conclusão é obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Conclusão")]
        public DateTime DataConclusao { get; set; }
    }
}
