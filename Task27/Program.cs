using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Task27.DataLayer;
using Task27.Factories.Entities;
using Task27.Services.Domain.Models;
using Task27.Services.Infrastructures.Repositories;

namespace Task27
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataBaseProvider baseProvider = new DataBaseProvider(new ConnectionPathModel("Data Source=" +
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\{0}",
                "db.sqlite"));

            CitizenRepository citizenRepository = new CitizenRepository(baseProvider);

            RegistrationSiteModel siteModel = new RegistrationSiteModel(new Sha256HashStrategy(), citizenRepository);

            RegistrationSitePresenterFactory sitePresenterFactory = new RegistrationSitePresenterFactory(siteModel);

            RegistrationSiteView siteView = new RegistrationSiteView(sitePresenterFactory);

            Application.Run(siteView);
        }
    }
}
