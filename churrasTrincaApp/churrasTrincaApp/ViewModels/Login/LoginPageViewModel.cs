using Acr.UserDialogs;
using churrasTrincaApp.Models;
using churrasTrincaApp.Services;
using churrasTrincaApp.Views.ListaChurras;
using MvvmHelpers;
using Refit;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace churrasTrincaApp.ViewModels.Login
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Variaveis
        private string _username;
        private string _password;
        #endregion

        #region Propriedades
        public string Username
        {
            get => _username;
            set
            {
                if (Username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (Password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        #endregion

        #region Commands
        public ICommand LogarCommand { get; set; }
        #endregion

        #region Construtor
        public LoginPageViewModel()
        {
            LogarCommand = new Command(async () => await Logar());
        }
        #endregion

        #region Methods
        public async Task Logar()
        {
            if (string.IsNullOrEmpty(Username))
            {
                await UserDialogs.Instance.AlertAsync("Você precisa informar o usuário", "Atenção", "CONFIRMAR");
            }
            else if (string.IsNullOrEmpty(Password))
            {
                await UserDialogs.Instance.AlertAsync("Você precisa informar a senha", "Atenção", "CONFIRMAR");
            }
            else
            {
                try
                {
                    ApiResponse<TokenModel> response = await BaseServices.GetAutentication(Username, Password);

                    if (response.IsSuccessStatusCode)
                    {
                        SharedServices.SavedToken = response.Content;
                        Application.Current.MainPage = new NavigationPage(new ListaChurrasPage());
                    }
                    else
                    {
                        await UserDialogs.Instance.AlertAsync("Usuário não encontrado na nossa base de dados", "Atenção", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    Exception error = ex;
                    await UserDialogs.Instance.AlertAsync("Ocorreu um erro ao processar a sua solicitação.", "ATENÇÃO", "Ok");
                }
            }
        }
        #endregion
    }
}