using csharp_fluent_email.Models;
using FluentEmail.Core;

namespace csharp_fluent_email.Services
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmailFactory _fluentEmailFactory;

        public EmailService(IFluentEmailFactory fluentEmailFactory)
        {
            _fluentEmailFactory = fluentEmailFactory;
        }

        public async Task SendEmailAsync(EmailRequestModel requestModel, CancellationToken cs = default)
        {
            try
            {
                var email = _fluentEmailFactory
                    .Create()
                    .Subject(requestModel.Subject);

                if (requestModel.Body is not null)
                {
                    email.Body(requestModel.Body, isHtml: true);
                }

                requestModel.ToEmails.ForEach(x => email.To(x));

                if (requestModel.CcEmails is not null && requestModel.CcEmails.Count > 0)
                {
                    requestModel.CcEmails.ForEach(x => email.CC(x));
                }

                if (requestModel.BccEmails is not null && requestModel.BccEmails.Count > 0)
                {
                    requestModel.BccEmails.ForEach(x => email.BCC(x));
                }

                if (requestModel.Files is not null && requestModel.Files.Count > 0)
                {
                    foreach (var file in requestModel.Files)
                    {
                        email.AttachFromFilename(
                            file.FilePath,
                            attachmentName: file.FileName,
                            contentType: file.ContentType
                        );
                    }
                }

                await email.SendAsync(cs);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
