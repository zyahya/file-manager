namespace FileManager.Contracts;

public record UploadMultipleFilesRequest(
    IFormFileCollection Files
);
