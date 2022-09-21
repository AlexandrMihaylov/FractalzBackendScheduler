using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Meeting;
using FractalzBackendScheduler.Application.Domains.Responses.Meeting;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Meeting;

public class DeleteMeetingHandler: IRequestHandler<DeleteMeetingRequest, DeleteMeetingResponse>
{
    private readonly IRepository<Entities.Meeting> _repositoryMeeting;
    public DeleteMeetingHandler(IRepository<Entities.Meeting> repositoryMeeting)
    {
        _repositoryMeeting = repositoryMeeting ?? throw new ArgumentNullException(nameof(repositoryMeeting));
    }
    public async Task<DeleteMeetingResponse> Handle(DeleteMeetingRequest request, CancellationToken cancellationToken)
    {
        var meeting = _repositoryMeeting.Get(i => i.Id == request.Id).FirstOrDefault();
        meeting.IsDeleted = true;

        var res = _repositoryMeeting.Update(meeting);
        if (res == null)
        { return new DeleteMeetingResponse() { Message = "", Success = false }; }
        else 
        { return new DeleteMeetingResponse() { Success = true }; }
    }
}