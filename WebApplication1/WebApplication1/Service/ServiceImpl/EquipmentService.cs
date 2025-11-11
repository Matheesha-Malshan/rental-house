
using AutoMapper;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.model;

using WebApplication1.Service.File;
using WebApplication1.Service.Stretagies;


namespace WebApplication1.Service.ServiceImpl;

public class EquipmentService:IEquipmentService
{
    private readonly IFileService _fileService;
    private readonly IMapper  _mapper;
    private readonly AppDb _appDb;
  

    public EquipmentService(IFileService fileService,IMapper mapper,AppDb appDb
        ,IStretagySelector stretagySelector)
    {
        _fileService = fileService;
        _mapper = mapper;
        _appDb = appDb;
        
    }

    public async Task CreateEquipmentAsync(EquipmentDto equipment)
    {
        var equipments =_mapper.Map<Equipment>(equipment);
        
        using var transaction = await _appDb.Database.BeginTransactionAsync();
        
        try
        {
            await _appDb.Equipments.AddAsync(equipments);
            await _appDb.SaveChangesAsync();
            equipment.EquipmentId=equipments.EquipmentId;
            string filePath = GetFilePath(equipment);
            equipments.ImageUrl = filePath;
            await _fileService.FileSaveAsync(equipment,filePath);
            
            await transaction.CommitAsync();
            
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }

    }

    public String GetFilePath(EquipmentDto equipment)
    {
        if (equipment.Image.Length > 0)
        {
           return _fileService.CreateFile(equipment);
        }
        return String.Empty;
        
    }
    

}