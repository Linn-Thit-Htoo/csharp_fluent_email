using csharp_fluent_email.Models;

namespace csharp_fluent_email.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailRequestModel requestModel, CancellationToken cs = default);
}
