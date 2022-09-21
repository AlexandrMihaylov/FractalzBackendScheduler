using System;
using System.ComponentModel;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Requests.Meeting;
using FractalzBackendScheduler.Application.Domains.Responses.Meeting;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FractalzBackendScheduler.Api.Controllers;

[ApiController]
[Route("/meeting/")]
[DisplayName("Встречи")]
[Produces("application/json")]
public class MeetingController : ControllerBase
{
    private readonly IMediator _mediator;

    public MeetingController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Создать встречу
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createMeeting")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создать встречу", typeof(CreateMeetingResponse))]
    public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// GetMeeting
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getMeeting")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить встречу", typeof(GetMeetingResponse))]
    public async Task<IActionResult> GetMeeting([FromQuery] GetMeetingRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// DeleteMeeting
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteMeeting")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить встречу", typeof(DeleteMeetingResponse))]
    public async Task<IActionResult> DeleteMeeting([FromQuery] DeleteMeetingRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// UpdateMeeting
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateMeeting")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновить встречу", typeof(UpdateMeetingResponse))]
    public async Task<IActionResult> UpdateMeeting([FromQuery] UpdateMeetingRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}