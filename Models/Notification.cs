namespace ConsoleBankingApp.Models;

public class Notification
{
    public Guid Id {get;}
    public string Title {get;}
    public string Message {get;}
    public DateTime CreatedAt {get;}

    public Notification(string title, string? message = null)
    {
        if (string.IsNullOrWhiteSpace(title)) 
            throw new ArgumentException("Una notificacion no puede tener el titulo vacio.");

        Title = title;
        Message = message ?? "-";
        CreatedAt = DateTime.UtcNow;
    }

    public void PrintNotification()
    {
        Console.WriteLine($"{Title} - {Message} - {CreatedAt}");
    }
}