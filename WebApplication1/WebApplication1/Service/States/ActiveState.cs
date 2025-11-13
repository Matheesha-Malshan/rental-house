using WebApplication1.Dto;
using WebApplication1.model;

namespace WebApplication1.Service.States;

public class ActiveState:IRentalState
{
    public string StateName=>"Active";
    public void Approve(Rental rental, Equipment equipment)
    {
        throw new InvalidOperationException("Can't approve this state");
    }

    public void Start(Rental rental)
    {
        throw new InvalidOperationException("rental is already active");
    }

    public void Complete(Rental rental, Equipment equipment)
    {
        rental.Status="Completed";
        equipment.IsActive=true;
    }

    public void Cancel(Rental rental, Equipment equipment)
    {
        throw new InvalidOperationException("rental is already active");
    }

    public bool CanApprove()
    {
        return false;
    }

    public bool CanStart()
    {
        return false;
    }

    public bool CanComplete()
    {
        return true;
    }

    public bool CanCancel()
    {
        return false;
    }
}