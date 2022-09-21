using System;

namespace FractalzBackendScheduler.Application.Domains.Entities;

/// <summary>
/// Notification
/// </summary>
public class Notification
{
    /// <summary>
    /// Id
    /// </summary>
    //[Key]
    public Guid Id { get; set; }
    
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
    
    /// <summary>
    /// IsDeleted
    /// </summary>
    public bool IsDeleted { get; set; }
}