
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.model;

using WebApplication1.Service.File;


namespace WebApplication1.Service.ServiceImpl;

public class EquipmentService:IEquipmentService
{
    private readonly IFileService _fileService;
    private readonly IMapper  _mapper;
    private readonly AppDb _appDb;
  

    public EquipmentService(IFileService fileService,IMapper mapper,AppDb appDb)
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
            
            _appDb.Equipments.Update(equipments);
            await _appDb.SaveChangesAsync();
            
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

    public async Task<List<EquipmentsDto>> GetAllEquipments()
    {
        var equipments = await _appDb.Equipments.ToListAsync();
        return _mapper.Map<List<EquipmentsDto>>(equipments);
    }
    
    public async Task<List<EquipmentsDto>> GetAllEquipmentsByCategory(string category)
    {
        var equipments = await _appDb.Equipments.Where(u => u.Category == category).ToListAsync();
        return _mapper.Map<List<EquipmentsDto>>(equipments);
    }
    
    public async Task<List<string>> GetAllEquipmentsByLetter(string letters)
    {
        if (string.IsNullOrWhiteSpace(letters))
        {
            return new List<string>();
        }
        letters=letters.ToLower();

        var eqipments = await _appDb.Equipments
            .Where(e => e.Category.ToLower().StartsWith(letters))
            .Select(e => e.Category)
            .Distinct()
            .ToListAsync();

        return eqipments;
    }



}