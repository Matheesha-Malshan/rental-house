using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.model;

public class Rental
{
    public int RentalId { get; set; }
    
    [ForeignKey(nameof(Equipment))]
    public int EquipmentId { get; set; }
    
    public string RenterName { get; set; } = "";
    public string RenterPhone{get;set;} = "";
    public string RenterEmail{get;set;} = "";
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public double TotalPrice { get; set; }
    public string Status { get; set; } = "";
    public DateOnly CreatedDate { get; set; }
    
    public Equipment Equipment { get; set; }
}