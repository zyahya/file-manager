namespace FileManager.Contracts;

public class UploadFileRequestValidator : AbstractValidator<UploadFileRequest>
{
    public UploadFileRequestValidator()
    {
        RuleFor(x => x.File)
            .SetValidator(new FileSizeValidator());

        RuleFor(x => x.File)
            .SetValidator(new FileSignatureValidator());

        RuleFor(x => x.File)
            .SetValidator(new FileNameValidator());
    }
}
