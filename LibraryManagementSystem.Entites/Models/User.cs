﻿using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
    }
}
