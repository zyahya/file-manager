namespace FileManager.Contracts.Common;

public class FileSignatureValidator : AbstractValidator<IFormFile>
{
    public FileSignatureValidator()
    {
        RuleFor(x => x)
            .Must(BeNotBlockedSignature)
            .When(x => x != null)
            .WithMessage("File type is not allowed.");
    }

    private static bool BeNotBlockedSignature(IFormFile file)
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
}
