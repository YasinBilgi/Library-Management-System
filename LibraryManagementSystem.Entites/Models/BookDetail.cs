using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class BookDetail
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }

        public virtual Book IdNavigation { get; set; } = null!;
    }
}
