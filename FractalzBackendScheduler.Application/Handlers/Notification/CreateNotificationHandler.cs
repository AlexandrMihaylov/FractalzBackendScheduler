using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Entities;
using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Notification;
using FractalzBackendScheduler.Application.Domains.Responses.Notification;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Notification;

public class CreateNotificationHandler: IRequestHandler<CreateNotificationRequest, CreateNotificationResponse>
{
    private readonly IRepository<Entities.Notification> _repositoryNotification;
    public CreateNotificationHandler(IRepository<Entities.Notification> repositoryNotification)
    {
        _repositoryNotification = repositoryNotification ?? throw new ArgumentNullException(nameof(repositoryNotification));
    }
    public async Task<CreateNotificationResponse> Handle(CreateNotificationRequest request, CancellationToken cancellationToken)
    {
        var notification = new Entities.Notification();

        notification.IdUser = request.IdUser;
        notification.Date = request.Date;
        notification.Text = request.Text;
        
        var res = _repositoryNotification.Create(notification);

        if (res == 0)
        { return new CreateNotificationResponse() { Message = "", Success = false }; }
        else 
        { return new CreateNotificationResponse() { Success = true }; }
    }
}