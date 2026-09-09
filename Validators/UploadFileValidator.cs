using FileManager.Contracts;
using FileManager.Settings;
using FluentValidation;

namespace FileManager.Validators;

public class UploadFileValidator : AbstractValidator<UploadFileRequest>
{
    public UploadFileValidator()
    {
        RuleFor(x => x.File)
            .Must(file => file.Length <= FileSettings.MaxSizeInBytes)
            .When(x => x.File != null)
            .WithMessage($"File size must not exceed {FileSettings.MaxSizeInMB} MB.");
    }
}
