using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
        public string? İmageUrl { get; set; }
        public bool? İsActive { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
