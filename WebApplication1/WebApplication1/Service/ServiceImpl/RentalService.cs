using WebApplication1.Dto;
using WebApplication1.model;
using WebApplication1.Service.Stretagies;

namespace WebApplication1.Service.ServiceImpl;

public class RentalService:IRentalService
{

    private readonly IStretagySelector _stretagySelector;
  
    public RentalService(IStretagySelector stretagySelector)
    {
        _stretagySelector = stretagySelector;

    }

    public PriceCalculatedDto PriceCalculateOnStretagy(PriceDecidesDto priceDecidesDto)
    {
        var days = (priceDecidesDto.EndDate - priceDecidesDto.StartDate).Days + 1;

        if (days > 10)
        {
            IPricingStretagy stretagy = _stretagySelector.SelectStretagy(PricingDto.Weekend);
            double price = stretagy.CalculatePrice(priceDecidesDto, 10);
            return new PriceCalculatedDto(price, priceDecidesDto.EquipmentId, priceDecidesDto.UserId);
        }

        if (days >= 1)
        {
            IPricingStretagy stretagy = _stretagySelector.SelectStretagy(PricingDto.Daily);
            double price = stretagy.CalculatePrice(priceDecidesDto, 5);
            return new PriceCalculatedDto(price, priceDecidesDto.EquipmentId, priceDecidesDto.UserId);
        }
        else
        {
            return new PriceCalculatedDto(0, priceDecidesDto.EquipmentId,
                priceDecidesDto.UserId, "date must be valid");
        }

    }

    public void CreateRental(Rental rental)
    {
        
    }

}