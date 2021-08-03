using Acr.UserDialogs;
using churrasTrincaApp.Models;
using churrasTrincaApp.Services;
using churrasTrincaApp.ViewModels.DetalhesChurras;
using churrasTrincaApp.Views.DetalhesChurras;
using churrasTrincaApp.Views.ListaChurras;
using MvvmHelpers;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace churrasTrincaApp.ViewModels.ListaChurras
{
    public class ListaChurrasViewModel : BaseViewModel
    {
        #region Variaveis
        private ObservableCollection<DataCardsChurras> _cardsChurras;
        #endregion

        #region Propriedades
        public ObservableCollection<DataCardsChurras> CardsChurras
        {
            get => _cardsChurras;
            set
            {
                _cardsChurras = value;
                OnPropertyChanged(nameof(CardsChurras));
            }
        }
        #endregion

        #region Commands
        public ICommand DetalharListaCommand { get; set; }
        public ICommand CriarChurrasCommand { get; set; }
        public ICommand ExcluirChurrasCommand { get; set; }
        #endregion

        #region Construtor
        public ListaChurrasViewModel()
        {
            _ = CarregarCardsChurras();
            DetalharListaCommand = new Command<DataCardsChurras>(DetalharLista);
            CriarChurrasCommand = new Command(async () => await CriarChurras());
            ExcluirChurrasCommand = new Command<string>(ExcluirChurras);
        }
        #endregion

        #region Methods
        public async Task CarregarCardsChurras()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Aguarde....");

                ApiResponse<CardsChurrasModel> response = await BaseServices.GetChurrascos();

                CardsChurras = response.IsSuccessStatusCode ? response.Content.Data : new ObservableCollection<DataCardsChurras>();
            }
            catch (Exception ex)
            {
                Exception error = ex;
                await UserDialogs.Instance.AlertAsync("Ocorreu um erro ao processar a sua solicitação.", "ATENÇÃO", "Ok");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }

        }

        public async void DetalharLista(DataCardsChurras cardsChurrasModel)
        {
            DetalhesChurrasViewModel viewModel = new DetalhesChurrasViewModel();
            await viewModel.CarregarDetalhes(cardsChurrasModel);

            await Application.Current.MainPage.Navigation.PushAsync(new DetalhesChurrasPage(viewModel), false);
        }

        public async Task CriarChurras()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CriarChurrasPage(), false);
        }

        public async void ExcluirChurras(string id)
        {
            bool choice = await UserDialogs.Instance.ConfirmAsync("Tem certeza que deseja excluir esse churrasco?", "Confirme a Exclusão", "EXCLUIR", "CANCELAR");

            if (choice)
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Aguarde....");

                    ApiResponse<string> response = await BaseServices.DeleteChurras(Convert.ToInt32(id));

                    if (response.IsSuccessStatusCode)
                    {
                        foreach (DataCardsChurras item in CardsChurras.Where(x => x.Id == id).ToList())
                        {
                            CardsChurras.Remove(item);
                        }
                    }
                    else
                    {
                        await UserDialogs.Instance.AlertAsync("Não foi possível excluir o churrasco", "ATENÇÃO", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    Exception error = ex;
                    await UserDialogs.Instance.AlertAsync("Ocorreu um erro ao processar a sua solicitação.", "ATENÇÃO", "Ok");
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
            
        }
        #endregion
    }
}