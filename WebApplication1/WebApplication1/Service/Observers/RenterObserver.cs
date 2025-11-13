using WebApplication1.Dto;

namespace WebApplication1.Service.Observers;

public class RenterObserver:IRentalObserver
{ 
    
    private readonly IRentalSubject _subject;
    
    public RenterObserver(IRentalSubject subject)
    {
        _subject = subject;
        AddObj();
    }

    public void AddObj()
    {
        _subject.AddObservers(this);
    }

    public void SendNotification(int userId)
    {
        _subject.AddNotification(new NotificationDto("your request is approved",userId));
    }

}