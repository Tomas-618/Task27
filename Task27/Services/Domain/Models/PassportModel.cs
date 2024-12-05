using System;

namespace Task27.Services.Domain.Models
{
    public struct PassportModel
    {
        private const int MinSerialNumberLength = 10;

        public PassportModel(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber))
                throw new ArgumentNullException(nameof(serialNumber));

            SerialNumber = serialNumber.Replace(" ", string.Empty);

            if (SerialNumber.Length < MinSerialNumberLength)
                throw new ArgumentOutOfRangeException(SerialNumber);
        }

        public string SerialNumber { get; }
    }
}
