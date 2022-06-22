using Core.Message;
using Core.Payload;

namespace Context.Rule;

public abstract class ConstraintRule<T> : Rules<T> where T : IPayload
{
    public abstract override bool Condition(T request);

    public virtual ResponseExceptionType GetMessage()
    {
        return ResponseExceptionType.BadRequest;
    }
}