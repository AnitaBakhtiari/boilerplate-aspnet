using System.Reflection;
using AutoMapper;
using DataCore.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Util.Paging;

namespace DataSql.Data.Repository;

public class BaseRepository<TEntity, TContext> : CoreRepository<TEntity, TContext>, IBaseRepository<TEntity>
    where TEntity : class where TContext : DbContext
{
    public BaseRepository(TContext context) : base(context)
    {
    }
}

public class BaseRepository<TEntity, TContext, TMapper> : CoreRepository<TEntity, TContext>, IBaseRepository<TEntity>
    where TEntity : class where TContext : DbContext where TMapper : IMapper
{
    protected readonly IMapper _mapper;

    public BaseRepository(TContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }
}