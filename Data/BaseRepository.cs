using Domain.Entities;
using Domain.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
    {
        public readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<int> Count()
        {
            return await _context.Set<TEntity>().Where(entity => entity.IsDeleted == false).CountAsync();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            var add = await _context.Set<TEntity>().AddAsync(entity);
            var saved = await _context.SaveChangesAsync();
            if (saved > 0) return entity;
            return null;
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public virtual async Task<bool> Delete(TEntity entity, Guid updatedBy)
        {
            entity.IsDeleted = true;
            entity.LastUpdatedOn = DateTime.UtcNow;
            entity.LastUpdatedBy = updatedBy;
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public virtual async Task<bool> Delete(TEntity entity, Guid updatedBy, string? LastUpdatedByName, string? LastUpdatedByEmail)
        {
            entity.IsDeleted = true;
            entity.LastUpdatedOn = DateTime.UtcNow;
            entity.LastUpdatedBy = updatedBy;
            entity.LastUpdatedByName = LastUpdatedByName;
            entity.LastUpdatedByEmail = LastUpdatedByEmail;
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<TEntity> GetById(Guid Id) => await _context.Set<TEntity>()
                .Where(e => e.Id == Id && e.IsDeleted == false)
                .FirstOrDefaultAsync();

        public virtual async Task<IEnumerable<TEntity>> ListAll()
        {
            return await _context.Set<TEntity>().Where(entity => entity.IsDeleted == false).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> ListPaginated(int pageSize, int page)
        {
            var ignore = page * pageSize;
            return await _context.Set<TEntity>().Where(entity => entity.IsDeleted == false).Skip(ignore).Take(pageSize).ToListAsync();
        }

        public virtual async Task<bool> Update(TEntity entity, Guid updatedBy)
        {
            entity.LastUpdatedOn = DateTime.UtcNow;
            entity.LastUpdatedBy = updatedBy;
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public virtual async Task<bool> Update(TEntity entity, Guid updatedBy, string? LastUpdatedByName, string? LastUpdatedByEmail)
        {
            entity.LastUpdatedOn = DateTime.UtcNow;
            entity.LastUpdatedBy = updatedBy;
            entity.LastUpdatedByName = LastUpdatedByName;
            entity.LastUpdatedByEmail = LastUpdatedByEmail;
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public virtual async Task<bool> Update(TEntity entity)
        {
            entity.LastUpdatedOn = DateTime.UtcNow;
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
