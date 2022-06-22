using Context.Actions.Interfaces;
using Util.Mapper;

namespace Context.Actions;

public class BaseAction<TOutput> : MapperModel<TOutput>, IBaseAction<TOutput>
{
}