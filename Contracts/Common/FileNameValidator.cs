namespace FileManager.Contracts.Common;

public class FileNameValidator : AbstractValidator<IFormFile>
{
    public FileNameValidator()
    {
        RuleFor(x => x)
            .Must(file => HasInvalidFileNameChars(file.FileName))
            .When(x => x != null)
            .WithMessage("The file name contains invalid characters.");
    }

    private static bool HasInvalidFileNameChars(string fileName)
    {
        return fileName.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
    }
}
