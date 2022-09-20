using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Entities;
using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Notification;
using FractalzBackendScheduler.Application.Domains.Responses.Notification;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Notification;

public class GetNotificationHandler: IRequestHandler<GetNotificationRequest, GetNotificationResponse>
{
    private readonly IRepository<Entities.Notification> _repositoryNotification;
    public GetNotificationHandler(IRepository<Entities.Notification> repositoryNotification)
    {
        _repositoryNotification = repositoryNotification ?? throw new ArgumentNullException(nameof(repositoryNotification));
    }
    public async Task<GetNotificationResponse> Handle(GetNotificationRequest request, CancellationToken cancellationToken)
    {
        var res = _repositoryNotification.Get(i => i.IdUser == request.IdUser).OrderBy((setting => setting.Date)).ToList();
        if (res == null)
        { return new GetNotificationResponse() { Message = "", Success = false }; }
        else 
        { return new GetNotificationResponse() { Success = true, Notification = res }; }
    }
}