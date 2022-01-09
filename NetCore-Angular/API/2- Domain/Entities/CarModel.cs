using System.ComponentModel.DataAnnotations;

namespace Valet.Domain.Entities
{
    public class CarModel : BaseEntity
    {
        [Display(Description = "Montadora")]
        public string Brand { get; set; }

        [Display(Description = "Modelo do Carro")]
        public string Model { get; set; }

        [Display(Description = "Placa")]
        public string Identification { get; set; }
    }
}
