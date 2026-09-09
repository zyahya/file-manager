namespace FileManager.Services;

public interface IFileService
{
    Task<Guid> UploadAsync(IFormFile file, CancellationToken ct);

    Task<IEnumerable<Guid>> UploadMultipleAsync(IFormFileCollection files, CancellationToken ct);
}
