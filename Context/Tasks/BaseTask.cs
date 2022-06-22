using Context.Tasks.Interface;
using Util.Mapper;

namespace Context.Tasks;

public class BaseTask<TOutput> : MapperModel<TOutput>, IBaseTask<TOutput>
{
}