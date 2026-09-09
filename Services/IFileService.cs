namespace FileManager.Services;

public interface IFileService
{
    Task<Guid> UploadAsync(IFormFile file, CancellationToken ct = default);

    Task<IEnumerable<Guid>> UploadMultipleAsync(IFormFileCollection files, CancellationToken ct = default);

    Task UploadImageAsync(IFormFile image, CancellationToken ct = default);
}
