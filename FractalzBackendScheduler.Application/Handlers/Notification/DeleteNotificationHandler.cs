using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Notification;
using FractalzBackendScheduler.Application.Domains.Responses.Notification;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Notification;

public class DeleteNotificationHandler: IRequestHandler<DeleteNotificationRequest, DeleteNotificationResponse>
{
    private readonly IRepository<Entities.Notification> _repositoryNotification;
    public DeleteNotificationHandler(IRepository<Entities.Notification> repositoryNotification)
    {
        _repositoryNotification = repositoryNotification ?? throw new ArgumentNullException(nameof(repositoryNotification));
    }
    public async Task<DeleteNotificationResponse> Handle(DeleteNotificationRequest request, CancellationToken cancellationToken)
    {
        var notification = _repositoryNotification.Get(i => i.Id == request.Id).FirstOrDefault();
        notification.IsDeleted = true;

        var res = _repositoryNotification.Update(notification);
        
        if (res == null)
        { return new DeleteNotificationResponse() { Message = "", Success = false }; }
        else 
        { return new DeleteNotificationResponse() { Success = true }; }
    }
}