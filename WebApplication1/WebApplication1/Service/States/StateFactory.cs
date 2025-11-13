namespace WebApplication1.Service.States;

public static class StateFactory
{
    public static IRentalState GetState(string state)
    {
        return state switch
        {
            "Pending" => new PendingState(),
            "Approved" => new ApprovedState(),
            "Active" => new ActiveState(),
            "Completed" => new CompletedState(),
            "Cancel" => new CancelState(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

}