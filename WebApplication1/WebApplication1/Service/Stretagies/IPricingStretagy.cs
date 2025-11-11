using WebApplication1.Dto;

namespace WebApplication1.Service.Stretagies;

public interface IPricingStretagy
{
    bool CheckStretagy(PricingDto pricingDto);
    double CalculatePrice(PriceDecidesDto priceDecidesDto, double dailyRate);
}