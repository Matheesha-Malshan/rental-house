using WebApplication1.Dto;

namespace WebApplication1.Service.Stretagies;

public class DailyPricingStrategy:IPricingStretagy
{
   
    
    public bool CheckStretagy(PricingDto pricingDto)
    {
        return pricingDto == PricingDto.Daily;
    }

    public double CalculatePrice(PriceDecidesDto priceDecidesDto, double dailyRate)
    {
        var days=(priceDecidesDto.EndDate - priceDecidesDto.StartDate).Days+1;
        return days * dailyRate;
    }
}