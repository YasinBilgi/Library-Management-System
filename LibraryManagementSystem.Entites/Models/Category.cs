using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public byte Id { get; set; }
        public string? Name { get; set; }
        public bool? İsActive { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
