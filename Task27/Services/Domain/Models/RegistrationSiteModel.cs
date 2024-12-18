﻿using System;
using Task27.Services.Domain.Models.Contracts;
using Task27.Services.Infrastructures.Repositories.Contracts;

namespace Task27.Services.Domain.Models
{
    public class RegistrationSiteModel
    {
        private readonly IHashStrategy _hasher;
        private readonly ICitizenRepository _citizenRepository;

        public RegistrationSiteModel(IHashStrategy hasher, ICitizenRepository citizenRepository)
        {
            _hasher = hasher ?? throw new ArgumentNullException(nameof(hasher));
            _citizenRepository = citizenRepository ?? throw new ArgumentNullException(nameof(citizenRepository));
        }

        public CitizenModel GetCitizen(PassportModel passport) =>
            _citizenRepository.FindCitizen(new TextHashModel(_hasher, passport.SerialNumber));
    }
}
