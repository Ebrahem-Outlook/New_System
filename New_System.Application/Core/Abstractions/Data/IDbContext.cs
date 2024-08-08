using Microsoft.EntityFrameworkCore;
using New_System.Domain.Core.BaseType;

namespace New_System.Application.Core.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
}
