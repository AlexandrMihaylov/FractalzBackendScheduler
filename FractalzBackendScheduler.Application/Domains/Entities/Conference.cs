using System;

namespace FractalzBackendScheduler.Application.Domains.Entities;

/// <summary>
/// Conference
/// </summary>
public class Conference
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