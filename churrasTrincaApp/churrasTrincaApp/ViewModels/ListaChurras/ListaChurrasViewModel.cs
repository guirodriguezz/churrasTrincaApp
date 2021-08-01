using churrasTrincaApp.Models;
using churrasTrincaApp.Services;
using churrasTrincaApp.ViewModels.DetalhesChurras;
using churrasTrincaApp.Views.DetalhesChurras;
using MvvmHelpers;
using System.Collections.ObjectModel;
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
        #endregion

        #region Construtor
        public ListaChurrasViewModel()
        {
            CardsChurras = BaseServices.CardsChurras();
            DetalharListaCommand = new Command<DataCardsChurras>(DetalharLista);
        }
        #endregion

        #region Methods
        public async void DetalharLista(DataCardsChurras cardsChurrasModel)
        {
            DetalhesChurrasViewModel viewModel = new DetalhesChurrasViewModel();
            viewModel.CarregarDetalhes(cardsChurrasModel);

            await Application.Current.MainPage.Navigation.PushAsync(new DetalhesChurrasPage(viewModel), false);
        }
        #endregion
    }
}