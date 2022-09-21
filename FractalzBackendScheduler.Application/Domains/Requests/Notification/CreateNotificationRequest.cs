using System;
using FractalzBackendScheduler.Application.Domains.Responses.Notification;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Requests.Notification;

public class CreateNotificationRequest : IRequest<CreateNotificationResponse>
{
    /// <summary>
    /// IdUser
    /// </summary>
    public Guid IdUser { get; set; }
    
    /// <summary>
    /// Время
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Текст
    /// </summary>
    public string Text { get; set; }
}