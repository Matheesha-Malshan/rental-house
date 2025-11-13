using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.model;

namespace WebApplication1.Configuration;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<EquipmentDto, Equipment>()
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
            .ForSourceMember(src => src.Image, opt => opt.DoNotValidate());
        
        CreateMap<RentalDto, Rental>();
        
        CreateMap<Rental, RentalDto>();

        CreateMap<Equipment, EquipmentsDto>();



    }

}