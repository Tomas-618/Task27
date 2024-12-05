using System;

namespace Task27.Services.Domain.Exceptions
{
    public class PassportNotFoundException : Exception
    {
        public PassportNotFoundException(string serialNumber) =>
            SerialNumber = serialNumber ?? string.Empty;

        public string SerialNumber { get; }
    }
}
