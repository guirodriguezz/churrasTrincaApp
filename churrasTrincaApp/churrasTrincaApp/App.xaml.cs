using Acr.UserDialogs;
using churrasTrincaApp.Models;
using churrasTrincaApp.Services;
using churrasTrincaApp.Views.ListaChurras;
using churrasTrincaApp.Views.Login;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace churrasTrincaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            _ = OpenScreen();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected async Task OpenScreen()
        {
            bool temUser = SharedServices.ContainsUser();

            if (temUser)
            {
                string username = SharedServices.Saveduser.Username;
                string password = SharedServices.Saveduser.Password;

                try
                {
                    UserDialogs.Instance.ShowLoading("Aguarde....");

                    Refit.ApiResponse<TokenModel> response = await BaseServices.GetAutentication(username, password);

                    MainPage = response.IsSuccessStatusCode ? new NavigationPage(new ListaChurrasPage()) : new NavigationPage(new LoginPage());
                }
                catch (System.Exception ex)
                {
                    System.Exception error = ex;
                    await UserDialogs.Instance.AlertAsync("Ocorreu um erro ao processar a sua solicitação.", "ATENÇÃO", "Ok");
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }

            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
