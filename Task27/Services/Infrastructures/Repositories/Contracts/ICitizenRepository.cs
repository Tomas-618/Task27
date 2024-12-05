using Task27.Services.Domain.Models;

namespace Task27.Services.Infrastructures.Repositories.Contracts
{
    public interface ICitizenRepository
    {
        CitizenModel FindCitizen(TextHashModel hashModel);
    }
}
