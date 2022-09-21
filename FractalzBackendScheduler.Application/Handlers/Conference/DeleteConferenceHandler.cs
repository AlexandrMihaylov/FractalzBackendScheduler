using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Conference;
using FractalzBackendScheduler.Application.Domains.Responses.Conference;
using MediatR;

namespace FractalzBackendScheduler.Application.Handlers.Conference;

public class DeleteConferenceHandler: IRequestHandler<DeleteConferenceRequest, DeleteConferenceResponse>
{
    private readonly IRepository<Domains.Entities.Conference> _repositoryConference;
    public DeleteConferenceHandler(IRepository<Domains.Entities.Conference> repositoryConference)
    {
        _repositoryConference = repositoryConference ?? throw new ArgumentNullException(nameof(repositoryConference));
    }
    public async Task<DeleteConferenceResponse> Handle(DeleteConferenceRequest request, CancellationToken cancellationToken)
    {
        var conference = _repositoryConference.Get(i => i.Id == request.Id).FirstOrDefault();
        conference.IsDeleted = true;

        var res = _repositoryConference.Update(conference);
        
        if (res == null)
        { return new DeleteConferenceResponse() { Message = "", Success = false }; }
        else 
        { return new DeleteConferenceResponse() { Success = true }; }
    }
}