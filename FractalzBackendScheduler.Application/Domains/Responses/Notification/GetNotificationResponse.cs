using System.Collections.Generic;

namespace FractalzBackendScheduler.Application.Domains.Responses.Notification;

public class GetNotificationResponse : BasicResponse
{
    public List<Entities.Notification> Notification { get; set; }
}