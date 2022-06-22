using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Context.Rule.Model;
using Core.Message.ResponseMessage;
using Core.Payload;
using Http.Exception;
using Microsoft.Extensions.Localization;

namespace Context.Rule;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class RuleAttribute : ValidationAttribute
{
    private readonly Type[] _rules;

    public RuleAttribute(params Type[] rules)
    {
        _rules = rules;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var rules = (from rule in _rules
            select Activator.CreateInstance(rule)
            into instance
            where instance != null
            select new SortRules {Rule = instance}).ToList();

        foreach (var ruleClass in rules)
            using (ruleClass)
            {
                var rule = ruleClass.Rule;
                var type = rule.GetType();

                if (IsInstanceOfGenericType(typeof(DerivationRule<>), rule))
                {
                    var targets = (IList<string>) type.GetField(nameof(DerivationRule<IPayload>.TargetColumn),
                        BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(rule)!;

                    var derivationCondition = type.GetMethod(nameof(DerivationRule<IPayload>.Condition))
                        ?.Invoke(rule, new[] {value})!;

                    if (!(bool) derivationCondition)
                        continue;

                    var derivedValue = type.GetMethod(nameof(DerivationRule<IPayload>.GetDerivedValue))
                        ?.Invoke(rule, new[] {value})!;

                    foreach (var target in targets) value?.GetType().GetProperty(target)?.SetValue(value, derivedValue);
                }

                else
                {
                    var localizationService =
                        (IStringLocalizer<ErrorMessage>) validationContext.GetService(
                            typeof(IStringLocalizer<ErrorMessage>))!;
                    var constraintCondition =
                        type.GetMethod(nameof(ConstraintRule<IPayload>.Condition))!.Invoke(rule, new[] {value})!;
                    if (!(bool) constraintCondition) continue;
                    var messageResult =
                        type.GetMethod(nameof(ConstraintRule<IPayload>.GetMessage))!.Invoke(rule, new object[] { });
                    if (messageResult != null)
                        new BadRequestException(localizationService[messageResult.ToString()!]);
                }
            }

        return ValidationResult.Success!;
    }

    private static bool IsInstanceOfGenericType(Type genericType, object instance)
    {
        var type = instance.GetType();
        while (type != null)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType) return true;
            type = type.BaseType;
        }

        return false;
    }
}