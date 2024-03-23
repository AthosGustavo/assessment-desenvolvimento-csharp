using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.Models
{
   public class Departamento
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O local é obrigatório.")]
    public string Local { get; set; }
    public List<Funcionario> Funcionarios { get; set; }

    public Departamento()
       {
           Funcionarios = new List<Funcionario>();
       }
}
}