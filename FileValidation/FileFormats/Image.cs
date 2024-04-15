﻿namespace FileValidation.FileFormats
{
    public class Image : FileFormatDescriptor
    {
        protected override void Initialize()
        {
            TypeName = "IMAGE FILE";
            MaximumFileSize = 1024 * 1024;
            Extensions.UnionWith([".jpeg", ".jpg", ".png"]);
            MagicNumbers.AddRange(new byte[][]
             {
                 [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A],
                 [0xFF, 0xD8, 0xFF, 0xE0],
                 [0xFF, 0xD8, 0xFF, 0xE1],
                 [0xFF, 0xD8, 0xFF, 0xE2],
                 [0xFF, 0xD8, 0xFF, 0xE3]
            });
        }
    }
}
