using Context.Rule;
using Test.Payload;

namespace Test.Rule.Derivation;

public class SetEndDateBaseOnStartDate : DerivationRule<MyViewModel>
{
    public SetEndDateBaseOnStartDate() : base(t => t.End, t => t.Begin)
    {
    }

    public override bool Condition(MyViewModel request)
    {
        return request.Begin.CompareTo(DateTime.MinValue) > 0;
    }

    public override object GetDerivedValue(MyViewModel request)
    {
        return request.Begin.AddDays(1);
    }
}