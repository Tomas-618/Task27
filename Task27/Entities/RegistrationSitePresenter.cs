using System;
using Task27.DataLayer.Exceptions;
using Task27.Entities.Contracts;
using Task27.Services.Domain.Exceptions;
using Task27.Services.Domain.Models;

namespace Task27
{
    public class RegistrationSitePresenter
    {
        private readonly IRegistrationSiteView _view;
        private readonly RegistrationSiteModel _model;

        public RegistrationSitePresenter(IRegistrationSiteView view, RegistrationSiteModel model)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public void OnButtonClicked(string passportSerialNumber)
        {
            try
            {
                PassportModel passport = new PassportModel(passportSerialNumber);

                CitizenModel citizen = _model.GetCitizen(passport);

                string voteAccess = citizen.CanVote ? "ПРЕДОСТАВЛЕН" : "НЕ ПРЕДОСТАВЛЯЛСЯ";

                _view.SetTextResult($"По паспорту «{passport.SerialNumber}» доступ к" +
                    $"бюллетеню на дистанционном электронном голосовании {voteAccess}");
            }
            catch (PassportNotFoundException passportNotFoundException)
            {
                _view.SetTextResult($"Паспорт «{passportNotFoundException.SerialNumber}» в списке" +
                    $"участников дистанционного голосования НЕ НАЙДЕН");
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                _view.ShowMessage($"Файл {fileNotFoundException.FilePath} не найден." +
                    $"Положите файл в папку вместе с exe.");
            }
            catch (ArgumentNullException)
            {
                _view.ShowMessage("Введите серию и номер паспорта");
            }
            catch (ArgumentOutOfRangeException)
            {
                _view.SetTextResult("Неверный формат серии или номера паспорта");
            }
        }
    }
}
