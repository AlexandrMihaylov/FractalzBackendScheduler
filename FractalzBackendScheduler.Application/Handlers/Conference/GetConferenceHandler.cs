using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Entities;
using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Requests.Conference;
using FractalzBackendScheduler.Application.Domains.Responses.Conference;
using MediatR;

namespace FractalzBackendScheduler.Application.Handlers.Conference;

public class GetConferenceHandler: IRequestHandler<GetConferenceRequest, GetConferenceResponse>
{
    private readonly IRepository<Domains.Entities.Conference> _repositoryConference;
    public GetConferenceHandler(IRepository<Domains.Entities.Conference> repositoryConference)
    {
        _repositoryConference = repositoryConference ?? throw new ArgumentNullException(nameof(repositoryConference));
    }
    public async Task<GetConferenceResponse> Handle(GetConferenceRequest request, CancellationToken cancellationToken)
    {
        var res = _repositoryConference.Get(i => i.IdUser == request.IdUser).OrderBy((setting => setting.DateStart)).ToList();
        if (res == null)
        { return new GetConferenceResponse() { Message = "", Success = false }; }
        else 
        { return new GetConferenceResponse() { Success = true, Conference = res }; }
    }
}