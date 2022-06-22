using System.ComponentModel.DataAnnotations;
using Core.Message;
using Http.Exception;

namespace Context.Rule;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
public class ValueAttribute : ValidationAttribute
{
    private readonly object[] _values;

    public ValueAttribute(params object[] values) : base(() =>
        new BadRequestException(ResponseExceptionType.ValueIsNotValid).Message)
    {
        _values = values;
    }

    public override bool IsValid(object? value)
    {
        return _values.Contains(value);
    }
}