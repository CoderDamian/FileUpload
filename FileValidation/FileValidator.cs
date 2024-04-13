using FileValidation.FileFormats;

namespace FileValidation
{
    public static class FileValidator
    {
        private static readonly List<FileFormatDescriptor> AllowedFormats = [new Image(), new PDF()];

        public static Result Validate(IFormFile file)
        {
            var file_extension = Path.GetExtension(file.FileName);

            var target_type = AllowedFormats.FirstOrDefault(x => x.IsIncludedExtention(file_extension));

            if (target_type is null)
            {
                return new Result(false, Status.NOT_SUPPORTED, $"{Status.NOT_SUPPORTED}");
            }
            else
            {
                return target_type.Validate(file);
            }
        }
    }
}
