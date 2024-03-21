using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace crud.Net7Razor.Models;

    public class Cliente
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
    [Required(ErrorMessage = "Informe o nome")]
    [StringLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
    [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
    [DisplayName("Nome Completo")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "Informe um email válido")]
    [DisplayName("E-mail")]
    public string Email { get; set; } = string.Empty;

    public List<Interesses> Interesses { get; set; } = new ();


    }

