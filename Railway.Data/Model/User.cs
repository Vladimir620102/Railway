﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
