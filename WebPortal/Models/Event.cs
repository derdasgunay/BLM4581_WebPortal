using System.ComponentModel.DataAnnotations;
namespace WebPortal.Models;


public class Event
{
    public int Id { get; set;}

    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title must be less than 100 characters")]
    public string Title { get; set; } = "";
    
    public string Description { get; set;} = "";
    
    [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000")]
    public int Capacity { get; set; }
}