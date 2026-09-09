namespace FileManager.Services;

public class FileService(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context) : IFileService
{
    private readonly string _filesPath = $"{webHostEnvironment.WebRootPath}/uploads";
    private readonly string _imagesPath = $"{webHostEnvironment.WebRootPath}/images";
    private readonly ApplicationDbContext _context = context;

    public async Task<Guid> UploadAsync(IFormFile file, CancellationToken ct)
    {
        var uploadedFile = await SaveFile(file, ct);

        await _context.Files.AddAsync(uploadedFile, cancellationToken: ct);
        await _context.SaveChangesAsync(ct);

        return uploadedFile.Id;
    }

    public async Task UploadImageAsync(IFormFile image, CancellationToken ct = default)
    {
        var path = Path.Combine(_imagesPath, NormalizeFileName(image.FileName));

        using var stream = File.Create(path);
        await image.CopyToAsync(stream, ct);
    }

    public async Task<IEnumerable<Guid>> UploadMultipleAsync(IFormFileCollection files, CancellationToken ct)
    {
        List<UploadedFile> uploadedFiles = [];

        foreach (var file in files)
        {
            var uploadedFile = await SaveFile(file, ct);
            uploadedFiles.Add(uploadedFile);
        }

        await _context.Files.AddRangeAsync(uploadedFiles, ct);
        await _context.SaveChangesAsync(ct);

        return uploadedFiles.Select(x => x.Id);
    }

    private async Task<UploadedFile> SaveFile(IFormFile file, CancellationToken ct)
    {
        var randomFileName = Path.GetRandomFileName();

        var uploadedFile = new UploadedFile
        {
            FileName = file.FileName,
            StoredFileName = randomFileName,
            ContentType = file.ContentType,
            FileExtension = Path.GetExtension(file.FileName)
        };

        var path = Path.Combine(_filesPath, randomFileName);

        using var stream = File.Create(path);
        await file.CopyToAsync(stream, ct);

        return uploadedFile;
    }

    private static string NormalizeFileName(string file)
    {
        return file.Replace(" ", "_");
    }
}
