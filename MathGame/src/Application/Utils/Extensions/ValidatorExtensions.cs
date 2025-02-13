using FluentValidation.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathGame.src.Infrastructure.Common.Helpers;

namespace MathGame.src.Application.Utils.Extensions;

public static class ValidatorExtensions
{
    public static async void ValidateAndHandleErrors<T>(this IValidator<T> validator, T instance)
    {
        var result = validator.Validate(instance);
        if (!result.IsValid)
        {
            var errorMessage = string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage));

            throw new ValidationException(errorMessage);
        }
    }
}
