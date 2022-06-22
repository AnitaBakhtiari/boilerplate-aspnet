using System.Linq.Expressions;
using Core.Payload;

namespace Context.Rule;

public abstract class DerivationRule<T> : Rules<T> where T : IPayload
{
    protected internal readonly IList<string> TargetColumn;

    protected DerivationRule(params Expression<Func<T, object>>[] targetColumn)
    {
        TargetColumn = GetName(targetColumn);
    }

    public abstract override bool Condition(T request);

    public virtual object? GetDerivedValue(T request)
    {
        return null;
    }

    public static IList<string> GetName<TT>(params Expression<Func<TT, object>>[] expressions)
    {
        IList<string> properties = new List<string>();
        foreach (var expression in expressions)
        {
            if (expression.Body is not MemberExpression body)
                body = (((UnaryExpression) expression.Body).Operand as MemberExpression)!;

            if (body?.Member.Name != null)
                properties.Add(body.Member.Name);
        }

        return properties;
    }
}