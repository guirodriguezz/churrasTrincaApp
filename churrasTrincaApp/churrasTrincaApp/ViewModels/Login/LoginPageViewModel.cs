using churrasTrincaApp.Views.ListaChurras;
using MvvmHelpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace churrasTrincaApp.ViewModels.Login
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Commands
        public ICommand LogarCommand { get; set; }
        #endregion

        #region Construtor
        public LoginPageViewModel()
        {
            LogarCommand = new Command(Logar);
        }
        #endregion

        #region Methods
        public void Logar()
        {
            Application.Current.MainPage = new NavigationPage(new ListaChurrasPage());
        }
        #endregion
    }
}