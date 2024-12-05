using System;

namespace Task27.DataLayer.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException(string filePath) =>
            FilePath = filePath ?? string.Empty;

        public string FilePath { get; }
    }
}
