namespace FileManager.Contracts.Common;

public class FileSizeValidator : AbstractValidator<IFormFile>
{
    public FileSizeValidator()
    {
        RuleFor(x => x)
            .Must(file => file.Length <= FileSettings.MaxSizeInBytes)
            .When(x => x != null)
            .WithMessage($"File size must not exceed {FileSettings.MaxSizeInMB} MB.");
    }
}
