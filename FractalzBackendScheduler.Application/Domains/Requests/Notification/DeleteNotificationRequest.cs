using MediatR;
using FractalzBackendScheduler.Application.Domains.Responses.Notification;

namespace FractalzBackendScheduler.Application.Domains.Requests.Notification;

public class DeleteNotificationRequest : IRequest<DeleteNotificationResponse>
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
}