using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Subtitle { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? İsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
