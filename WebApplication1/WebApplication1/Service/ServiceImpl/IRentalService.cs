using WebApplication1.Dto;

namespace WebApplication1.Service.ServiceImpl;

public interface IRentalService
{
    PriceCalculatedDto PriceCalculateOnStretagy(PriceDecidesDto priceDecidesDto);
}