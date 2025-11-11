using WebApplication1.Dto;

namespace WebApplication1.Service.States;

public interface IRentalState
{
    string StateName { get; set; }
    
    void Approve(RentalDto rental,EquipmentDto equipment);
    void Start(RentalDto rental);
    void Complete(RentalDto rental,EquipmentDto equipment);
    void Cancel(RentalDto rental,EquipmentDto equipment);
    
    bool CanApprove();
    bool CanStart();
    bool CanComplete();
    bool CanCancel();
    
}