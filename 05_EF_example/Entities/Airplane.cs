using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _05_EF_example.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }

}
