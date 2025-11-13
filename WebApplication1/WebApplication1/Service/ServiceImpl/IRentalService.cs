using WebApplication1.Dto;

namespace WebApplication1.Service.ServiceImpl;

public interface IRentalService
{
    PriceCalculatedDto PriceCalculateOnStretagy(PriceDecidesDto priceDecidesDto);
    Task<RentalDto> CreateRentalAsync(RentalDto rental);

    Task<List<RentalDto>> GetRentalAsync(int userId);

    Task<RentalDto> ApproveRentalAsync(int rentalId);

    Task<RentalDto> CancelRentalAsync(int rentalId);
    Task<RentalDto> CompleteRentalAsync(int rentalId);

    Task<RentalDto> StartRentalAsync(int rentalId);

    NotificationDto NotifyRental(int userId);
}