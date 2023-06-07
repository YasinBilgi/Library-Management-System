using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int İd { get; set; }
        public byte? CategoryId { get; set; }
        public string? Name { get; set; }
        public int? NumberPage { get; set; }
        public string? İmageUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? Isbn { get; set; }
        public bool? İsActive { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual Category? Category { get; set; }
        public virtual BookDetail? BookDetail { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
