﻿using _05_EF_example.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access_entity.Entities
{
    public class Credentials//as Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }
}
