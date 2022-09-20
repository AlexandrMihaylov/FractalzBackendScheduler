using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Entities;
using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Meeting;
using FractalzBackendScheduler.Application.Domains.Responses.Meeting;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Meeting;

public class CreateMeetingHandler: IRequestHandler<CreateMeetingRequest, CreateMeetingResponse>
{
    private readonly IRepository<Entities.Meeting> _repositoryMeeting;
    public CreateMeetingHandler(IRepository<Entities.Meeting> repositoryMeeting) 
    {
        _repositoryMeeting = repositoryMeeting ?? throw new ArgumentNullException(nameof(repositoryMeeting));
    }
    public async Task<CreateMeetingResponse> Handle(CreateMeetingRequest request, CancellationToken cancellationToken)
    {
        var meeting = new Entities.Meeting();

        meeting.IdUser = request.IdUser;
        meeting.DateStart = request.DateStart;
        meeting.DateEnd = request.DateEnd;
        meeting.Text = request.Text;
        
        var res = _repositoryMeeting.Create(meeting);

        if (res == 0)
        { return new CreateMeetingResponse() { Message = "", Success = false }; }
        else 
        { return new CreateMeetingResponse() { Success = true }; }
    }
}