using System;
using Task27.Entities.Contracts;
using Task27.Services.Domain.Models;

namespace Task27.Factories.Entities
{
    public class RegistrationSitePresenterFactory
    {
        private readonly RegistrationSiteModel _registrationSiteModel;

        public RegistrationSitePresenterFactory(RegistrationSiteModel registrationSiteModel) =>
            _registrationSiteModel = registrationSiteModel ??
            throw new ArgumentNullException(nameof(registrationSiteModel));

        public RegistrationSitePresenter Create(IRegistrationSiteView registrationSiteView) =>
            new RegistrationSitePresenter(registrationSiteView, _registrationSiteModel);
    }
}