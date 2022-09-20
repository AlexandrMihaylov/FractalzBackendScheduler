using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Entities;
using FractalzBackendScheduler.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FractalzBackendScheduler.Infrastructure.Database.Repositories;

public class ConferenceRepository : IRepository<Conference>
{
    private readonly DbSet<Conference> _dbSet;
    private readonly SchedulerContext _context;

    /// <summary>
    /// ConferenceRepository
    /// </summary>
    /// <param name="context"></param>
    public ConferenceRepository(SchedulerContext context)
    {
        _context = context;
        _dbSet = context.Set<Conference>();
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Conference> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IEnumerable<Conference> Get(Func<Conference, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    /// <summary>
    /// FindById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Conference FindById(Guid id)
    {
        return _dbSet.Find(id);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Create(Conference item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Update(Conference item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    /// <summary>
    /// Remove
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Remove(Conference item)
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
    public IEnumerable<Conference> GetWithInclude(object includeProperty,
        params Expression<Func<Conference, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    /// <summary>
    /// GetWithInclude
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    public IEnumerable<Conference> GetWithInclude(Func<Conference, bool> predicate,
        params Expression<Func<Conference, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    /// <summary>
    /// Include
    /// </summary>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    private IQueryable<Conference> Include(params Expression<Func<Conference, object>>[] includeProperties)
    {
        IQueryable<Conference> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}