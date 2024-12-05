namespace Task27.Services.Domain.Models.Contracts
{
    public interface IHasher
    {
        string GetHash(string text);
    }
}
