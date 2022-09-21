using System;
using System.ComponentModel;
using System.Threading.Tasks;
using FractalzBackendScheduler.Application.Domains.Requests.Notification;
using FractalzBackendScheduler.Application.Domains.Responses.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FractalzBackendScheduler.Api.Controllers;
[ApiController]
[Route("/notification/")]
[DisplayName("Уведомления")]
[Produces("application/json")]
public class NotificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Создать уведомление
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createNotification")]
    [SwaggerResponse(StatusCodes.Status200OK, "Создать уведомление", typeof(CreateNotificationResponse))]
    public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

    /// <summary>
    /// GetNotification
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getNotification")]
    [SwaggerResponse(StatusCodes.Status200OK, "Получить уведомление", typeof(GetNotificationResponse))]
    public async Task<IActionResult> GetNotification([FromQuery] GetNotificationRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// DeleteNotification
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("deleteNotification")]
    [SwaggerResponse(StatusCodes.Status200OK, "Удалить уведомление", typeof(DeleteNotificationResponse))]
    public async Task<IActionResult> DeleteNotification([FromQuery] DeleteNotificationRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// UpdateNotification
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("updateNotification")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновить уведомление", typeof(UpdateNotificationResponse))]
    public async Task<IActionResult> UpdateNotification([FromQuery] UpdateNotificationRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}