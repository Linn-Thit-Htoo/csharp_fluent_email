using csharp_fluent_email.Services;
using System.Net;
using System.Net.Mail;

namespace csharp_fluent_email.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(opt =>
            {
                opt.SerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEmailService, EmailService>();

            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("lth1212001@gmail.com", ""),
                EnableSsl = true,
                UseDefaultCredentials = false
            };

            services
                .AddFluentEmail("lth1212001@gmail.com")
                .AddSmtpSender(smtpClient)
                .AddRazorRenderer();

            return services;
        }
    }
}
