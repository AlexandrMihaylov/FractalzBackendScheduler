using FractalzBackendScheduler.Application.Domains.Responses.Conference;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Requests.Conference;

public class DeleteConferenceRequest : IRequest<DeleteConferenceResponse>
{
    /// <summary>
    /// Id
    /// </summary>
    //[Key]
    public Guid Id { get; set; }
}