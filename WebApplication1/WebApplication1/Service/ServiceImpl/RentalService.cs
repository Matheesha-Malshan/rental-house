using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.model;
using WebApplication1.Service.Observers;
using WebApplication1.Service.States;
using WebApplication1.Service.Stretagies;

namespace WebApplication1.Service.ServiceImpl;

public class RentalService:IRentalService
{

    private readonly IStretagySelector _stretagySelector;
    private readonly AppDb _appDb;
    private readonly IMapper  _mapper;
    private readonly IRentalSubject _rentalSubject;
    public RentalService(IStretagySelector stretagySelector,AppDb appDb,IMapper  mapper,IRentalSubject rentalSubject)
    {
        _stretagySelector = stretagySelector;
        _appDb = appDb;
        _mapper = mapper;
        _rentalSubject = rentalSubject;
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

    public async Task<RentalDto> CreateRentalAsync(RentalDto rental)
    {
        rental.Status = "Pending";
        _appDb.Rentals.Add(_mapper.Map<Rental>(rental));
        await _appDb.SaveChangesAsync();
        
        return _mapper.Map<RentalDto>(rental);

    }

    public async Task<RentalDto> ApproveRentalAsync(int rentalId)
    {
        var rental = await _appDb.Rentals
            .Include(r=>r.Equipment)
            .FirstOrDefaultAsync(r=>r.RentalId==rentalId);

        if (rental == null)
        {
            throw new Exception("Rental not found");
        }

        var state = StateFactory.GetState(rental.Status);

        if (!state.CanApprove())
        {
            throw new Exception("Can't approve rental");
        }
        
        state.Approve(rental,rental.Equipment);

        _rentalSubject.RunObservers(rental.Equipment.UserId);
        
        await _appDb.SaveChangesAsync();
        return _mapper.Map<RentalDto>(rental);
    }


    public async Task<RentalDto> StartRentalAsync(int rentalId)
    {
        var rental = await _appDb.Rentals
            .Include(r=>r.Equipment)
            .FirstOrDefaultAsync(r=>r.RentalId==rentalId);

        if (rental == null)
        {
            throw new Exception("Rental not found");
        }
        
        var state = StateFactory.GetState(rental.Status);
        
        if (!state.CanStart())
        {
            throw new Exception("Can't Start rental");
        }
     
        state.Start(rental);
        
        await _appDb.SaveChangesAsync();
        return _mapper.Map<RentalDto>(rental);
    }

    public async Task<RentalDto> CompleteRentalAsync(int rentalId)
    {
        var rental = await _appDb.Rentals
            .Include(r=>r.Equipment)
            .FirstOrDefaultAsync(r=>r.RentalId==rentalId);

        if (rental == null)
        {
            throw new Exception("Rental not found");
        }

        var state = StateFactory.GetState(rental.Status);

        if (!state.CanComplete())
        {
            throw new Exception("Can't Complete rental");
        }
        
        state.Complete(rental,rental.Equipment);
        
        await _appDb.SaveChangesAsync();
        return _mapper.Map<RentalDto>(rental);
    }

    public async Task<RentalDto> CancelRentalAsync(int rentalId)
    {
        var rental = await _appDb.Rentals
            .Include(r=>r.Equipment)
            .FirstOrDefaultAsync(r=>r.RentalId==rentalId);

        if (rental == null)
        {
            throw new Exception("Rental not found");
        }

        var state = StateFactory.GetState(rental.Status);

        if (!state.CanCancel())
        {
            throw new Exception("Can't Complete rental");
        }
        
        state.Cancel(rental,rental.Equipment);
        
        await _appDb.SaveChangesAsync();
        return _mapper.Map<RentalDto>(rental);
    }

    public async Task<List<RentalDto>> GetRentalAsync(int userId)
    {
        var rental = await _appDb.Rentals
            .Include(r => r.Equipment)
            .Where(r => r.Equipment.UserId == userId)
            .ToListAsync();
        
        return _mapper.Map<List<RentalDto>>(rental);

    }

    public NotificationDto NotifyRental(int userId)
    {
        
        NotificationDto notification = _rentalSubject.DequeueNotification(userId);
        return notification;


    }


}