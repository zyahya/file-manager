namespace FileManager.Contracts.Common;

public class ImageSignatureValidator : AbstractValidator<IFormFile>
{
    public ImageSignatureValidator()
    {
        RuleFor(x => x)
            .Must(IsImageSignatureAllowed)
            .When(x => x != null)
            .WithMessage("File type is not allowed.");
    }

    private static bool IsImageSignatureAllowed(IFormFile file)
    {
        var binary = new BinaryReader(file.OpenReadStream());
        var bytes = binary.ReadBytes(2);
        var fileSignatureHex = BitConverter.ToString(bytes);

        foreach (var signature in FileSettings.AllowedImageSignatures)
        {
            if (fileSignatureHex.Equals(signature, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}
