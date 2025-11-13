using WebApplication1.Dto;

namespace WebApplication1.Service.Observers;

public interface IRentalSubject
{
    void AddObservers(IRentalObserver observer);
    void RunObservers(int userId);

    void AddNotification(NotificationDto notification);

    NotificationDto DequeueNotification(int userId);
}