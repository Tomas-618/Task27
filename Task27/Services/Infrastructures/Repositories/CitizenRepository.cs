using System;
using System.Data;
using Task27.DataLayer;
using Task27.Services.Domain.Exceptions;
using Task27.Services.Domain.Models;
using Task27.Services.Infrastructures.Repositories.Contracts;

namespace Task27.Services.Infrastructures.Repositories
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly DataBaseProvider _baseProvider;

        public CitizenRepository(DataBaseProvider dataBaseProvider) =>
            _baseProvider = dataBaseProvider ?? throw new ArgumentNullException();

        public CitizenModel FindCitizen(TextHashModel hashModel)
        {
            DataTable dataTable = _baseProvider.FindCitizenData(hashModel.Hash);

            if (dataTable.Rows.Count == 0)
                throw new PassportNotFoundException(hashModel.Text);

            return new CitizenModel((bool)dataTable.Rows[0].ItemArray[1]);
        }
    }
}
