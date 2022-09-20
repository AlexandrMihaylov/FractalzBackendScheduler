using System.Collections.Generic;
using FractalzBackendScheduler.Application.Domains.Entities;
namespace FractalzBackendScheduler.Application.Domains.Responses.Conference;


public class GetConferenceResponse : BasicResponse
{
    public List<Entities.Conference> Conference { get; set; }
}