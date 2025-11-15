namespace WebApplication1.Dto;

public class RentalDto
{
    public int RentalId { get; set; }
    public int EquipmentId { get; set; }
    public string Title { get; set; } = "";
    public string RenterName { get; set; } = "";
    public string RenterPhone{get;set;} = "";
    public string RenterEmail{get;set;} = "";
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public double TotalPrice { get; set; }
    public string Status { get; set; } = "";
    public DateOnly CreatedDate { get; set; }
    
   
}