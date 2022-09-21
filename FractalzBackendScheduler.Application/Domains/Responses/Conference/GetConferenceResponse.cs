namespace FractalzBackendScheduler.Application.Domains.Responses.Conference;
public class GetConferenceResponse : BasicResponse
{
    public List<Entities.Conference> Conference { get; set; }
}