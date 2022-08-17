﻿using Sat.Recruitment.Models.Enums;
using System;

namespace Sat.Recruitment.Models.Abstract
{    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType Type { get; set; }
        public decimal Money { get; set; }
        public abstract void CalculateMoney();
    }
}
