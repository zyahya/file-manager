using FileManager.Contracts;

namespace FileManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController(IFileService fileService) : ControllerBase
{
    private readonly IFileService _fileService = fileService;

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] UploadFileRequest request, CancellationToken ct)
    {
        var fileId = await _fileService.UploadAsync(request.File, ct);
        Console.WriteLine("Hello, World!");

        return Created();
    }
}
