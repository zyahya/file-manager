namespace FileManager.Contracts.Common;

public class ImageExtensionValidator : AbstractValidator<IFormFile>
{
    public ImageExtensionValidator()
    {
        RuleFor(x => x)
            .Must(BeAllowedExtension)
            .When(x => x != null)
            .WithMessage($"Only allowed image extension methods are '.jpg', '.jpeg' and '.png'.");
    }

    private static bool BeAllowedExtension(IFormFile file)
    {
        var imageExtension = Path.GetExtension(file.FileName);

        if (imageExtension == string.Empty)
        {
            return false;
        }

        foreach (var extension in FileSettings.AllowedImageExtensions)
        {
            if (imageExtension.Equals(extension, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}
