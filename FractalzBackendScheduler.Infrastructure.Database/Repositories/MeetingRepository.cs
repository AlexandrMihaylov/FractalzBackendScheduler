using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FractalzBackendScheduler.Application.Abstractions;
using FractalzBackendScheduler.Application.Domains.Entities;
using FractalzBackendScheduler.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FractalzBackendScheduler.Infrastructure.Database.Repositories;

public class MeetingRepository : IRepository<Meeting>
{
    private readonly DbSet<Meeting> _dbSet;
    private readonly SchedulerContext _context;

    /// <summary>
    /// MeetingRepository
    /// </summary>
    /// <param name="context"></param>
    public MeetingRepository(SchedulerContext context)
    {
        context.Database.EnsureCreated();
        _context = context;
        _dbSet = context.Set<Meeting>();
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Meeting> Get()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IEnumerable<Meeting> Get(Func<Meeting, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }

    /// <summary>
    /// FindById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Meeting FindById(Guid id)
    {
        return _dbSet.Find(id);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Create(Meeting item)
    {
        _dbSet.Add(item);
        return _context.SaveChanges();
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Update(Meeting item)
    {
        _context.Entry(item).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    /// <summary>
    /// Remove
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int Remove(Meeting item)
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
    public IEnumerable<Meeting> GetWithInclude(object includeProperty,
        params Expression<Func<Meeting, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    /// <summary>
    /// GetWithInclude
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    public IEnumerable<Meeting> GetWithInclude(Func<Meeting, bool> predicate,
        params Expression<Func<Meeting, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    /// <summary>
    /// Include
    /// </summary>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    private IQueryable<Meeting> Include(params Expression<Func<Meeting, object>>[] includeProperties)
    {
        IQueryable<Meeting> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}