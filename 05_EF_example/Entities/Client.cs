using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_EF_example.Entities
{
    //Collections
    //Entities
    //Airplanes
    //Flights
    //Clients
    [Table("Passengers")]
    public class Client
    {
        public int Id { get; set; }
        [Required]//not null
        [MaxLength(100)]//nvarchar(100)
        [Column("FirstName")]//set name column
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }

}
