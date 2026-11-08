using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = "";
    public List<Event> Events { get; set; } = new();
}
