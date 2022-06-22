using AutoMapper;
using Util.Paging;

namespace Util.Mapper;

public class MapperModel<TDestination>
{
    protected static readonly AutoMapper.Mapper mapper = new(new MapperConfiguration(cfg =>
    {
        cfg.AddMaps(typeof(TDestination).IsGenericType
            ? typeof(TDestination).GetGenericArguments().FirstOrDefault()!.IsGenericType
                ? typeof(TDestination).GetGenericArguments().FirstOrDefault()?.GetGenericArguments().FirstOrDefault()
                : typeof(TDestination).GetGenericArguments().FirstOrDefault()
            : typeof(TDestination));

        cfg.AddMaps(typeof(TDestination));
        cfg.CreateMap(typeof(Page<>), typeof(Page<>));
    }));

    public TDestination PlainToClass<TSource, TDestination>(TSource source)
    {
        return mapper.Map<TDestination>(source);
    }

    public IList<TDestination> PlainToClass<TSource>(IList<TSource> sources)
    {
        return sources.Select(source => mapper.Map<TDestination>(source)).ToList();
    }
}