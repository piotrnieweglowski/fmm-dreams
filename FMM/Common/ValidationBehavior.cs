using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace FMM.Common
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
    
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();
    
            if (errors.Any())
            {
                var errorBuilder = new StringBuilder();
                errorBuilder.AppendLine("Invalid command, reason: ");
                foreach (var error in errors)
                {
                    errorBuilder.AppendLine(error.ErrorMessage);
                }
    
                throw new Exception(errorBuilder.ToString());
            }
    
            return next();
        }
    }
}