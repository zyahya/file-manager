namespace FileManager.Contracts;

public class UploadImageRequestValidator : AbstractValidator<UploadImageRequest>
{
    public UploadImageRequestValidator()
    {
        RuleFor(x => x.Image)
            .SetValidator(new FileSizeValidator())
            .SetValidator(new ImageSignatureValidator())
            .SetValidator(new ImageExtensionValidator())
            .SetValidator(new FileNameValidator());
    }
}
