using data_access_entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_EF_example.Entities
{
    public class Client
    {
        //public int Id { get; set; }
        [Key]
        public int CredentialsId { get; set; }//set primary and foreign key
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        //Navigation properties
        public ICollection<Flight> Flights { get; set; } //Collection
        public Credentials Credentials { get; set; }
    }

}
