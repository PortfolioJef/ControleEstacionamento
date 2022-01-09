using System;
using System.ComponentModel.DataAnnotations;

namespace StaparParking.Models
{
    public class Valet : BaseEntity
    {
        [Display(Name = "Nome"), Required(ErrorMessage = "Nome é obrigatório."), 
            MaxLength(100,ErrorMessage ="Tamanho Máximo 100 caracteres.") ]
        public string Name { get; set; }

        [Display(Name = "CPF do Manobrista"), Required(ErrorMessage = "Cpf é obrigatório."), 
            MaxLength(11, ErrorMessage = "Tamanho Máximo 11 caracteres.")]
        public string NumberId { get; set; }

        [Display(Name = "Data de Nascimento do Manobrista"), 
            Required(ErrorMessage = "Data de Nascimento é obrigatório.")]
        public DateTime BirthDate { get; set; }

    }
}
