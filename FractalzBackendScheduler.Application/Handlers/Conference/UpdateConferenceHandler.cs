using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Entities;
using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Conference;
using FractalzBackendScheduler.Application.Domains.Responses.Conference;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Handlers.Conference;

public class UpdateConferenceHandler: IRequestHandler<UpdateConferenceRequest, UpdateConferenceResponse>
{
    private readonly IRepository<Entities.Conference> _repositoryConference;
    public UpdateConferenceHandler(IRepository<Entities.Conference> repositoryConference) 
    {
        _repositoryConference = repositoryConference ?? throw new ArgumentNullException(nameof(repositoryConference));
    }
    public async Task<UpdateConferenceResponse> Handle(UpdateConferenceRequest request, CancellationToken cancellationToken)
    {
        var conference = _repositoryConference.Get(i => i.Id == request.Id).FirstOrDefault();
        
        DateTime zero = new DateTime(1,1,1,0,0,0);
        if (request.DateStart != zero){conference.DateStart = request.DateStart;}
        if (request.DateEnd != zero){conference.DateEnd = request.DateEnd;}
        if (request.Text != null){conference.Text = request.Text;}
        
        var res = _repositoryConference.Update(conference);

        if (res == 0)
        { return new UpdateConferenceResponse() { Message = "", Success = false }; }
        else 
        { return new UpdateConferenceResponse() { Success = true }; }
    }
}