using WebApplication1.Dto;


namespace WebApplication1.Service;

public interface IEquipmentService
{
    Task CreateEquipmentAsync(EquipmentDto equipment);
    Task<List<EquipmentsDto>> GetAllEquipments();
    Task<List<EquipmentsDto>> GetAllEquipmentsByCategory(string category);

    Task<List<string>> GetAllEquipmentsByLetter(string letters);

    Task<List<EquipmentsDto>> GetAllEquipmentsByTitle(string titles);

}