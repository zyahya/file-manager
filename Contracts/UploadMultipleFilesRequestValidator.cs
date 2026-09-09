namespace FileManager.Contracts;

public class UploadMultipleFilesRequestValidator : AbstractValidator<UploadMultipleFilesRequest>
{
    public UploadMultipleFilesRequestValidator()
    {
        RuleForEach(x => x.Files)
            .SetValidator(new FileSizeValidator());

        RuleForEach(x => x.Files)
            .SetValidator(new FileSignatureValidator());

        RuleForEach(x => x.Files)
            .SetValidator(new FileNameValidator());
    }
}
