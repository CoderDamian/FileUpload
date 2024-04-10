namespace FileValidation.FileFormats
{
    /// <summary>
    /// Abstract class which will act as a base class for specific file-type implementations
    /// </summary>
    public abstract class FileFormatDescriptor
    {
        public FileFormatDescriptor()
        {
            Initialize();
            MaxMagicNumberLength = MagicNumbers.Max(m => m.Length);
        }

        protected abstract void Initialize();

        // store supported file extensions
        protected HashSet<string> Extensions { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        
        // store the corresponding file signatures to the file extensions        
        protected List<byte[]> MagicNumbers { get; } = [];

        protected int MaxMagicNumberLength { get; }
        public string TypeName { get; set; }

        public bool IsIncludedExtention(string extension)
            => Extensions.Contains(extension);

        /// <summary>
        /// Will be responsible for performing validation
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public Result Validate(IFormFile formFile)
        {
            using var stream = formFile.OpenReadStream();

            // majority of file formats have relatively short signatures, typically less than 16 bytes, If byte requirements exceed a reasonable length, such as 256 bytes, utilize ArrayPool
            Span<byte> initialBytes = stackalloc byte[MaxMagicNumberLength];

            int readBytes = stream.Read(initialBytes);

            foreach (var magicNumber in MagicNumbers)
            {
                if (initialBytes[..magicNumber.Length].SequenceCompareTo(magicNumber) == 0)
                    return new Result(true, Status.GENUINE, $"{Status.GENUINE} {TypeName}");
            }

            return new Result(false, Status.FAKE, $"{Status.FAKE} {TypeName} !");
        }
    }
}
