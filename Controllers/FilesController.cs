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

    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage([FromForm] UploadImageRequest request, CancellationToken ct)
    {
        await _fileService.UploadImageAsync(request.Image, ct);

        return Created();
    }
}
