using AutoMapper;
using DataCore.Data.Repository;
using Util.Paging;

namespace DataSql.Data.Repository;

public class BaseRepository<TEntity> : CoreRepository<TEntity>, IBaseRepository<TEntity> where TEntity : class
{
    protected static readonly Mapper mapper = new(new MapperConfiguration(cfg =>
    {
        cfg.AddMaps(typeof(TEntity).IsGenericType
            ? typeof(TEntity).GetGenericArguments().FirstOrDefault()!.IsGenericType
                ? typeof(TEntity).GetGenericArguments().FirstOrDefault()?.GetGenericArguments().FirstOrDefault()
                : typeof(TEntity).GetGenericArguments().FirstOrDefault()
            : typeof(TEntity));

        cfg.AddMaps(typeof(TEntity));
        cfg.CreateMap(typeof(Page<>), typeof(Page<>));
    }));
}