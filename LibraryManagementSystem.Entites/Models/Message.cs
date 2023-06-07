using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public bool? İsActive { get; set; }
        public string? RegisterDate { get; set; }
    }
}
