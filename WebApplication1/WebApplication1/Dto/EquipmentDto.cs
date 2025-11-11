using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Dto;

public class EquipmentDto
{
    
    public int EquipmentId { get; set; }
    public int UserId { get; set; }
    
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Category { get; set; } = "";
    public Double DailyPrice { get; set; } 
    public string OwnerName { get; set; } = "";
    public string OwnerPhone { get; set; } = "";
    public string OwnerEmail { get; set; } = "";
    public string IsActive { get; set; } = "";
    public DateTime CreatedDate { get; set; }

    public IFormFile Image { get; set; }
   

}