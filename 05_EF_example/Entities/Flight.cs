using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _05_EF_example.Entities
{
    public class Flight
    {
        //Primary key : Id/id/ID/ EntityName+Id
        [Key]//set primary key
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        public int? Rating { get; set; }

        //Relational Type : 
        //Foreign key : RelatedEntityName +  RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }
        //Navigation properties
        public Airplane Airplane { get; set; }

        public ICollection<Client> Clients { get; set; }
    }

}
