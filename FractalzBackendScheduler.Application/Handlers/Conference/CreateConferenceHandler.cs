using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Conference;
using FractalzBackendScheduler.Application.Domains.Responses.Conference;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Conference;

public class CreateConferenceHandler: IRequestHandler<CreateConferenceRequest, CreateConferenceResponse>
{
    private readonly IRepository<Entities.Conference> _repositoryConference;
    public CreateConferenceHandler(IRepository<Entities.Conference> repositoryConference) 
    {
        _repositoryConference = repositoryConference ?? throw new ArgumentNullException(nameof(repositoryConference));
    }
    public async Task<CreateConferenceResponse> Handle(CreateConferenceRequest request, CancellationToken cancellationToken)
    {
        var conference = new Entities.Conference();

        conference.IdUser = request.IdUser;
        conference.DateStart = request.DateStart;
        conference.DateEnd = request.DateEnd;
        conference.Text = request.Text;
        conference.IsDeleted = false;
        
        var res = _repositoryConference.Create(conference);

        if (res == 0)
        { return new CreateConferenceResponse() { Message = "", Success = false }; }
        else 
        { return new CreateConferenceResponse() { Success = true }; }
    }
}