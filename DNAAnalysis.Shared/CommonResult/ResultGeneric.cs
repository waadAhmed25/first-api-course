namespace DNAAnalysis.Shared.CommonResult;

public class Result<T> : Result
{
    public T? Value { get; private set; }
    public List<Error>? Errors { get; private set; }

    private Result(T value)
    {
        IsSuccess = true;
        Value = value;
    }

    private Result(List<Error> errors)
    {
        IsSuccess = false;
        Errors = errors;
    }

    // 🔥 Implicit from T
    public static implicit operator Result<T>(T value)
        => new(value);

    // 🔥 Implicit from Error
    public static implicit operator Result<T>(Error error)
        => new(new List<Error> { error });

    // 🔥 Implicit from List<Error>
    public static implicit operator Result<T>(List<Error> errors)
        => new(errors);
}
