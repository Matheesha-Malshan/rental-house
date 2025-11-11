using WebApplication1.Dto;

namespace WebApplication1.Service.Stretagies;

public interface IStretagySelector
{
    IPricingStretagy SelectStretagy(PricingDto pricingDto);
}