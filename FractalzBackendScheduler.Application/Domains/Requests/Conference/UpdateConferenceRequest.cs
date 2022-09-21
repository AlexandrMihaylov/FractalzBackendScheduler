using System;
using FractalzBackendScheduler.Application.Domains.Responses.Conference;
using MediatR;

namespace FractalzBackendScheduler.Application.Domains.Requests.Conference;

public class UpdateConferenceRequest : IRequest<UpdateConferenceResponse>
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Время начала
    /// </summary>
    public DateTime DateStart { get; set; }
    
    /// <summary>
    /// Время конца
    /// </summary>
    public DateTime DateEnd { get; set; }
    
    /// <summary>
    /// Текст
    /// </summary>
    public string Text { get; set; }
}