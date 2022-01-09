using System.ComponentModel.DataAnnotations;

namespace StaparParking.Models
{
    public class Vehicle : BaseEntity
    {
        [Display(Name = "Montadora"),
            Required(ErrorMessage = "Nome é obrigatório."), MaxLength(150, ErrorMessage = "Tamanho Máximo 100 caracteres.")]
        public string Brand { get; set; }

        [Display(Name = "Modelo do Carro"),
            Required(ErrorMessage = "Nome é obrigatório."), MaxLength(150, ErrorMessage = "Tamanho Máximo 100 caracteres.")]
        public string Model { get; set; }

        [Display(Name = "Placa"),
            Required(ErrorMessage = "Nome é obrigatório."),
            MaxLength(150, ErrorMessage = "Tamanho Máximo 9 caracteres.")]
        public string Identification { get; set; }
    }
}
