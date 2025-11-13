namespace WebApplication1.Dto;

public class NotificationDto
{
  
    public string Message { get; set; } = "";
    public DateTime Time { get; set; } = DateTime.Now;
    public int UserId { get; set; }
    
    public NotificationDto(string message,int userId)
    {
        
        Message = message;
        UserId = userId;
    }

    public NotificationDto()
    {
    }
}