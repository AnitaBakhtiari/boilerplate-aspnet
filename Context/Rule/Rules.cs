using Core.Payload;

namespace Context.Rule;

public abstract class Rules<T> where T : IPayload
{
    public abstract bool Condition(T request);
}