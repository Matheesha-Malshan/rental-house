using WebApplication1.Dto;

namespace WebApplication1.Service.Observers;

public class RentalSubject:IRentalSubject
{
    private List<IRentalObserver> _objects = new();
    private readonly Queue<NotificationDto> _notificationQueue = new();
    public void AddObservers(IRentalObserver observer)
    {
        _objects.Add(observer);
    }

    public void RunObservers(int userId)
    {
        
        foreach (var o in _objects)
        {
            o.SendNotification(userId);
        }
    }

    public void AddNotification(NotificationDto notification)
    {
        _notificationQueue.Enqueue(notification);
    }

    public NotificationDto DequeueNotification(int  userId)
    {
        
        if (_notificationQueue.Count > 0)
        {
            Console.WriteLine("notification count is"+_notificationQueue.Count);
            
            foreach (var o in _notificationQueue)
            {
                
                if (o.UserId == userId)
                {
                    return o;
                }
            }
        }

        return new NotificationDto();
    }


}