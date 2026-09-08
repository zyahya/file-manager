namespace FileManager.Services;

public interface IFileService
{
    Task<Guid> UploadAsync(IFormFile file, CancellationToken ct);
}
