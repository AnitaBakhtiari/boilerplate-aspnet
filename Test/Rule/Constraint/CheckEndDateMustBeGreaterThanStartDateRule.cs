using Context.Rule;
using Core.Message;
using Test.Payload;

namespace Test.Rule.Constraint;

public class CheckEndDateMustBeGreaterThanStartDateRule : ConstraintRule<MyViewModel>
{
    public override bool Condition(MyViewModel request)
    {
        return request.Begin.CompareTo(request.End) > 0;
    }

    public override ResponseExceptionType GetMessage()
    {
        return ResponseExceptionType.EndDateGreaterTHanStartDate;
    }
}