using FractalzBackendScheduler.Application.Domains.Responses.Notification;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Requests.Notification;

public class UpdateNotificationRequest : IRequest<UpdateNotificationResponse>
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Время
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Текст
    /// </summary>
    public string Text { get; set; }
}