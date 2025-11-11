using WebApplication1.Dto;

namespace WebApplication1.Service.States;

public class PendingState:IRentalState
{
    public string StateName { get; set; }
    
    
    
    
    public void Approve(RentalDto rental, EquipmentDto equipment)
    {
        throw new NotImplementedException();
    }

    public void Start(RentalDto rental)
    {
        throw new NotImplementedException();
    }

    public void Complete(RentalDto rental, EquipmentDto equipment)
    {
        throw new NotImplementedException();
    }

    public void Cancel(RentalDto rental, EquipmentDto equipment)
    {
        throw new NotImplementedException();
    }

    public bool CanApprove()
    {
        return true;
    }

    public bool CanStart()
    {
        return false;
    }

    public bool CanComplete()
    {
        return false;
    }

    public bool CanCancel()
    {
        return true;
    }
}