namespace FileManager.Settings;

public static class FileSettings
{
    public const int MaxSizeInMB = 1;
    public const int MaxSizeInBytes = MaxSizeInMB * 1024 * 1024;
    public static readonly string[] BlockedSignatures = ["4d-5a", "2f-2a", "d0-cf", "63-6f"];

    public static readonly string[] AllowedImageSignatures = ["ff-d8", "89-50"];
    public static readonly string[] AllowedImageExtensions = [".jpg", ".jpeg", ".png"];
}
