using System;
using FractalzBackendScheduler.Application.Domains.Responses.Conference;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Requests.Conference;

public class GetConferenceRequest : IRequest<GetConferenceResponse>
{
    /// <summary>
    /// IdUser
    /// </summary>
    public Guid IdUser { get; set; }
}