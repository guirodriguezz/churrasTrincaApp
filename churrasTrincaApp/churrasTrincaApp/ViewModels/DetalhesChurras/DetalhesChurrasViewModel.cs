using churrasTrincaApp.Models;
using churrasTrincaApp.Services;
using MvvmHelpers;
using System;
using System.Collections.ObjectModel;

namespace churrasTrincaApp.ViewModels.DetalhesChurras
{
    public class DetalhesChurrasViewModel : BaseViewModel
    {
        #region Variaveis
        private DataCardsChurras _cardsChurras;
        private ObservableCollection<ListPeopleModel> _listPeople;
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

        public ObservableCollection<ListPeopleModel> ListPeople
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
        #endregion

        #region Construtor
        public DetalhesChurrasViewModel()
        {

        }
        #endregion

        #region Methods
        public void CarregarDetalhes(DataCardsChurras cardsChurrasModel)
        {
            CardsChurras = cardsChurrasModel;
            ListPeople = BaseServices.ListPeople();
        }
        #endregion
    }
}