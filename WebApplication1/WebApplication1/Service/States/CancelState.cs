using WebApplication1.model;

namespace WebApplication1.Service.States;

public class CancelState:IRentalState
{
    public string StateName =>"Cancelled";
    public void Approve(Rental rental, Equipment equipment)
    {
        throw new NotImplementedException();
    }

    public void Start(Rental rental)
    {
        throw new NotImplementedException();
    }

    public void Complete(Rental rental, Equipment equipment)
    {
        throw new NotImplementedException();
    }

    public void Cancel(Rental rental, Equipment equipment)
    {
        throw new NotImplementedException();
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
        return false;
    }

    public bool CanCancel()
    {
        return false;
    }
}