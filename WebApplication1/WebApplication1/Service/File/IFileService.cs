using WebApplication1.Dto;

namespace WebApplication1.Service.File;

public interface IFileService
{
    string CreateFile(EquipmentDto equipment);
    Task FileSaveAsync(EquipmentDto equipment, string path);
}