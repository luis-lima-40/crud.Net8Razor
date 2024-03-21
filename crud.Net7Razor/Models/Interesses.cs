using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace crud.Net7Razor.Models;

public class Interesses
{
    [Key]
    [DisplayName("Id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o interesse")]
    [StringLength(50, ErrorMessage = "O interesse deve ter no máximo 50 caracteres")]
    [MinLength(3, ErrorMessage = "O interesse deve conter pelo menos 3 caracteres")]
    [DisplayName("Interesse")]
    public string Interesse { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    [DisplayName("Data de Cadastro")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [DisplayName("Cliente")]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "Cliente Invalido")]

    public Cliente? Cliente { get; set; }
    //public bool Selecionado { get; set; }
}
