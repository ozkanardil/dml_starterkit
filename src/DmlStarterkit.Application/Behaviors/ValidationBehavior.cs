using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DmlStarterkit.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : class
{
    private readonly bool _hasValidators;
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
        _hasValidators = _validators.Any();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_hasValidators)
            return await next();

        var context = new ValidationContext<TRequest>(request);
        ValidationResult[] validationResults =
                    await Task.WhenAll(_validators.Select(v =>
                           v.ValidateAsync(context, cancellationToken)));

        List<ValidationFailure> failures =
                    validationResults.SelectMany(r => r.Errors)
                          .Where(f => f != null).ToList();

        if (!failures.Any())
            return await next();

        throw new Exception(failures[0].ErrorMessage);
    }

}