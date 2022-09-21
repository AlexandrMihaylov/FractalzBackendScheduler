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
        var reqdate = request.DateTime;
        
        DateTime reqstart = new DateTime(reqdate.Year, reqdate.Month, reqdate.Day, 0, 0, 0, 0);
        DateTime reqend = new DateTime(reqdate.Year, reqdate.Month, reqdate.Day, 23, 59, 59, 999);

        var res = _repositoryNotification.Get(
            i => i.IdUser == request.IdUser &&
                 i.Date >= reqstart &&
                 i.Date <= reqend
        ).OrderBy((setting => setting.Date)).ToList();
        
        if (res == null)
        { return new GetNotificationResponse() { Message = "", Success = false }; }
        else 
        { return new GetNotificationResponse() { Success = true, Notification = res }; }
    }
}