using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models;

public class Event
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Başlık zorunludur.")]
    [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    [Range(1, 1000, ErrorMessage = "Kapasite 1 ile 1000 arasında olmalıdır.")]
    public int Capacity { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Kategori seçiniz.")]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
