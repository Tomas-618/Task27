namespace Task27.Services.Domain.Models.Contracts
{
    public interface IHashStrategy
    {
        string GetHash(string text);
    }
}
