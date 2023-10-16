using CSharpFunctionalExtensions;

namespace LEGO.CSharpExamples.Infrastructure;

public static class DomainErrorHandler
{
    public static T HandleDomainError<T>(this Result<T, Error> result)
    {
        if (result.IsFailure)
        {
            throw new Exception(result.Error.Message);
        }

        return result.Value;
    }
}