using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Entities;
using FractalzBackendScheduler.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FractalzBackendScheduler.Infrastructure.Database.Repositories;

public class NotificationRepository : IRepository<Notification>
{
    private readonly DbSet<Notification> _dbSet;
    private readonly SchedulerContext _context;

    /// <summary>
    /// NotificationRepository
    /// </summary>
    /// <param name="context"></param>
    public NotificationRepository(SchedulerContext context)
    {
        _context = context;
        _dbSet = context.Set<Notification>();
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Notification> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IEnumerable<Notification> Get(Func<Notification, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    /// <summary>
    /// FindById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Notification FindById(Guid id)
    {
        return _dbSet.Find(id);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Create(Notification item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Update(Notification item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    /// <summary>
    /// Remove
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Remove(Notification item)
    {
        _dbSet.Remove(item);
        return _context.SaveChanges();
    }

    /// <summary>
    /// GetWithInclude
    /// </summary>
    /// <param name="includeProperty"></param>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    public IEnumerable<Notification> GetWithInclude(object includeProperty,
        params Expression<Func<Notification, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    /// <summary>
    /// GetWithInclude
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    public IEnumerable<Notification> GetWithInclude(Func<Notification, bool> predicate,
        params Expression<Func<Notification, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    /// <summary>
    /// Include
    /// </summary>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    private IQueryable<Notification> Include(params Expression<Func<Notification, object>>[] includeProperties)
    {
        IQueryable<Notification> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}