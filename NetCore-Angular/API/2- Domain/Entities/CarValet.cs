using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valet.Domain.Entities
{
    public class CarValet : BaseEntity
    {
        public int ValetID { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
    }
}