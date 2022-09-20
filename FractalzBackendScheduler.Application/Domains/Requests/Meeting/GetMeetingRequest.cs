using System;
using FractalzBackendScheduler.Application.Domains.Responses.Meeting;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Requests.Meeting;

public class GetMeetingRequest : IRequest<GetMeetingResponse>
{
    /// <summary>
    /// IdUser
    /// </summary>
    public Guid IdUser { get; set; }
}