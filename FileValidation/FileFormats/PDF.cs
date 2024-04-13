﻿namespace FileValidation.FileFormats
{
    public class PDF : FileFormatDescriptor
    {
        protected override void Initialize()
        {
            TypeName = "PDF FILE";
            Extensions.Add(".pdf");
            MagicNumbers.Add([0x25, 0x50, 0x44, 0x46]);
        }
    }
}
