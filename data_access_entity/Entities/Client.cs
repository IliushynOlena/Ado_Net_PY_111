﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_EF_example.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        //Navigation properties
        public ICollection<Flight> Flights { get; set; } //Collection
    }

}
