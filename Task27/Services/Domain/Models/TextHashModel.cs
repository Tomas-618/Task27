using System;
using Task27.Services.Domain.Models.Contracts;

namespace Task27.Services.Domain.Models
{
    public struct TextHashModel
    {
        private readonly IHashStrategy _hasher;

        public TextHashModel(IHashStrategy hasher, string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));

            _hasher = hasher ?? throw new ArgumentNullException(nameof(hasher));
            Text = text;
            Hash = _hasher.GetHash(text);
        }

        public string Text { get; }

        public string Hash { get; }
    }
}
