namespace FileManager.Contracts;

public class UploadFileRequestValidator : AbstractValidator<UploadFileRequest>
{
    public UploadFileRequestValidator()
    {
        RuleFor(x => x.File)
            .SetValidator(new FileSizeValidator())
            .SetValidator(new FileSignatureValidator())
            .SetValidator(new FileNameValidator());
    }
}
