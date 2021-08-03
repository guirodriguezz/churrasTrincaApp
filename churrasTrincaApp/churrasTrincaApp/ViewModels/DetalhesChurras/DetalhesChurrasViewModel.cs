using Acr.UserDialogs;
using churrasTrincaApp.Models;
using churrasTrincaApp.Services;
using MvvmHelpers;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace churrasTrincaApp.ViewModels.DetalhesChurras
{
    public class DetalhesChurrasViewModel : BaseViewModel
    {
        #region Variaveis
        private DataCardsChurras _cardsChurras;
        private ObservableCollection<DataListPeople> _listPeople;
        #endregion

        #region Propriedades
        public DataCardsChurras CardsChurras
        {
            get => _cardsChurras;
            set
            {
                _cardsChurras = value;
                OnPropertyChanged(nameof(CardsChurras));
            }
        }

        public ObservableCollection<DataListPeople> ListPeople
        {
            get => _listPeople;
            set
            {
                _listPeople = value;
                OnPropertyChanged(nameof(ListPeople));
            }
        }
        #endregion

        #region Commands
        public ICommand VoltarCommand { get; set; }
        #endregion

        #region Construtor
        public DetalhesChurrasViewModel()
        {
            VoltarCommand = new Command(async () => await Voltar());
        }
        #endregion

        #region Methods
        public async Task CarregarDetalhes(DataCardsChurras cardsChurrasModel)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Aguarde....");

                CardsChurras = cardsChurrasModel;
                ApiResponse<ListPeopleModel> response = await BaseServices.GetDetalhesChurrasco(Convert.ToInt32(cardsChurrasModel.Id));

                ListPeople = response.IsSuccessStatusCode ? response.Content.Data : null;
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

        public async Task Voltar()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}