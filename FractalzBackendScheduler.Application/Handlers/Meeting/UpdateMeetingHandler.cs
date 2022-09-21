using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Meeting;
using FractalzBackendScheduler.Application.Domains.Responses.Meeting;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Meeting;

public class UpdateMeetingHandler: IRequestHandler<UpdateMeetingRequest, UpdateMeetingResponse>
{
    private readonly IRepository<Entities.Meeting> _repositoryMeeting;
    public UpdateMeetingHandler(IRepository<Entities.Meeting> repositoryMeeting) 
    {
        _repositoryMeeting = repositoryMeeting ?? throw new ArgumentNullException(nameof(repositoryMeeting));
    }
    public async Task<UpdateMeetingResponse> Handle(UpdateMeetingRequest request, CancellationToken cancellationToken)
    {
        var meeting = _repositoryMeeting.Get(i => i.Id == request.Id).FirstOrDefault();
        
        DateTime zero = new DateTime(1,1,1,0,0,0);
        if (request.DateStart != zero){meeting.DateStart = request.DateStart;}
        if (request.DateEnd != zero){meeting.DateEnd = request.DateEnd;}
        if (request.Text != null){meeting.Text = request.Text;}
        
        var res = _repositoryMeeting.Update(meeting);

        if (res == 0)
        { return new UpdateMeetingResponse() { Message = "", Success = false }; }
        else 
        { return new UpdateMeetingResponse() { Success = true }; }
    }
}