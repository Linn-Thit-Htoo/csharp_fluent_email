using csharp_fluent_email.Models;
using csharp_fluent_email.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp_fluent_email.Endpoints;

public static class EmailEndpoints
{
    public static void UseEmailEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/SendEmail", async ([FromBody] EmailRequestModel requestModel, IEmailService emailService) =>
        {
            await emailService.SendEmailAsync(requestModel);
            return Results.Ok("Email Sending Successful.");
        }).WithName("SendEmail").WithOpenApi();
    }
}
