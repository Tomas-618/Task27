using System;

namespace Task27.Services.Domain.Models
{
    public struct ConnectionPathModel
    {
        public ConnectionPathModel(string connectionString, string path)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            Path = path;

            Value = string.Format(connectionString, Path);
        }

        public string Path { get; }

        public string Value { get; }
    }
}
