using System;
using System.Windows.Forms;
using Task27.Entities.Contracts;
using Task27.Factories.Entities;

namespace Task27
{
    public partial class RegistrationSiteView : Form, IRegistrationSiteView
    {
        private readonly RegistrationSitePresenter _presenter;

        public RegistrationSiteView(RegistrationSitePresenterFactory presenterFactory)
        {
            if (presenterFactory == null)
                throw new ArgumentNullException(nameof(presenterFactory));

            _presenter = presenterFactory.Create(this);

            InitializeComponent();
        }

        private void ClickButton(object sender, EventArgs eventArgs) =>
            _presenter.OnButtonClicked(_passportTextbox.Text);

        public void ShowMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            MessageBox.Show(message);
        }

        public void SetTextResult(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            _textResult.Text = message;
        }
    }
}
