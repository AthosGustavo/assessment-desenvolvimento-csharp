using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.Models
{
    public class Funcionario
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O endereço é obrigatório.")]
    public string Endereco { get; set; }
    
    [Required(ErrorMessage = "O telefone é obrigatório.")]
    public string Telefone { get; set; }
    
    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A data de nascimento é obrigatório.")]
    public DateTime DataNascimento { get; set; }
    
    // [Required(ErrorMessage = "O departamento é obrigatório.")]
    public int DepartamentoId { get; set; }
    
    public Departamento? Departamento { get; set; }
}
}