using WebApplication1.Dto;

namespace WebApplication1.Service.Stretagies;

public class WeekendPricingStretagy:IPricingStretagy
{
    
    public bool CheckStretagy(PricingDto pricingDto)
    {
        return pricingDto == PricingDto.Weekend;
    }

    public double CalculatePrice(PriceDecidesDto priceDecidesDto, double dailyRate)
    {
        var days=(priceDecidesDto.EndDate - priceDecidesDto.StartDate).Days+1;
        var weeks = days / 7;
        var remainingDays=days%7;

        double weekendRate = dailyRate * 7 * 0.9;
        return weeks*weekendRate+remainingDays*dailyRate;
    }

   
}