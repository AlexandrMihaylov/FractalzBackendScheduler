using System;
using System.ComponentModel;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Requests.Conference;
using FractalzBackendScheduler.Application.Domains.Responses.Conference;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FractalzBackendScheduler.Api.Controllers;

[ApiController]
[Route("/conference/")]
[DisplayName("Конференции")]
[Produces("application/json")]
public class ConferenceController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConferenceController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Создать конференцию
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createConference")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создать конференцию", typeof(CreateConferenceResponse))]
    public async Task<IActionResult> CreateConference([FromBody] CreateConferenceRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// GetConference
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getConference")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить конференцию", typeof(GetConferenceResponse))]
    public async Task<IActionResult> GetConference([FromQuery] GetConferenceRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// DeleteConference
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteConference")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить конференцию", typeof(DeleteConferenceResponse))]
    public async Task<IActionResult> DeleteConference([FromQuery] DeleteConferenceRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// UpdateConference
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateConference")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновить конференцию", typeof(PutConferenceResponse))]
    public async Task<IActionResult> PutConference([FromQuery] PutConferenceRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}