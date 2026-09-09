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

        return Ok(fileId);
    }

    [HttpPost("upload-multiple")]
    public async Task<IActionResult> UploadMultiple([FromForm] UploadMultipleFilesRequest request, CancellationToken ct)
    {
        var fileIds = await _fileService.UploadMultipleAsync(request.Files, ct);

        return Ok(fileIds);
    }
}
