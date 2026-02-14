namespace DNAAnalysis.Shared.CommonResult;

public class Result
{
    public bool IsSuccess { get; protected set; }
    public bool IsFailure => !IsSuccess;
}
