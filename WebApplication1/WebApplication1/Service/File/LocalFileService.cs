using WebApplication1.Dto;

namespace WebApplication1.Service.File;

public class LocalFileService:IFileService
{
    private string _path="../wwwroot";
    
    public string CreateFile(EquipmentDto equipment)
    {
        _path = _path + "/" +equipment.UserId;

        if (Directory.Exists(_path))
        {
            return _path+"/"+equipment.EquipmentId;
        }

        try
        {
            DirectoryInfo directory = Directory.CreateDirectory(_path);
            return directory.FullName+"/"+equipment.EquipmentId;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    public async Task FileSaveAsync(EquipmentDto equipment,string path)
    {
        
        
        if (equipment.Image.Length > 0)
        {
            using var stream = new FileStream(path, FileMode.Create);
            await equipment.Image.CopyToAsync(stream);
            Console.WriteLine("file is created");
        }
        else
        {
            Console.WriteLine("fuck");
        }
    }
}