namespace WebApplication1.Dto;

public class PriceCalculatedDto
{
    public int EquipmentId { get; set; }
    public int UserId { get; set; }
    public double Price { get; set; }

    public string Message { get; set; } = string.Empty;

    public PriceCalculatedDto(double price, int equipmentId, int userId,string message)
    {
        Price = price;
        EquipmentId = equipmentId;
        UserId = userId;
        Message = message;
    }
    public PriceCalculatedDto(double price, int equipmentId, int userId)
    {
        Price = price;
        EquipmentId = equipmentId;
        UserId = userId;
   
    }
}