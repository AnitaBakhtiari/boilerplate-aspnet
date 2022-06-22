using System.ComponentModel.DataAnnotations;
using Context.Rule;
using Core.Payload;
using Test.Rule.Constraint;
using Test.Rule.Derivation;

namespace Test.Payload;

[Rule(typeof(CheckEndDateMustBeGreaterThanStartDateRule), typeof(SetEndDateBaseOnStartDate))]
public class MyViewModel : IPayload
{
    [Required] [Value(DayEnum.Friday)] public DayEnum ValueEnum { get; set; }

    public DateTime Begin { get; set; }

    public DateTime End { get; set; }
}

public enum DayEnum
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}