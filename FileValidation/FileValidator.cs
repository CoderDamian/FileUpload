using FileValidation.FileFormats;

namespace FileValidation
{
    public static class FileValidator
    {
        private static readonly List<FileFormatDescriptor> AllowedFormats = [new Image(), new PDF()];

        public static Result Validate(IFormFile file)
        {

            if (IsFileNull(file))
            {
                return new Result(false, Status.FAKE, "the file is null");
            }

            string? file_extension = Path.GetExtension(file.FileName);

            FileFormatDescriptor? target_type = AllowedFormats.FirstOrDefault(x => x.IsIncludedExtention(file_extension));

            if (target_type is null)
            {
                return new Result(false, Status.NOT_SUPPORTED, $"{Status.NOT_SUPPORTED}");
            }

            if (target_type.IsFileSizeExceeded(file.Length))
            {
                return new Result(false, Status.SIZE_EXCEEDED, $"{Status.SIZE_EXCEEDED}");
            }

            return target_type.Validate(file);
        }

        private static bool IsFileNull(IFormFile file)
            => file is null || file.Length == 0;
    }
}
