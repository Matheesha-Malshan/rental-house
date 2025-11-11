using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.model;

public class Equipment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EquipmentId { get; set; }
    public int UserId { get; set; }
    [MaxLength(255)]
    public string Title { get; set; } = "";
    [MaxLength(255)]
    public string Description { get; set; } = "";
    [MaxLength(255)]
    public string Category { get; set; } = "";
    public Double DailyPrice { get; set; } 
    [MaxLength(255)]
    public string OwnerName { get; set; } = "";
    [MaxLength(255)]
    public string OwnerPhone { get; set; } = "";
    [MaxLength(255)]
    public string OwnerEmail { get; set; } = "";
    [MaxLength(255)]
    public string IsActive { get; set; } = "";
    public DateTime CreatedDate { get; set; }
    [MaxLength(255)] public string ImageUrl { get; set; } = "";
    
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
    