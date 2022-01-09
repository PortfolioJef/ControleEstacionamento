
using System.ComponentModel.DataAnnotations;

namespace Valet.Domain.Entities
{
    public class Valet : BaseEntity
    {
        [Display(Description = "Nome")]
        public string Name { get; set; }

        [Display(Description = "CPF do Manobrista")]
        public string NumberId { get; set; }

        [Display(Description = "Data de Nascimento do Manobrista")]
        public DateTime BirthDate { get; set; }

    }
}
