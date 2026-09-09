using FileManager.Settings;
using FluentValidation;

namespace FileManager.Contracts;

public class UploadFileRequestValidator : AbstractValidator<UploadFileRequest>
{
    public UploadFileRequestValidator()
    {
        RuleFor(x => x.File)
            .Must(file => file.Length <= FileSettings.MaxSizeInBytes)
            .When(x => x.File != null)
            .WithMessage($"File size must not exceed {FileSettings.MaxSizeInMB} MB.");

        RuleFor(x => x.File)
            .Must(BeAllowedSignature)
            .When(x => x.File != null)
            .WithMessage("File type is not allowed.");

        RuleFor(x => x.File)
            .Must(file => HasInvalidFileNameChars(file.FileName))
            .When(x => x.File != null)
            .WithMessage("The file name contains invalid characters.");
    }

    private static bool BeAllowedSignature(IFormFile file)
    {
        var binary = new BinaryReader(file.OpenReadStream());
        var bytes = binary.ReadBytes(2);
        var fileSignatureHex = BitConverter.ToString(bytes);

        foreach (var signature in FileSettings.BlockedSignatures)
        {
            if (fileSignatureHex.Equals(signature, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
        }

        return true;
    }

    private static bool HasInvalidFileNameChars(string fileName)
    {
        return fileName.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
    }
}
