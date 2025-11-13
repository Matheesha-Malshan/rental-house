using WebApplication1.Dto;
using WebApplication1.model;

namespace WebApplication1.Service.States;

public interface IRentalState
{
    string StateName{ get; }
    
    void Approve(Rental rental,Equipment equipment);
    void Start(Rental rental);
    void Complete(Rental rental,Equipment equipment);
    void Cancel(Rental rental,Equipment equipment);
    
    bool CanApprove();
    bool CanStart();
    bool CanComplete();
    bool CanCancel();
    
}