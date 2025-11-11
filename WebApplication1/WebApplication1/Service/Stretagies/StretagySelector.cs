using WebApplication1.Dto;

namespace WebApplication1.Service.Stretagies;

public class StretagySelector:IStretagySelector
{
    Dictionary<PricingDto,IPricingStretagy> _stretagies=new Dictionary<PricingDto,IPricingStretagy>();
    
    
    public StretagySelector(IEnumerable<IPricingStretagy> stretagies)
    {
        foreach (var stretagy in stretagies)
        {
            foreach (PricingDto category in Enum.GetValues(typeof(PricingDto)))
            {
                if (stretagy.CheckStretagy(category))
                {
                    _stretagies.Add(category,stretagy);
                }
            }
            
        }
       
        
    }

    public IPricingStretagy SelectStretagy(PricingDto pricingDto)
    {
        return _stretagies[pricingDto];

    }
}