using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Entities;
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
        var res = _repositoryMeeting.Get(i => i.IdUser == request.IdUser).OrderBy((setting => setting.DateStart)).ToList();
        if (res == null)
        { return new GetMeetingResponse() { Message = "", Success = false }; }
        else 
        { return new GetMeetingResponse() { Success = true, Meeting = res }; }
    }
}