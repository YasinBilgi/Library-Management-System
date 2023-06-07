using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class About
    {
        public byte Id { get; set; }
        public string? Title { get; set; }
        public string? İmageUrl { get; set; }
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public bool? İsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
