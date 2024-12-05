namespace Task27.Services.Domain.Models
{
    public struct CitizenModel
    {
        public CitizenModel(bool canVote) =>
            CanVote = canVote;

        public bool CanVote { get; }
    }
}
