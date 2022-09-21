namespace FractalzBackendScheduler.Application.Domains.Responses.Meeting;
public class GetMeetingResponse : BasicResponse
{
    public List<Entities.Meeting> Meeting { get; set; }
}