using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Meeting;
using FractalzBackendScheduler.Application.Domains.Responses.Meeting;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Meeting;

public class GetMeetingHandler: IRequestHandler<GetMeetingRequest, GetMeetingResponse>
{
    private readonly IRepository<Entities.Meeting> _repositoryMeeting;
    public GetMeetingHandler(IRepository<Entities.Meeting> repositoryMeeting)
    {
        _repositoryMeeting = repositoryMeeting ?? throw new ArgumentNullException(nameof(repositoryMeeting));
    }
    public async Task<GetMeetingResponse> Handle(GetMeetingRequest request, CancellationToken cancellationToken)
    {
        var reqdate = request.DateTime;
        
        DateTime reqstart = new DateTime(reqdate.Year, reqdate.Month, reqdate.Day, 0, 0, 0, 0);
        DateTime reqend = new DateTime(reqdate.Year, reqdate.Month, reqdate.Day, 23, 59, 59, 999);

        var res = _repositoryMeeting.Get(
            i => i.IdUser == request.IdUser &&
                 i.DateStart >= reqstart &&
                 i.DateStart <= reqend
        ).OrderBy((setting => setting.DateStart)).ToList();
        
        if (res == null)
        { return new GetMeetingResponse() { Message = "", Success = false }; }
        else 
        { return new GetMeetingResponse() { Success = true, Meeting = res }; }
    }
}