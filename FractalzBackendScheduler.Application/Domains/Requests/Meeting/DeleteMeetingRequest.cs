using MediatR;
using FractalzBackendScheduler.Application.Domains.Responses.Meeting;

namespace FractalzBackendScheduler.Application.Domains.Requests.Meeting;

public class DeleteMeetingRequest : IRequest<DeleteMeetingResponse>
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
}