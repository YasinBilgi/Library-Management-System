using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace LibraryManagementSystem.Areas.ManagementPanel.Data
{
    public class BookViewModel
    {
        public int İd { get; set; }

        [Required(ErrorMessage = "Kategori seçmeniz gerekiyor")]
        public byte? CategoryId { get; set; } = null;

        [Required(ErrorMessage = "İsim alanı boş bırakılamaz")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Sayfa sayısı boş bırakılamaz")]
        public int? NumberPage { get; set; }

        public string? İmageUrl { get; set; }

        public DateTime? PublishDate { get; set; }

        [Required(ErrorMessage = "Seri no alanı boş bırakılamaz")]
        public string? Isbn { get; set; }

        public bool? İsActive { get; set; }

        public DateTime? RegisterDate { get; set; }

        public string? Description { get; set; }

        public int? Stock { get; set; }
    }
}
