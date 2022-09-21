using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Notification;
using FractalzBackendScheduler.Application.Domains.Responses.Notification;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Notification;

public class UpdateNotificationHandler: IRequestHandler<UpdateNotificationRequest, UpdateNotificationResponse>
{
    private readonly IRepository<Entities.Notification> _repositoryNotification;
    public UpdateNotificationHandler(IRepository<Entities.Notification> repositoryNotification)
    {
        _repositoryNotification = repositoryNotification ?? throw new ArgumentNullException(nameof(repositoryNotification));
    }
    public async Task<UpdateNotificationResponse> Handle(UpdateNotificationRequest request, CancellationToken cancellationToken)
    {
        var notification = _repositoryNotification.Get(i => i.Id == request.Id).FirstOrDefault();
        
        DateTime zero = new DateTime(1,1,1,0,0,0);
        if (request.Date != zero){notification.Date = request.Date;}
        if (request.Text != null){notification.Text = request.Text;}
        
        var res = _repositoryNotification.Update(notification);

        if (res == 0)
        { return new UpdateNotificationResponse() { Message = "", Success = false }; }
        else 
        { return new UpdateNotificationResponse() { Success = true }; }
    }
}