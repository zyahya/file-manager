namespace FileManager.Entities;

public class UploadedFile
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string FileName { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public string StoredFileName { get; set; } = default!;
    public string FileExtension { get; set; } = default!;
}
