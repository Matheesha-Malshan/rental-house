using WebApplication1.Dto;
using WebApplication1.model;

namespace WebApplication1.Service.States;

public class PendingState:IRentalState
{
    public string StateName =>"Pending";
    
    public void Approve(Rental rental, Equipment equipment)
    {
        rental.Status="Approved";
        equipment.IsActive = false;
    }

    public void Start(Rental rental)
    {
        throw new InvalidOperationException("Cannot start a pending state");
    }

    public void Complete(Rental rental, Equipment equipment)
    {
        throw new InvalidOperationException("Cannot complete a pending state");
    }

    public void Cancel(Rental rental, Equipment equipment)
    {
        rental.Status = "Cancelled";
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