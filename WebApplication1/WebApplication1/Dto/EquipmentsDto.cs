namespace WebApplication1.Dto;

public class EquipmentsDto
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
    public Boolean IsActive { get; set; } 
    public DateTime CreatedDate { get; set; }
    public string ImageUrl { get; set; } = "";
}