using System;
using FractalzBackendScheduler.Application.Domains.Responses.Notification;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Requests.Notification;

public class GetNotificationRequest : IRequest<GetNotificationResponse>
{
    /// <summary>
    /// IdUser
    /// </summary>
    public Guid IdUser { get; set; }
}