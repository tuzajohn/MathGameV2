using MathGame.src.Infrastructure.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.src.Infrastructure.Common.CustomExceptions;

public class GenericException : Exception
{
    public GenericException(MessageResponse response)
        : base(response.Message)
    {

    }

    public GenericException(string[] errors) : base("Multiple errors occurred. See error details.")
    {
        Errors = errors;
    }

    public string[] Errors { get; set; }
}
