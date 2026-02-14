namespace DNAAnalysis.Services.Abstraction
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
