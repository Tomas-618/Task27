using System;
using Task27.Services.Domain.Models.Contracts;

namespace Task27.Services.Domain.Models
{
    public struct TextHashModel
    {
        public TextHashModel(IHashStrategy hasher, string text)
        {
            if (hasher == null)
                throw new ArgumentNullException(nameof(hasher));

            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));

            Text = text;
            Hash = hasher.GetHash(text);
        }

        public string Text { get; }

        public string Hash { get; }
    }
}
