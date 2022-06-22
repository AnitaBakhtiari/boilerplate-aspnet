// using Util.Mapper;
// using Util.Paging;
//
// namespace DataCore.Uti;
//
// public abstract class MapperPagingModel<TDestination> : MapperModel<TDestination>
// {
//     public TDestination PlainToClass<TSource>(Page<TSource> source)
//     {
//         var a = typeof(TDestination).GetGenericArguments().FirstOrDefault();
//
//         return Mapper.Map<TDestination>(source);
//     }
// }

