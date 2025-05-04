namespace csharp_fluent_email.Models;

public class EmailRequestModel
{
    public List<string> ToEmails { get; set; }
    public List<string>? CcEmails { get; set; }
    public List<string>? BccEmails { get; set; }
    public string Subject { get; set; }
    public string? Body { get; set; }
    public List<FileModel>? Files { get; set; }
}
