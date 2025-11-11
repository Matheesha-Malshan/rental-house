using WebApplication1.Dto;


namespace WebApplication1.Service;

public interface IEquipmentService
{
    Task CreateEquipmentAsync(EquipmentDto equipment);
    



}