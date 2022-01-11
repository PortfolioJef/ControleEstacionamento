using System;

namespace StaparParking.Models
{
    public class Parking : BaseEntity
    {
        public int ValetID { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }

        public virtual Valet Valet { get; set; }
        public virtual Vehicle Vehicle { get; set; }

    }
}