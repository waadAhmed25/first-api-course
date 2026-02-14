namespace DNAAnalysis.Shared.CommonResult;

public record Error(string Code, string Description)
{
    public static Error InvalidCredentials(string code)
        => new(code, "Invalid Email or Password");

    public static Error Validation(string code, string description)
        => new(code, description);

        public static Error NotFound()
    => new("NotFound", "Resource Not Found");

}
